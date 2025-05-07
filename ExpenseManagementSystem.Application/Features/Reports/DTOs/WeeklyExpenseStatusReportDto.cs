using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseManagementSystem.Application.Features.Reports.DTOs
{
    public class WeeklyExpenseStatusReportDto
    {
        public int Year { get; set; }
        public int Week { get; set; }
        public int ApprovedCount { get; set; }
        public decimal ApprovedTotalAmount { get; set; }
        public int RejectedCount { get; set; }
        public decimal RejectedTotalAmount { get; set; }
    }

}
