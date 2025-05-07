using ExpenseManagementSystem.Application.Features.Expenses.DTOs;
using ExpenseManagementSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseManagementSystem.Application.Features.Expenses
{
    public interface IExpenseService
    {
        Task<IEnumerable<Expense>> GetAllExpensesAsync();
        Task<Expense?> GetExpenseByIdAsync(int id);
        Task<Expense> CreateAsync(CreateExpenseDto createExpenseDto);
        Task<IEnumerable<Expense>> CreateAsync(IEnumerable<CreateExpenseDto> createExpenseDtos);
        Task UpdateAsync(UpdateExpenseDto updateExpenseDto);
        Task DeleteAsync(int id);
    }
}
