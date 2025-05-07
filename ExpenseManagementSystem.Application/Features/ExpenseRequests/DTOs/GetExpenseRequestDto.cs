using ExpenseManagementSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseManagementSystem.Application.Features.ExpenseRequests.DTOs
{
    public class GetExpenseRequestDto
    {
        public int Id { get; set; }
        public string Status { get; set; } = "";
        public string RejectionReason { get; set; } = "";
        public DateTime RequestDate { get; set; }
        public UserDto User { get; set; }
        public List<ExpenseDto> Expenses { get; set; } = new List<ExpenseDto>();
        public List<string> Files { get; set; } = new();

    }
    public class ExpenseDto
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public GetExpenseRequestExpenseCategoryDto ExpenseCategory { get; set; }
    }

    public class GetExpenseRequestExpenseCategoryDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public class UserDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Iban { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
    }

}
