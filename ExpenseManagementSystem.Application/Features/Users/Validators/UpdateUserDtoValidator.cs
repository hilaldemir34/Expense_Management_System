using ExpenseManagementSystem.Application.Features.Users.DTOs;
using ExpenseManagementSystem.Domain.Entities.Identity;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ExpenseManagementSystem.Application.Features.Users.Validators
{
    public class UpdateUserDtoValidator : AbstractValidator<UpdateUserDto>
    {
        private static readonly Regex IbanRegex = new Regex(@"^TR\d{2}\d{5}\d{16}$", RegexOptions.Compiled);
        private static readonly string[] ValidRoles = new[]
        {
            ApplicationRole.Admin,
            ApplicationRole.Personnel
        };
        
        public UpdateUserDtoValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Kullanıcı Id boş olamaz.");

            RuleFor(x => x.NameSurname)
                .NotEmpty().WithMessage("Ad Soyad boş olamaz.")
                .MaximumLength(200).WithMessage("Ad Soyad en fazla 200 karakter olabilir.");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email boş olamaz.")
                .EmailAddress().WithMessage("Geçerli bir email adresi giriniz.");

            RuleFor(x => x.Iban)
                .NotEmpty().WithMessage("IBAN boş olamaz.")
                .Must(iban => IbanRegex.IsMatch(iban))
                    .WithMessage("Geçerli bir TR IBAN giriniz (ör. TR12...).");

            When(x => !string.IsNullOrEmpty(x.Password), () =>
            {
                RuleFor(x => x.Password)
                    .MinimumLength(6).WithMessage("Şifre en az 6 karakter olmalıdır.")
                    .MaximumLength(100).WithMessage("Şifre en fazla 100 karakter olabilir.");
            });

            RuleFor(x => x.Role)
                .NotEmpty().WithMessage("Rol boş olamaz.")
                .Must(r => ValidRoles.Contains(r))
                    .WithMessage($"Rol yalnızca şunlardan biri olabilir: {string.Join(", ", ValidRoles)}.");
        }
    }
}
