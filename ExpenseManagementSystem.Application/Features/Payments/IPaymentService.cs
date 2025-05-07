using ExpenseManagementSystem.Application.Features.Payments.DTOs;

namespace ExpenseManagementSystem.Application.Features.Payments
{

    public interface IPaymentService
    {
        Task<PaymentDto> GetByIdAsync(int id);
        Task<IEnumerable<PaymentDto>> GetAllAsync();
        Task<IEnumerable<PaymentDto>> GetByRequestIdAsync(int expenseRequestId);
        Task<PaymentDto> CreateAsync(CreatePaymentDto dto);
        Task DeleteAsync(int id);
    }
}
