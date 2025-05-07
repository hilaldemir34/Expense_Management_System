using ExpenseManagementSystem.Domain.Enums;

namespace ExpenseManagementSystem.API.RequestDTOs
{
    public class CreateExpenseRequestRequestDto
    {
        public List<CreateExpenseDto> Expenses { get; set; } = new List<CreateExpenseDto>();
    }
    public class CreateExpenseDto
    {
        public int CategoryId { get; set; }
        public decimal Amount { get; set; }
        public string Description { get; set; }
    }
}