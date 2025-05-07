using ExpenseManagementSystem.Application.Features.Payments;
using ExpenseManagementSystem.Application.Repositories;
using ExpenseManagementSystem.Domain.Entities;
using ExpenseManagementSystem.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseManagementSystem.Persistence.Repositories
{
    public class PaymentRepository : IPaymentRepository
    {
        private readonly ApplicationDbContext _context;

        public PaymentRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Payment entity)
        {
            await _context.Payments.AddAsync(entity);
        }

        public void Delete(Payment entity)
        {
            _context.Payments.Remove(entity);
        }

        public async Task<IEnumerable<Payment>> GetAllAsync()
        {
            return await _context.Payments
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Payment> GetByIdAsync(int id)
        {
            return await _context.Payments
                .Include(p => p.ExpenseRequest)
                .Include(p => p.SenderUser)
                .Include(p => p.ReceiverUser)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<Payment>> FilterByRequestAsync(int expenseRequestId)
        {
            return await _context.Payments
                .Where(p => p.ExpenseRequestId == expenseRequestId)
                .AsNoTracking()
                .ToListAsync();
        }
    }
}

