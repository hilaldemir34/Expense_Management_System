using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseManagementSystem.Application.Features.Payments.DTOs
{
    public class PaymentDto
    {
        public int Id { get; set; }
        public int ExpenseRequestId { get; set; }
        public string SenderUserId { get; set; }
        public string ReceiverUserId { get; set; }
        public decimal Amount { get; set; }
        public DateTime PaidAt { get; set; }
        public string Status { get; set; }
    }
}
