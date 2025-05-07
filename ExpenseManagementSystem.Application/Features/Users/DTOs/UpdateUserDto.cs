using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseManagementSystem.Application.Features.Users.DTOs
{
    public class UpdateUserDto
    {
        public string Id { get; set; }
        public string NameSurname { get; set; }
        public string Email { get; set; }
        public string Iban { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public string PhoneNumber { get; set; }
    }
}
