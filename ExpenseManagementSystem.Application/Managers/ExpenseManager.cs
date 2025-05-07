using ExpenseManagementSystem.Application.Features.Expenses;
using ExpenseManagementSystem.Application.Features.Expenses.DTOs;
using ExpenseManagementSystem.Application.Repositories;
using ExpenseManagementSystem.Domain.Entities;
using ExpenseManagementSystem.Domain.Interfaces;

namespace ExpenseManagementSystem.Application.Managers
{
    public class ExpenseManager : IExpenseService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IExpenseRepository _expenseRepository;
        public ExpenseManager(IExpenseRepository expenseRepository, IUnitOfWork unitOfWork)
        {
            _expenseRepository = expenseRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<Expense> CreateAsync(CreateExpenseDto createExpenseDto)
        {
            var expense = new Expense
            {
                Amount = createExpenseDto.Amount,
                Description = createExpenseDto.Description,
                ExpenseCategoryId = createExpenseDto.CategoryId,
                CreatedDate = DateTime.UtcNow,

            };
            await _expenseRepository.AddAsync(expense);
            return expense;
        }

        public async Task<IEnumerable<Expense>> CreateAsync(IEnumerable<CreateExpenseDto> createExpenseDtos)
        {
            var expenses = createExpenseDtos.Select(dto => new Expense
            {
                Amount = dto.Amount,
                ExpenseCategoryId = dto.CategoryId,
                Description = dto.Description,
                CreatedDate = DateTime.UtcNow,
            }).ToList();
            await _expenseRepository.AddRangeAsync(expenses);
            return expenses;

        }
        public async Task DeleteAsync(int id)
        {
            var expense = await _expenseRepository.GetByIdAsync(id);
            if (expense != null)
            {
                _expenseRepository.Delete(expense);
                await _unitOfWork.SaveChangesAsync();
            }
        }
        public async Task<IEnumerable<Expense>> GetAllExpensesAsync()
        {
            return await _expenseRepository.GetAllAsync();
        }
        public async Task<Expense?> GetExpenseByIdAsync(int id)
        {
            return await _expenseRepository.GetByIdAsync(id);
        }
        public async Task UpdateAsync(UpdateExpenseDto updateExpenseDto)
        {

            var expense = await _expenseRepository.GetByIdAsync(updateExpenseDto.Id);
            if (expense != null)
            {
                expense.Amount = updateExpenseDto.Amount;
                expense.Description = updateExpenseDto.Description;
                _expenseRepository.Update(expense);
                await _unitOfWork.SaveChangesAsync();
            }
        }

    }
}
