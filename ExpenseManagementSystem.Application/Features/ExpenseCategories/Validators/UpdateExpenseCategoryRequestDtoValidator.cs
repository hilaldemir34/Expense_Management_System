using ExpenseManagementSystem.Application.Features.ExpenseCategories.DTOs;
using ExpenseManagementSystem.Application.Repositories;
using FluentValidation;

namespace ExpenseManagementSystem.Application.Validators
{
    public class UpdateExpenseCategoryDtoValidator : AbstractValidator<UpdateExpenseCategoryDto>
    {
        private readonly IExpenseCategoryRepository _repository;

        public UpdateExpenseCategoryDtoValidator(IExpenseCategoryRepository repository)
        {
            _repository = repository;

            RuleFor(x => x.Id)
                .GreaterThan(0)
                    .WithMessage("Geçerli bir kategori Id'si girilmelidir.");

            RuleFor(x => x.CategoryName)
      .NotEmpty()
          .WithMessage("Kategori adı boş olamaz.")
      .Length(3, 100)
          .WithMessage("Kategori adı 3 ile 100 karakter arasında olmalıdır.")
      .Matches("^[a-zA-ZığüşöçİĞÜŞÖÇ0-9 ]+$")
          .WithMessage("Kategori adı sadece harf, rakam ve boşluk içerebilir.")
      .Must((dto, categoryName) => {
          var exists = _repository.ExistsByNameAsync(categoryName).GetAwaiter().GetResult();
          if (!exists) return true;
          var category = _repository.GetDomainByNameAsync(categoryName).GetAwaiter().GetResult();
          return category != null && category.Id == dto.Id;
      })
          .WithMessage("Bu kategori adı zaten mevcut.");

        }

        private async Task<bool> BeUnique(int id, string name, CancellationToken token)
        {
            var exists = await _repository.ExistsByNameAsync(name);
            if (!exists) return true;
            var category = await _repository.GetDomainByNameAsync(name);
            return category != null && category.Id == id;
        }
    }
}
