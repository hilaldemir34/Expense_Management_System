using ExpenseManagementSystem.Application.Features.Expenses.DTOs;
using Microsoft.AspNetCore.Http;

namespace ExpenseManagementSystem.Application.Features.ExpenseDocuments.DTOs
{
    public class CreateExpenseRequestWithFilesDto
    {
        public List<CreateExpenseDto> Expenses { get; set; }
        public IFormFileCollection Files { get; set; }
    }

}
