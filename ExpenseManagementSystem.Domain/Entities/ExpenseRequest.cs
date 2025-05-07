using ExpenseManagementSystem.Domain.BaseEntity;
using ExpenseManagementSystem.Domain.Entities.Identity;
using ExpenseManagementSystem.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseManagementSystem.Domain.Entities
{
    public class ExpenseRequest:EntityBase
    {
        public ApprovalStatus Status { get; set; }
        public string RejectionReason { get; set; }= "";
        public DateTime RequestDate { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
        public ICollection<Expense> Expenses { get; set; }
        public ICollection<Payment> Payments { get; set; }
        public ICollection<ExpenseDocument> Documents { get; set; }


    }
}
