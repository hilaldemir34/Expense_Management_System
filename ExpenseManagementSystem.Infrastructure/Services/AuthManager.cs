using ExpenseManagementSystem.Application.Features.Auths;
using ExpenseManagementSystem.Application.Interfaces;
using ExpenseManagementSystem.Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity;

namespace ExpenseManagementSystem.Infrastructure.Services
{
    public class AuthManager : IAuthService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ITokenGenerator _tokenGenerator;

        public AuthManager(UserManager<ApplicationUser> userManager, ITokenGenerator tokenGenerator)
        {
            _userManager = userManager;
            _tokenGenerator = tokenGenerator;
        }

        public async Task<string> LoginAsync(string email, string password)
        {
           var user=await _userManager.FindByEmailAsync(email);
            if (user == null)
            {
                throw new Exception("User not found");
            }
            var result = await _userManager.CheckPasswordAsync(user, password);
            if (result)
            {
                var roles = await _userManager.GetRolesAsync(user);
                return _tokenGenerator.GenerateAccessToken(user, GetFormattedRoles(roles));
            }
            throw new Exception("Invalid password");
        }
        
        public async Task<string> RegisterAsync(string email, string password,string nameSurname)
        {
            var user = new ApplicationUser
            {
                Id = Guid.NewGuid().ToString(),
                UserName = email,
                Email = email,
                Iban="",
                NameSurname = nameSurname
            };
            var result = await _userManager.CreateAsync(user, password);

            if (result.Succeeded)
            {
                var roles = await _userManager.GetRolesAsync(user);
                return _tokenGenerator.GenerateAccessToken(user, GetFormattedRoles(roles));

            }
            throw new Exception(result.Errors.First().Description);
        }
        private string GetFormattedRoles(IList<string> roles)
        {
            if (roles.Count == 0)
            {
                return string.Empty;
            }
            return string.Join(", ", roles);
        }
    }
}
