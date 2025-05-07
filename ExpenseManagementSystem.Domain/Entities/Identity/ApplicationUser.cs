using ExpenseManagementSystem.Domain.BaseEntity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseManagementSystem.Domain.Entities.Identity
{
    public class ApplicationUser : IdentityUser<String>, IAuditableEntity, ISoftDeletable
    {
        public String NameSurname { get; set; }
        public string Iban { get; set; }
        public ICollection<Expense> Expenses { get; set; }
        public ICollection<Payment> SentPayments { get; set; }
        public ICollection<Payment> ReceivedPayments { get; set; }
        public ICollection<ExpenseRequest> ExpenseRequests { get; set; }
        public DateTime CreatedAtUtc { get; set; }
        public DateTime? UpdatedAtUtc { get; set; }
        public DateTime? DeletedAtUtc { get; set; }

    }
}
