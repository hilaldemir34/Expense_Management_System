using ExpenseManagementSystem.Application.Features.ExpenseRequests;
using ExpenseManagementSystem.Application.Features.ExpenseRequests.DTOs;
using ExpenseManagementSystem.Application.Features.Payments.DTOs;
using ExpenseManagementSystem.Application.Interfaces;
using ExpenseManagementSystem.Application.Repositories;
using ExpenseManagementSystem.Domain.Entities;
using ExpenseManagementSystem.Domain.Entities.Identity;
using ExpenseManagementSystem.Domain.Enums;
using ExpenseManagementSystem.Domain.Interfaces;
using ExpenseManagementSystem.Infrastructure.Channels;



using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
namespace ExpenseManagementSystem.Application.Managers
{
    public class ExpenseRequestManager : IExpenseRequestService
    {
        private readonly IExpenseRequestRepository _expenseRequestRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICurrentUser _currentUser;
        private readonly IEftChannel _eftChannel;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IPaymentRepository _paymentRepository;

        public ExpenseRequestManager(IExpenseRequestRepository expenseRequestRepository, IUnitOfWork unitOfWork, ICurrentUser currentUser, IEftChannel eftChannel, IHttpContextAccessor httpContextAccessor, UserManager<ApplicationUser> userManager, IPaymentRepository paymentRepository)
        {

            _expenseRequestRepository = expenseRequestRepository;
            _unitOfWork = unitOfWork;
            _currentUser = currentUser;
            _eftChannel = eftChannel;
            _httpContextAccessor = httpContextAccessor;
            _userManager = userManager;
            _paymentRepository = paymentRepository;
        }

        public async Task<EftRequestDto> ApproveAsync(int id)
        {
            var expenseRequest = await _expenseRequestRepository.GetByIdAsync(id).ConfigureAwait(false);
            if (expenseRequest == null)
            {
                throw new InvalidOperationException("Expense request not found");
            }
            if(expenseRequest.Status != ApprovalStatus.Pending)
            {
                throw new InvalidOperationException("Expense request is not pending");
            }
            expenseRequest.Status = ApprovalStatus.Approved;
            await _unitOfWork.SaveChangesAsync().ConfigureAwait(false);

            var adminId = _httpContextAccessor.HttpContext!
                           .User.FindFirstValue(ClaimTypes.NameIdentifier)!;
            var adminUser = await _userManager.FindByIdAsync(adminId).ConfigureAwait(false)
                              ?? throw new InvalidOperationException("Admin not found");

            var total = expenseRequest.Expenses?.Sum(e => e.Amount) ?? 0m;

            var payment = new Payment
            {
                Amount = total,
                PaidAt = DateTime.UtcNow,  
                ExpenseRequestId = expenseRequest.Id,  
                SenderUserId = adminUser.Id,  
                ReceiverUserId = expenseRequest.User.Id,
                Status = PaymentStatus.Pending.ToString()

            };

            await _paymentRepository.AddAsync(payment); 
            await _unitOfWork.SaveChangesAsync();  

            var requestDto = new EftRequestDto
            {
                ExpenseRequestId = expenseRequest.Id,
                FromIban = adminUser.Iban,
                ToIban = expenseRequest.User.Iban,
                Amount = total
            };
            await _eftChannel.Writer.WriteAsync(requestDto).ConfigureAwait(false);

            return new EftRequestDto
            {
                ExpenseRequestId = requestDto.ExpenseRequestId,
                FromIban = requestDto.FromIban,
                ToIban = requestDto.ToIban,
                Amount = requestDto.Amount,
                Message = "Ödeme gerçekleştirilecektir."
            };
        }


        public async Task<ExpenseRequest> CreateAsync(CreateExpenseRequestDto createExpenseRequestDto)
        {
            var expenseRequest = new ExpenseRequest
            {
                UserId = _currentUser.UserId,
                Status = ApprovalStatus.Pending,
                RequestDate = DateTime.UtcNow,
            };
            await _expenseRequestRepository.AddAsync(expenseRequest);
            return expenseRequest;
        }
        public async Task DeleteAsync(int id)
        {
            var expenseRequest = await _expenseRequestRepository.GetByIdAsync(id);
            if (expenseRequest != null)
            {
                _expenseRequestRepository.Delete(expenseRequest);
                await _unitOfWork.SaveChangesAsync();
            }

        }
        public async Task<IEnumerable<GetExpenseRequestDto>> GetAllExpenseRequestsAsync()

