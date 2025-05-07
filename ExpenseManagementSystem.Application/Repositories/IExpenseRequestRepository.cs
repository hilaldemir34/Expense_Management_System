using ExpenseManagementSystem.Application.Features.ExpenseRequests.DTOs;
using ExpenseManagementSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseManagementSystem.Application.Repositories
{
    public interface IExpenseRequestRepository
    {
        Task AddAsync(ExpenseRequest expenseRequest);
        void Update(ExpenseRequest expenseRequest);
        void Delete(ExpenseRequest expenseRequest);
        Task<GetExpenseRequestDto?> GetByIdDetailAsync(int id);
        Task<ExpenseRequest?> GetByIdAsync(int id);

        Task<IEnumerable<ExpenseRequest>> GetAllAsync();
        Task<IEnumerable<ExpenseRequest>> FilterByAsync(Expression<Func<ExpenseRequest, bool>> predicate);
        Task<IEnumerable<GetExpenseRequestDto>> GetAllExpenseRequestsAsync();
        Task<List<GetExpenseRequestDto>> GetExpensesByUserIdAsync(string userId);
        Task<IEnumerable<ExpenseRequest>> FilterByCriteriaAsync(string userId, ExpenseRequestFilterDto filter);



    }
}
