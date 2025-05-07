using ExpenseManagementSystem.Application.Features.Expenses.DTOs;
using ExpenseManagementSystem.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseManagementSystem.Application.Features.ExpenseRequests.DTOs
{
    public class CreateExpenseRequestDto
    {
        public List<CreateExpenseDto> Expenses { get; set; } = new List<CreateExpenseDto>();
    }
  
}