        {
            return await _expenseRequestRepository.GetAllExpenseRequestsAsync();

        }

        public async Task<IEnumerable<ExpenseRequest>> GetApprovedExpenseRequestsAsync()
        {
            return await _expenseRequestRepository.FilterByAsync(x => x.Status == ApprovalStatus.Approved);
        }

        public async Task<GetExpenseRequestDto?> GetByIdAsync(int id)
        {
            return await _expenseRequestRepository.GetByIdDetailAsync(id);
        }

        public async Task<List<GetExpenseRequestDto>> GetExpensesByUserIdAsync()
        {

            return await _expenseRequestRepository.GetExpensesByUserIdAsync(_currentUser.UserId);
        }


        public async Task<IEnumerable<ExpenseRequest>> GetPendingExpenseRequestsAsync()
        {
            return await _expenseRequestRepository.FilterByAsync(x => x.Status == ApprovalStatus.Pending);
        }

        public async Task<IEnumerable<ExpenseRequest>> GetRejectedExpenseRequestsAsync()
        {
            return await _expenseRequestRepository.FilterByAsync(x => x.Status == ApprovalStatus.Rejected);
        }


        public async Task UpdateAsync(UpdateExpenseRequestDto dto)
        {
            var existingExpenseRequest = await _expenseRequestRepository.GetByIdAsync(dto.Id);

            if (existingExpenseRequest == null)
            {
                throw new InvalidOperationException("Expense request not found");
            }

            existingExpenseRequest.Status = dto.Status;
            existingExpenseRequest.RejectionReason = dto.RejectionReason;

            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<RejectionResponseDto> RejectAsync(int id, string rejectionReason)
        {
            var er = await _expenseRequestRepository.GetByIdAsync(id)
             ?? throw new InvalidOperationException("Expense request not found");
            if (er.Status != ApprovalStatus.Pending)
            {
                throw new InvalidOperationException("Expense request is not pending");
            }
            er.Status = ApprovalStatus.Rejected;
            er.RejectionReason = rejectionReason;
            await _unitOfWork.SaveChangesAsync();

            return new RejectionResponseDto
            {
                ExpenseRequestId = er.Id,
                RejectionReason = rejectionReason,
                Message = "Ödeme gerçekleştirilemedi: " + rejectionReason
            };
        }
        public async Task<IEnumerable<GetExpenseRequestDto>> FilterMyRequestsAsync(ExpenseRequestFilterDto filter)
        {
            var userId = _currentUser.UserId;
            var list = await _expenseRequestRepository.FilterByCriteriaAsync(userId, filter);

            return list.Select(er => new GetExpenseRequestDto
            {
                Id = er.Id,
                Status = er.Status.ToString(),
                RejectionReason = er.RejectionReason ?? "",
                RequestDate = er.RequestDate,
                User = er.User == null
                    ? new UserDto { Id = "", Name = "", Email="", Iban="", PhoneNumber="" }
                    : new UserDto { Id = er.User.Id, Name = er.User.NameSurname, Iban=er.User.Iban, PhoneNumber=er.User.PhoneNumber},
                Expenses = (er.Expenses ?? Enumerable.Empty<Expense>())
                    .Select(e => new ExpenseDto
                    {
                        Id = e.Id,
                        Amount = e.Amount,
                        Description = e.Description,
                        CreatedDate = e.CreatedDate,
                        ExpenseCategory = e.ExpenseCategory == null
                            ? new GetExpenseRequestExpenseCategoryDto()
                            : new GetExpenseRequestExpenseCategoryDto
                            {
                                Id = e.ExpenseCategory.Id,
                                Name = e.ExpenseCategory.Name
                            }
                    }).ToList()
            }).ToList();
        }
    }
}
