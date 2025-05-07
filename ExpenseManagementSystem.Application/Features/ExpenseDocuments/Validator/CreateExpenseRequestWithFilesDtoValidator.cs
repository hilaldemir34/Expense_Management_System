using ExpenseManagementSystem.Application.Features.ExpenseDocuments.DTOs;
using ExpenseManagementSystem.Application.Features.ExpenseRequests.Validators;
using ExpenseManagementSystem.Application.Features.Expenses;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseManagementSystem.Application.Features.ExpenseDocuments.Validator
{
    public class CreateExpenseRequestWithFilesDtoValidator : AbstractValidator<CreateExpenseRequestWithFilesDto>
    {
        private readonly string[] _permittedExtensions = { ".jpg", ".jpeg", ".png", ".pdf" };
        private const long _fileSizeLimit = 5 * 1024 * 1024; // 5 MB

        public CreateExpenseRequestWithFilesDtoValidator()
        {
            // At least one expense entry
            RuleFor(x => x.Expenses)
                .NotNull()
                    .WithMessage("At least one expense row must be provided.")
                .Must(list => list.Any())
                    .WithMessage("At least one expense row must be provided.");

            // Validate each expense DTO
            RuleForEach(x => x.Expenses)
                .SetValidator(new CreateExpenseDtoValidator());

            // At least one file
            RuleFor(x => x.Files)
                .NotNull()
                    .WithMessage("At least one file must be uploaded.")
                .Must(files => files.Count > 0)
                    .WithMessage("At least one file must be uploaded.");

            // File-specific rules
            RuleForEach(x => x.Files)
                .Must(f => f.Length > 0)
                    .WithMessage(f => $"{f.Files} cannot be an empty file.")
                .Must(f => f.Length <= _fileSizeLimit)
                    .WithMessage(f => $"{f.Files} must be at most {_fileSizeLimit / (1024 * 1024)} MB.")
                .Must(f => _permittedExtensions.Contains(Path.GetExtension(f.FileName).ToLower()))
                    .WithMessage(f => $"{f.Files} extension is not permitted. Allowed: {string.Join(", ", _permittedExtensions)}.");
        }
    }
}
