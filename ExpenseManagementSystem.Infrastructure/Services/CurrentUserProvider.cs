using ExpenseManagementSystem.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace ExpenseManagementSystem.Infrastructure.Services
{
    public class CurrentUserProvider : ICurrentUser
    {
        public bool IsAuthenticated => !string.IsNullOrEmpty(this.UserId);
        public string? UserId { get; }
        public string? Username { get; }


        public CurrentUserProvider(IHttpContextAccessor httpContextAccessor)
        {
            ArgumentNullException.ThrowIfNull(httpContextAccessor);
            ArgumentNullException.ThrowIfNull(httpContextAccessor.HttpContext);

            var claimsPrincipal = httpContextAccessor.HttpContext.User;
            this.UserId = claimsPrincipal.FindFirstValue(ClaimTypes.NameIdentifier);
            this.Username = claimsPrincipal.FindFirstValue(ClaimTypes.Name);
        }

       
    }
}


