using ExpenseManagementSystem.Application.Features.ExpenseRequests.DTOs;
using ExpenseManagementSystem.Application.Features.Payments.DTOs;
using ExpenseManagementSystem.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ExpenseManagementSystem.Application.Features.ExpenseRequests
{
    public interface IExpenseRequestService
    {
        Task<IEnumerable<GetExpenseRequestDto>> GetAllExpenseRequestsAsync();
        Task<GetExpenseRequestDto?> GetByIdAsync(int id);
        Task<ExpenseRequest> CreateAsync(CreateExpenseRequestDto createExpenseRequestDto);
        Task UpdateAsync(UpdateExpenseRequestDto dto);
        Task DeleteAsync(int id);
        Task<IEnumerable<ExpenseRequest>> GetPendingExpenseRequestsAsync();
        Task<IEnumerable<ExpenseRequest>> GetApprovedExpenseRequestsAsync();
        Task<IEnumerable<ExpenseRequest>> GetRejectedExpenseRequestsAsync();
        Task<List<GetExpenseRequestDto>> GetExpensesByUserIdAsync();
        Task<EftRequestDto> ApproveAsync(int id);
        Task<RejectionResponseDto> RejectAsync(int id, string rejectionReason);
        Task<IEnumerable<GetExpenseRequestDto>> FilterMyRequestsAsync(ExpenseRequestFilterDto filter);

    }
}
