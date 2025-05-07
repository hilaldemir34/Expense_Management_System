using ExpenseManagementSystem.Domain.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseManagementSystem.Application.Repositories
{
    public interface IExpenseRepository
    {
        Task AddAsync(Expense expense);
        Task AddRangeAsync(IEnumerable<Expense> expenses);
        Task<Expense?> GetByIdAsync(int id);
        Task<IEnumerable<Expense>> GetAllAsync();
        void Update(Expense expense);
        void Delete(Expense expense);
        Task<IEnumerable<Expense>> FilterByAsync(Func<Expense, bool> predicate);


    }
}
