using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseManagementSystem.Application.Features.Payments.DTOs
{
    public class EftRequestDto
    {
        public int ExpenseRequestId { get; set; }
        public string FromIban { get; set; } = null!;
        public string ToIban { get; set; } = null!;
        public decimal Amount { get; set; }
        public string Message { get; set; } = "Ödeme Tamamlandı!";
    }
}
