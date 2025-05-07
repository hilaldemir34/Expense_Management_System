using ExpenseManagementSystem.Application.Features.ExpenseRequests.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseManagementSystem.Application.Features.ExpenseRequests.Validators
{
    public class RejectExpenseRequestDtoValidator : AbstractValidator<RejectionResponseDto>
    {
        public RejectExpenseRequestDtoValidator()
        {
            RuleFor(x => x.RejectionReason)
                .NotEmpty().WithMessage("Red nedeni boş olamaz.")
                .MinimumLength(5).WithMessage("Red nedeni en az 5 karakter olmalıdır.")
                .MaximumLength(500).WithMessage("Red nedeni en fazla 500 karakter olabilir.");
        }
    }
}
