using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseManagementSystem.Application.Features.Expenses.DTOs
{
    public class UpdateExpenseDto
    {

        public int Id { get; set; }
        public decimal Amount { get; set; }
        public string Description { get; set; }
    }
}
