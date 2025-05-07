using ExpenseManagementSystem.Application.Features.Expenses.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseManagementSystem.Application.Features.Expenses
{
    public class CreateExpenseDtoValidator:AbstractValidator<CreateExpenseDto>

    {
        public CreateExpenseDtoValidator()
        {
            RuleFor(x => x.Amount)
                .NotEmpty().WithMessage("Amount is required.")
                .GreaterThan(0).WithMessage("Amount must be greater than 0.");
            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("Description is required.")
                .MaximumLength(500).WithMessage("Description cannot exceed 500 characters.");
            RuleFor(x => x.CategoryId)
                .NotEmpty().WithMessage("Category ID is required.");
        }
    }
}
