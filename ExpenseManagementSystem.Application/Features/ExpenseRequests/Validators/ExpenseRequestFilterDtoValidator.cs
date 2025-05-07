using ExpenseManagementSystem.Application.Features.ExpenseRequests.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseManagementSystem.Application.Features.ExpenseRequests.Validators
{
    public class ExpenseRequestFilterDtoValidator : AbstractValidator<ExpenseRequestFilterDto>
    {
        public ExpenseRequestFilterDtoValidator()
        {
            RuleFor(x => x.MinAmount)
                .GreaterThanOrEqualTo(0).When(x => x.MinAmount.HasValue)
                .WithMessage("Minimum tutar 0'dan küçük olamaz.");

            RuleFor(x => x.MaxAmount)
                .GreaterThanOrEqualTo(0).When(x => x.MaxAmount.HasValue)
                .WithMessage("Maksimum tutar 0'dan küçük olamaz.");

            RuleFor(x => x)
                .Must(x => !x.MinAmount.HasValue || !x.MaxAmount.HasValue || x.MinAmount <= x.MaxAmount)
                .WithMessage("Minimum tutar, maksimum tutardan büyük olamaz.");
        }
    }
}
