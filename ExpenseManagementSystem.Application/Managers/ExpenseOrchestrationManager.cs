using ExpenseManagementSystem.Application.Features.ExpenseRequests;
using ExpenseManagementSystem.Application.Features.ExpenseRequests.DTOs;
using ExpenseManagementSystem.Application.Features.Expenses;
using ExpenseManagementSystem.Application.Interfaces;
using ExpenseManagementSystem.Domain.Interfaces;

namespace ExpenseManagementSystem.Application.Managers
{
    public class ExpenseOrchestrationManager : IExpenseOrchestrationService
    {
        IUnitOfWork _unitOfWork;
        IExpenseRequestService _expenseRequestService;
        IExpenseService _expenseService;
        public ExpenseOrchestrationManager(IExpenseRequestService expenseRequestService, IUnitOfWork unitOfWork, IExpenseService expenseService)
        {
            _expenseRequestService = expenseRequestService;
            _unitOfWork = unitOfWork;
            _expenseService = expenseService;
        }
        public async Task CreateAsync(CreateExpenseRequestDto dto)
        {

            var expenseRequest = await _expenseRequestService.CreateAsync(dto);
            var expense = await _expenseService.CreateAsync(dto.Expenses);

            expenseRequest.Expenses=expense.ToList();

            await _unitOfWork.SaveChangesAsync();

        }
    }
}
