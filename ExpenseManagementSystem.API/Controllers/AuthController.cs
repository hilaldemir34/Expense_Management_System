using ExpenseManagementSystem.API.RequestDTOs;
using ExpenseManagementSystem.Application.Features.Auths;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseManagementSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthsController : ControllerBase
    {
        private readonly IAuthService _authService;
        public AuthsController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)] 
        [ProducesResponseType(StatusCodes.Status400BadRequest)] 
        [ProducesResponseType(StatusCodes.Status401Unauthorized)] 
        public async Task<IActionResult> Login(LoginRequestDto loginRequestDto)
        {
            var result = await _authService.LoginAsync(loginRequestDto.Email, loginRequestDto.Password);
            return Ok(result);
        }

    }

}
