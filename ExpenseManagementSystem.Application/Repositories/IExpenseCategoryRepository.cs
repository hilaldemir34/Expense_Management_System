using ExpenseManagementSystem.Application.Features.ExpenseCategories.DTOs;
using ExpenseManagementSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseManagementSystem.Application.Repositories
{
    public interface IExpenseCategoryRepository
    {
        Task AddAsync(ExpenseCategory expenseCategory);
        Task<ExpenseCategoryDto> GetByIdAsync(int id);
        Task<IEnumerable<ExpenseCategoryDto?>> GetAllAsync();
        Task<ExpenseCategory?> GetDomainByIdAsync(int id);
        void Update(ExpenseCategory expenseCategory);
        void Delete(ExpenseCategory expenseCategory);
        Task<bool> ExistsByNameAsync(string name);
        Task<ExpenseCategory?> GetDomainByNameAsync(string name);
    }
}
