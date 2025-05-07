using ExpenseManagementSystem.Application.Features.Users.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseManagementSystem.Application.Features.Users
{
    public interface IUserService
    {
       Task CreateAsync(CreateUserDto dto);
        Task UpdateAsync(UpdateUserDto dto);
        Task DeleteAsync(string id);
        Task<UserDto> GetByIdAsync(string id);
        Task<IEnumerable<UserDto>> GetAllUsersAsync();


    }
}
