using ExpenseManagementSystem.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseManagementSystem.Application.Features.ExpenseRequests.DTOs
{
    public class UpdateExpenseRequestDto
    {
        public int Id { get; set; }
        public ApprovalStatus Status { get; set; }
        public string RejectionReason { get; set; } = "";
    }
}
