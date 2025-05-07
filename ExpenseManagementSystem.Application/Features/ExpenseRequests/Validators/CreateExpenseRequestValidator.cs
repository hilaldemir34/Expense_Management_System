using ExpenseManagementSystem.Application.Features.ExpenseRequests.DTOs;
using ExpenseManagementSystem.Application.Features.Expenses;
using ExpenseManagementSystem.Application.Features.Expenses.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseManagementSystem.Application.Features.ExpenseRequests.Validators
{
    public class CreateExpenseRequestDtoValidator : AbstractValidator<CreateExpenseRequestDto>
    {
        public CreateExpenseRequestDtoValidator()
        {
            RuleFor(x => x.Expenses)
                .NotEmpty().WithMessage("En az bir gider eklemelisiniz.")
                .Must(x => x.Count > 0).WithMessage("En az bir gider eklemelisiniz.");
            RuleForEach(x => x.Expenses)
                .SetValidator(new CreateExpenseDtoValidator());
        }
    }
}  

