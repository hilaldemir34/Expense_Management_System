using ExpenseManagementSystem.Application.Repositories;
using ExpenseManagementSystem.Domain.Entities;
using ExpenseManagementSystem.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace ExpenseManagementSystem.Persistence.Repositories
{
    public class ExpenseRepository : IExpenseRepository
    {
        private readonly ApplicationDbContext _context;
        public ExpenseRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task AddAsync(Expense expense)
        {
            await _context.Expenses.AddAsync(expense);
        }

        public async Task AddRangeAsync(IEnumerable<Expense> expenses)
        {
            await _context.Expenses.AddRangeAsync(expenses);
        }

        public void Delete(Expense expense)
        {
           _context.Expenses.Remove(expense);
        }

        public async Task<IEnumerable<Expense>> GetAllAsync()
        {
          return await _context.Expenses.ToListAsync();
        }

        public async Task<Expense?> GetByIdAsync(int id)
        {
           return await _context.Expenses.FindAsync(id);
        }

        public void Update(Expense expense)
        {
            _context.Expenses.Update(expense);
        }

        public async Task<IEnumerable<Expense>> FilterByAsync(Func<Expense, bool> predicate)
        {
            return await Task.FromResult(_context.Expenses.Where(predicate).ToList());
        }


    }
}
