using ExpenseManagementSystem.Domain.BaseEntity;
using ExpenseManagementSystem.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseManagementSystem.Domain.Entities
{
    public class Expense:EntityBase
    {
        public decimal Amount { get; set; }
        public string Description { get; set; } 
        public DateTime CreatedDate { get; set; } 
        public int ExpenseCategoryId { get; set; }
        public ExpenseCategory ExpenseCategory { get; set; }
        public int ExpenseRequestId { get; set; }
        public ExpenseRequest ExpenseRequest { get; set; }
    }
}
