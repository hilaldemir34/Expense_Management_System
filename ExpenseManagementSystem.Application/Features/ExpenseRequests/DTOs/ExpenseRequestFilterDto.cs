using ExpenseManagementSystem.Domain.Enums;

namespace ExpenseManagementSystem.Application.Features.ExpenseRequests.DTOs
{
    public class ExpenseRequestFilterDto
    {
        public ApprovalStatus? Status { get; set; }

        public int? CategoryId { get; set; }
        public decimal? MinAmount { get; set; }
        public decimal? MaxAmount { get; set; }
    }
}
