using ExpenseManagementSystem.Application.Features.ExpenseCategories.DTOs;
using ExpenseManagementSystem.Application.Repositories;
using ExpenseManagementSystem.Domain.Entities;
using ExpenseManagementSystem.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace ExpenseManagementSystem.Persistence.Repositories
{
    public class ExpenseCategoryRepository : IExpenseCategoryRepository
    {
        private readonly ApplicationDbContext _context;

        public ExpenseCategoryRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(ExpenseCategory expenseCategory)
        {
            await _context.ExpenseCategories.AddAsync(expenseCategory);
        }

        public void Delete(ExpenseCategory expenseCategory)
        {
            _context.ExpenseCategories.Remove(expenseCategory);
        }

        public async Task<IEnumerable<ExpenseCategoryDto?>> GetAllAsync()
        {
            return await _context.ExpenseCategories
                    .Select(x => new ExpenseCategoryDto
                    {
                        Id = x.Id,
                        Name = x.Name
                    }).ToListAsync();
        }


        public Task<ExpenseCategoryDto?> GetByIdAsync(int id)
        {
            return _context.ExpenseCategories.Where(x => x.Id == id).Select(x => new ExpenseCategoryDto
            {
                Id = x.Id,
                Name = x.Name
            }).FirstOrDefaultAsync();
        }

        public void Update(ExpenseCategory expenseCategory)
        {
            var existing = _context.ExpenseCategories
                .Local
                .FirstOrDefault(c => c.Id == expenseCategory.Id);

            if (existing == null)
            {
                existing = _context.ExpenseCategories.Find(expenseCategory.Id);
            }

            if (existing != null)
            {
                existing.Name = expenseCategory.Name;
                _context.Entry(existing).State = EntityState.Modified;
            }
            else
            {

                _context.ExpenseCategories.Attach(expenseCategory);
                _context.Entry(expenseCategory).State = EntityState.Modified;
            }
        }
        public async Task<ExpenseCategory?> GetDomainByIdAsync(int id)
        {
            return await _context.ExpenseCategories.FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task<bool> ExistsByNameAsync(string name)
        {
            return await _context.ExpenseCategories
             .AnyAsync(c => c.Name == name);
        }

        public async Task<ExpenseCategory?> GetDomainByNameAsync(string name)
        {
            return await _context.ExpenseCategories
                .FirstOrDefaultAsync(c => c.Name == name);
        }

    }

}
