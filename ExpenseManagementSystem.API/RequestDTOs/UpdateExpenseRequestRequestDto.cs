using ExpenseManagementSystem.Domain.Enums;

namespace ExpenseManagementSystem.API.RequestDTOs
{

    public class UpdateExpenseRequestRequestDto
    {

        public ApprovalStatus Status { get; set; }
        public string RejectionReason { get; set; } = "";
    }
}