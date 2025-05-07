using ExpenseManagementSystem.Application.Features.ExpenseCategories.DTOs;
using ExpenseManagementSystem.Application.Features.Payments;
using ExpenseManagementSystem.Application.Features.Payments.DTOs;
using ExpenseManagementSystem.Application.Repositories;
using ExpenseManagementSystem.Domain.Entities;
using ExpenseManagementSystem.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseManagementSystem.Application.Managers
{
    public class PaymentManager : IPaymentService
    {
        private readonly IPaymentRepository _paymentRepository;

        public PaymentManager(IPaymentRepository paymentRepository)
        {
            _paymentRepository = paymentRepository;
        }

        public async Task<PaymentDto> CreateAsync(CreatePaymentDto dto)
        {
            var payment = new Payment
            {
                Amount = dto.Amount,
                PaidAt = DateTime.UtcNow, 
                ExpenseRequestId = dto.ExpenseRequestId,
                SenderUserId = dto.SenderUserId,
                ReceiverUserId = dto.ReceiverUserId
            };

            await _paymentRepository.AddAsync(payment);

            var paymentDto = new PaymentDto
            {
                Id = payment.Id, 
                Amount = payment.Amount,
                PaidAt = payment.PaidAt,
                ExpenseRequestId = payment.ExpenseRequestId,
                SenderUserId = payment.SenderUserId,
                ReceiverUserId = payment.ReceiverUserId,
                Status=payment.Status
            };

            return paymentDto;
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<PaymentDto>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<PaymentDto> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<PaymentDto>> GetByRequestIdAsync(int expenseRequestId)
        {
            throw new NotImplementedException();
        }
    }
}
