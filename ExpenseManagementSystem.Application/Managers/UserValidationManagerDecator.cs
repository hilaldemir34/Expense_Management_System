using ExpenseManagementSystem.Application.Features.Users;
using ExpenseManagementSystem.Application.Features.Users.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseManagementSystem.Application.Managers
{
    public class UserValidationManagerDecator : IUserService
    {
        private readonly IUserService _userService;
        private IValidator<CreateUserDto> _createUserValidator;
        private IValidator<UpdateUserDto> _updateUserValidator;
        public UserValidationManagerDecator(IUserService userService,
            IValidator<CreateUserDto> createUserValidator,
            IValidator<UpdateUserDto> updateUserValidator)
        {
            _userService = userService;
            _createUserValidator = createUserValidator;
            _updateUserValidator = updateUserValidator;
        }
        public async Task CreateAsync(CreateUserDto dto)
        {
            await _createUserValidator.ValidateAndThrowAsync(dto);
            await _userService.CreateAsync(dto);
        }

        public async Task DeleteAsync(string id)
        {
            await _userService.DeleteAsync(id);
        }

        public async Task<IEnumerable<UserDto>> GetAllUsersAsync()
        {
            return await _userService.GetAllUsersAsync();
        }

        public async Task<UserDto> GetByIdAsync(string id)
        {
            return await _userService.GetByIdAsync(id);
        }

        public async Task UpdateAsync(UpdateUserDto dto)
        {
            await _updateUserValidator.ValidateAndThrowAsync(dto);
            await _userService.UpdateAsync(dto);
        }
    }
}
