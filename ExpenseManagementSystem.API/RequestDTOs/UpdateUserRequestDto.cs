using ExpenseManagementSystem.Domain.Entities.Identity;
using System.ComponentModel.DataAnnotations;

namespace ExpenseManagementSystem.API.RequestDTOs
{
    public class UpdateUserRequestDto
    {
        public string NameSurname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Iban { get; set; }

        [AllowedValues(ApplicationRole.Admin, ApplicationRole.Personnel, ErrorMessage = $"Role sadece {ApplicationRole.Admin} veya {ApplicationRole.Personnel} olabilir.")]
        public string Role { get; set; }
        public string PhoneNumber { get; set; }

    }
}
