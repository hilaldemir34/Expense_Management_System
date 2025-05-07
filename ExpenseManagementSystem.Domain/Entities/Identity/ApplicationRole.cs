using ExpenseManagementSystem.Domain.BaseEntity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseManagementSystem.Domain.Entities.Identity
{
    public class ApplicationRole : IdentityRole<String>,IAuditableEntity,ISoftDeletable
    {
      public const string Admin = "Administrator";
        public const string Personnel = "Personnel";

        public DateTime CreatedAtUtc { get ; set; }
        public DateTime? UpdatedAtUtc { get; set; }
        public DateTime? DeletedAtUtc { get; set; }
    }
}
