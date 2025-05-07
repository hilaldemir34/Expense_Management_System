using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseManagementSystem.Application.Features.Reports.DTOs
{
    public class ExpenseReportDto
    {
        public int ExpenseRequestId { get; set; }
        public DateTime RequestDate { get; set; }
        public string RequestStatus { get; set; } = null!;
        public string? RequestRejectionReason { get; set; }
        public int ExpenseId { get; set; }
        public decimal ExpenseAmount { get; set; }
        public string ExpenseDescription { get; set; } = null!;
        public DateTime ExpenseCreatedDate { get; set; }
        public string ExpenseCategoryName { get; set; } = null!;
    }
}
