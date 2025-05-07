using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseManagementSystem.Application.Features.ExpenseRequests.DTOs
{
    public class RejectExpenseRequestDto
    {
        public string RejectionReason { get; set; } = string.Empty;
    }
}
