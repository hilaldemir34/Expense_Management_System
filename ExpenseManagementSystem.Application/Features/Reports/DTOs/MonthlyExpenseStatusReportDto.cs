namespace ExpenseManagementSystem.Application.Features.Reports.DTOs
{
    public class MonthlyExpenseStatusReportDto
    {
        public int Year { get; set; }
        public int Month { get; set; }
        public int ApprovedCount { get; set; }
        public decimal ApprovedTotalAmount { get; set; }
        public int RejectedCount { get; set; }
        public decimal RejectedTotalAmount { get; set; }

    }
}
