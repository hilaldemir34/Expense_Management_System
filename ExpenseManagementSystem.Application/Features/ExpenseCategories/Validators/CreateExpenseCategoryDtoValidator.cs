using ExpenseManagementSystem.Application.Features.ExpenseCategories.DTOs;
using ExpenseManagementSystem.Application.Repositories;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseManagementSystem.Application.Validators
{
    public class CreateExpenseCategoryDtoValidator : AbstractValidator<CreateExpenseCategoryDto>
    {
        private readonly IExpenseCategoryRepository _repository;

        public CreateExpenseCategoryDtoValidator(IExpenseCategoryRepository repository)
        {
            _repository = repository;

            RuleFor(x => x.ExpenseCategoryName)
                .NotEmpty()
                    .WithMessage("Kategori adı boş olamaz.")
                .MinimumLength(3)
                    .WithMessage("Kategori adı en az 3 karakter olmalıdır.")
                .MaximumLength(100)
                    .WithMessage("Kategori adı en fazla 100 karakter olabilir.")
                .Matches("^[a-zA-ZığüşöçİĞÜŞÖÇ0-9 ]+$")
                    .WithMessage("Kategori adı sadece harf, rakam ve boşluk içerebilir.")
                .MustAsync(BeUnique)
                    .WithMessage("Bu kategori adı zaten mevcut.");
        }

        private async Task<bool> BeUnique(string name, CancellationToken cancellationToken)
        {
            var exists = await _repository.ExistsByNameAsync(name);
            return !exists;
        }
    }
}
