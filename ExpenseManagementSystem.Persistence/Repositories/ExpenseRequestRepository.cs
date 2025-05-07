using ExpenseManagementSystem.Application.Features.ExpenseRequests.DTOs;
using ExpenseManagementSystem.Application.Repositories;
using ExpenseManagementSystem.Domain.Entities;
using ExpenseManagementSystem.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ExpenseManagementSystem.Persistence.Repositories
{
    public class ExpenseRequestRepository : IExpenseRequestRepository
    {
        private readonly ApplicationDbContext _context;
        public ExpenseRequestRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public void Add(ExpenseRequest expenseRequest)
        {
            _context.ExpenseRequests.Add(expenseRequest);
        }

        public async Task AddAsync(ExpenseRequest expenseRequest)
        {
            await _context.ExpenseRequests.AddAsync(expenseRequest);
        }

        public void Delete(ExpenseRequest expenseRequest)
        {
            _context.ExpenseRequests.Remove(expenseRequest);
        }

        public async Task<IEnumerable<ExpenseRequest>> FilterByAsync(Expression<Func<ExpenseRequest, bool>> predicate)
        {
            return await _context.ExpenseRequests.Where(predicate)
                .Include(er => er.User)
                .Include(er => er.Expenses)
                .ThenInclude(e => e.ExpenseCategory)
                .Include(er => er.Payments)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<IEnumerable<ExpenseRequest>> GetAllAsync()
        {
            return await _context.ExpenseRequests.ToListAsync();
        }

        public async Task<IEnumerable<GetExpenseRequestDto>> GetAllExpenseRequestsAsync()
        {
            return await _context.ExpenseRequests.Include(er => er.User).Include(er => er.Documents).Include(er => er.Expenses).ThenInclude(e => e.ExpenseCategory)
               .Select(er => new GetExpenseRequestDto
               {
                   Id = er.Id,
                   Status = er.Status.ToString(),
                   RejectionReason = er.RejectionReason ?? string.Empty,
                   RequestDate = er.RequestDate,
                   Files = er.Documents.Select(e => e.Location).ToList(),
                   User = new UserDto
                   {
                       Id = er.User.Id,
                       Name = er.User.NameSurname,
                       Iban = er.User.Iban,
                       Email = er.User.Email,
                       PhoneNumber = er.User.PhoneNumber,
                   },
                   Expenses = er.Expenses.Select(e => new ExpenseDto
                   {
                       Id = e.Id,
                       Amount = e.Amount,
                       Description = e.Description,
                       CreatedDate = e.CreatedDate,

                       ExpenseCategory = new GetExpenseRequestExpenseCategoryDto
                       {
                           Id = e.ExpenseCategory.Id,
                           Name = e.ExpenseCategory.Name
                       }
                   }).ToList()
               })
               .ToListAsync();
        }

        public async Task<GetExpenseRequestDto?> GetByIdDetailAsync(int id)
        {
           return await _context.ExpenseRequests
                 .Include(er => er.User)
             .Include(er => er.Expenses)
             .ThenInclude(e => e.ExpenseCategory)
        .Select(expenseRequest => new GetExpenseRequestDto
        {
            Id = expenseRequest.Id,
            Status = expenseRequest.Status.ToString(),
            RejectionReason = expenseRequest.RejectionReason ?? string.Empty,
            RequestDate = expenseRequest.RequestDate,
            User= new UserDto
                    {
                        Id = expenseRequest.User.Id,
                        Name = expenseRequest.User.NameSurname,
                        Iban = expenseRequest.User.Iban,
                        Email = expenseRequest.User.Email,
                        PhoneNumber = expenseRequest.User.PhoneNumber
                    },
                   
            Expenses = expenseRequest.Expenses
                    .Select(e => new ExpenseDto
                    {
                        Id = e.Id,
                        Amount = e.Amount,
                        Description = e.Description,
                        CreatedDate = e.CreatedDate,
                        ExpenseCategory= new GetExpenseRequestExpenseCategoryDto
                            {
                                Id = e.ExpenseCategory.Id,
                                Name = e.ExpenseCategory.Name
                            }
         
                    }).ToList() ?? new List<ExpenseDto>(),
        })



        .FirstOrDefaultAsync(er => er.Id == id);
        }

        public async Task<List<GetExpenseRequestDto>> GetExpensesByUserIdAsync(string userId)
        {
            var requests = _context.ExpenseRequests
            .Where(r => r.UserId == userId)
            .Include(r => r.User)
            .Include(r => r.Expenses)
            .ThenInclude(e => e.ExpenseCategory); 
            return await requests.Select(r => new GetExpenseRequestDto
            {
                Id = r.Id,
                Status = r.Status.ToString(),
                RejectionReason = r.RejectionReason ?? string.Empty,
                RequestDate = r.RequestDate,
                User = new UserDto
                {
                    Id = r.User.Id
                },
                Expenses = r.Expenses.Select(e => new ExpenseDto
                {
                    Id = e.Id,
                    Amount = e.Amount,
                    Description = e.Description,
                    CreatedDate = e.CreatedDate,
                    ExpenseCategory = new GetExpenseRequestExpenseCategoryDto
                    {
                        Id = e.ExpenseCategory.Id,
                        Name = e.ExpenseCategory.Name
                    }
                }).ToList()
            }).ToListAsync();
        }
        public async Task<IEnumerable<ExpenseRequest>> FilterByCriteriaAsync(string userId, ExpenseRequestFilterDto f)
        {
            var query = _context.ExpenseRequests
                .Where(r => r.UserId == userId)
                 .Include(r => r.User)
                .Include(r => r.Expenses)
                    .ThenInclude(e => e.ExpenseCategory)
                .AsQueryable();

            if (f.Status.HasValue)
                query = query.Where(r => r.Status.ToString() == f.Status.Value.ToString());

            if (f.CategoryId.HasValue)
                query = query.Where(r => r.Expenses.Any(e => e.ExpenseCategoryId == f.CategoryId.Value));

            if (f.MinAmount.HasValue)
                query = query.Where(r => r.Expenses.Sum(e => e.Amount) >= f.MinAmount.Value);

            if (f.MaxAmount.HasValue)
                query = query.Where(r => r.Expenses.Sum(e => e.Amount) <= f.MaxAmount.Value);

            return await query.ToListAsync();
        }


        public void Update(ExpenseRequest expenseRequest)
        {
            _context.ExpenseRequests.Update(expenseRequest);
        }

        public async Task<ExpenseRequest?> GetByIdAsync(int id)
        {
            return await _context.ExpenseRequests
                .Include(er => er.User)
                .Include(er => er.Expenses)
                .ThenInclude(e => e.ExpenseCategory)
                .Include(er => er.Documents)
                .FirstOrDefaultAsync(er => er.Id == id);
        }
    }
}
