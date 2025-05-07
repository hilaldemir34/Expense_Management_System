using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseManagementSystem.Application.Features.Reports.DTOs
{
    public class WeeklyPersonnelExpensesReportDto
    {
        public string UserId { get; set; }
        public string UserName { get; set; }
        public int Year { get; set; }
        public int Week { get; set; }
        public decimal TotalExpenses { get; set; }
        public decimal TotalAmount { get; set; }

    }
}
