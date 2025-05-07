using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseManagementSystem.Application.Features.ExpenseRequests.DTOs
{
    public class RejectionResponseDto
    {
        public int ExpenseRequestId { get; set; }
        public string RejectionReason { get; set; } = null!;
        public string Message { get; set; } 
    }
}
