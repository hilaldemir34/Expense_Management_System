using ExpenseManagementSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseManagementSystem.Application.Repositories
{
    public interface IPaymentRepository
    {
        Task<Payment> GetByIdAsync(int id);
        Task<IEnumerable<Payment>> GetAllAsync();
        Task<IEnumerable<Payment>> FilterByRequestAsync(int expenseRequestId);
        Task AddAsync(Payment entity);
        void Delete(Payment entity);
    }
}
