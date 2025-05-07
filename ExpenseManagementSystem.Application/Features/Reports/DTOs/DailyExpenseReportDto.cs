using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseManagementSystem.Application.Features.Reports.DTOs
{
    public class DailyExpenseReportDto
    {
        public DateTime ExpenseDate { get; set; }
        public decimal TotalAmount { get; set; }
    }

}
