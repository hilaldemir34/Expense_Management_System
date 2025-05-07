using ExpenseManagementSystem.Domain.BaseEntity;
using ExpenseManagementSystem.Domain.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseManagementSystem.Domain.Entities
{
    public class Payment:EntityBase
    {
        public decimal Amount { get; set; }
        public DateTime PaidAt { get; set; }
        public string Status { get; set; }
        public int ExpenseRequestId { get; set; }
        public ExpenseRequest ExpenseRequest { get; set; }
        public string SenderUserId { get; set; }
        public ApplicationUser SenderUser { get; set; }
        public string ReceiverUserId { get; set; }
        public ApplicationUser ReceiverUser { get; set; }

    }
}
