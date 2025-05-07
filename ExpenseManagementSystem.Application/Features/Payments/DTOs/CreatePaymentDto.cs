using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseManagementSystem.Application.Features.Payments.DTOs
{
    public class CreatePaymentDto
    {
        public int ExpenseRequestId { get; set; }
        public string SenderUserId { get; set; }
        public string ReceiverUserId { get; set; }
        public decimal Amount { get; set; }
        public string Status { get; set; }
    }
}
