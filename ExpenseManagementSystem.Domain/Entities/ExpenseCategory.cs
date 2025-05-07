using ExpenseManagementSystem.Domain.BaseEntity;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseManagementSystem.Domain.Entities
{
    public class ExpenseCategory : EntityBase
    {
        public string Name { get; set; }
        public ICollection<Expense> Expenses { get; set; }

    }
}
