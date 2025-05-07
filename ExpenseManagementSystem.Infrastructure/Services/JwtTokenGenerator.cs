using ExpenseManagementSystem.Application.Interfaces;
using ExpenseManagementSystem.Domain.Entities.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseManagementSystem.Infrastructure.Services
{
    public class JwtTokenGenerator : ITokenGenerator
    {
        private readonly IConfiguration _configuration;

        public JwtTokenGenerator(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GenerateAccessToken(ApplicationUser applicationUser,string role)
        {

            SymmetricSecurityKey securityKey = new(Encoding.UTF8.GetBytes(_configuration["Token:SecurityKey"]));
          
            SigningCredentials signingCredentials = new(securityKey, SecurityAlgorithms.HmacSha256);

            var tokenLifeTime =Convert.ToInt32(_configuration["Token:ExpirationSeconds"]);
            JwtSecurityToken securityToken = CreateSecurityToken(tokenLifeTime, signingCredentials, applicationUser,role);

            JwtSecurityTokenHandler tokenHandler = new();

            return tokenHandler.WriteToken(securityToken);

        }
        private JwtSecurityToken CreateSecurityToken(int lifeTime,SigningCredentials signingCredentials,ApplicationUser user,string roles)
        {
            return new(
                audience: _configuration["Token:Audience"],
                issuer: _configuration["Token:Issuer"],
                expires: DateTime.UtcNow.AddSeconds(lifeTime),
                notBefore: DateTime.UtcNow,
                signingCredentials: signingCredentials,
                claims: new List<Claim> {
                    new(ClaimTypes.Name, user.UserName),
                    new(ClaimTypes.Email, user.Email),
                    new(ClaimTypes.NameIdentifier, user.Id),
                    new(ClaimTypes.Role, roles)
                    }
                );
        }
    }
}

