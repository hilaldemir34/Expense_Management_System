using ExpenseManagementSystem.API.RequestDTOs;
using ExpenseManagementSystem.Application.Features.Users;
using ExpenseManagementSystem.Application.Features.Users.DTOs;
using ExpenseManagementSystem.Domain.Entities.Identity;
using Mapster;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseManagementSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = ApplicationRole.Admin)]
    public class UserController : ControllerBase
    {
        IUserService _userSevice;

        public UserController(IUserService userSevice)
        {
            _userSevice = userSevice;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _userSevice.GetAllUsersAsync();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(string id)
        {
            var user = await _userSevice.GetByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserRequestDto request)
        {
            await _userSevice.CreateAsync(request.Adapt<CreateUserDto>());
            return Created();
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(string id, [FromBody] UpdateUserRequestDto request)
        {
            var user= request.Adapt<UpdateUserDto>();
            user.Id = id;
            await _userSevice.UpdateAsync(user);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(string id)
        {
            await _userSevice.DeleteAsync(id);
            return NoContent();
        }
    }
}
