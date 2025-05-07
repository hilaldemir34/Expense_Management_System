using ExpenseManagementSystem.Application.Features.Users;
using ExpenseManagementSystem.Application.Features.Users.DTOs;
using ExpenseManagementSystem.Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity;

namespace ExpenseManagementSystem.Infrastructure.Services
{
    public class ApplicationUserManager : IUserService
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public ApplicationUserManager(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task CreateAsync(CreateUserDto dto)
        {
            var user = new ApplicationUser
            {
                Id = Guid.NewGuid().ToString(),
                UserName = dto.Email,
                Email = dto.Email,
                Iban = dto.Iban,
                NameSurname = dto.NameSurname,
                PhoneNumber = dto.PhoneNumber,
             


            };
            await _userManager.CreateAsync(user, dto.Password);
            await _userManager.AddToRoleAsync(user, ApplicationRole.Personnel);
        }

        public async Task DeleteAsync(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user != null)
            {
                await _userManager.DeleteAsync(user);
            }
        }

        public async Task<IEnumerable<UserDto>> GetAllUsersAsync()
        {
            var users = _userManager.Users.ToList();
            var userDtos = new List<UserDto>();

            foreach (var user in users)
            {
                var roles = await _userManager.GetRolesAsync(user);
                userDtos.Add(new UserDto
                {
                    UserId = user.Id,
                    NameSurname = user.NameSurname,
                    Email = user.Email,
                    Iban = user.Iban,
                    Role = roles.FirstOrDefault()
                });
            }

            return userDtos;
        }

        public async Task<UserDto> GetByIdAsync(string id)
        {
            var user = _userManager.Users.FirstOrDefault(u => u.Id == id);
            if (user == null)
            {
                return null;
            }

            var roles = await _userManager.GetRolesAsync(user);

            var userDto = new UserDto
            {
                UserId=user.Id,
                NameSurname = user.NameSurname,
                Email = user.Email,
                Iban = user.Iban,
                Role = roles.FirstOrDefault()
            };

            return userDto;
        }
        public async Task UpdateAsync(UpdateUserDto dto)
        {
            var user = await _userManager.FindByIdAsync(dto.Id);
            if (user != null)
            {
                user.NameSurname = dto.NameSurname;
                user.Iban = dto.Iban;
                user.Email = dto.Email;
                user.UserName = dto.Email;
                user.PhoneNumber = dto.PhoneNumber;
                var result = await _userManager.UpdateAsync(user);

                if (!result.Succeeded)
                {
                    var errors = string.Join(", ", result.Errors.Select(e => e.Description));
                    throw new FluentValidation.ValidationException($"User update failed: {errors}");
                }

                await _userManager.AddToRoleAsync(user, dto.Role);
            }


        }
    }
}
