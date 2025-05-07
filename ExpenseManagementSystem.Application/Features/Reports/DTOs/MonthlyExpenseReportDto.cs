using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseManagementSystem.Application.Features.Reports.DTOs
{
    public class MonthlyExpenseReportDto
    {
        public int Year { get; set; }
        public int Month { get; set; }
        public int TotalExpenses { get; set; }
        public decimal TotalAmount { get; set; }
    }
}
