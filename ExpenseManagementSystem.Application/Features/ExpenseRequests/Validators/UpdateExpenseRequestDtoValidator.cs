using ExpenseManagementSystem.Application.Features.ExpenseRequests.DTOs;
using FluentValidation;

namespace ExpenseManagementSystem.Application.Features.ExpenseRequests.Validators
{
    public class UpdateExpenseRequestDtoValidator : AbstractValidator<UpdateExpenseRequestDto>
    {
        public UpdateExpenseRequestDtoValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .WithMessage("Id alanı gereklidir.");

            RuleFor(x => x.Status.ToString())
                .NotEmpty()
                .WithMessage("Status Alanı gereklidir.")
                .MaximumLength(500);

        }
    }
}
