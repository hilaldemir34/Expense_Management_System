using ExpenseManagementSystem.Application.Features.Auths;
using ExpenseManagementSystem.Application.Features.Payments;
using ExpenseManagementSystem.Application.Features.Users;
using ExpenseManagementSystem.Application.Features.Users.DTOs;
using ExpenseManagementSystem.Application.Interfaces;
using ExpenseManagementSystem.Application.Managers;
using ExpenseManagementSystem.Infrastructure.Channels;
using ExpenseManagementSystem.Infrastructure.Services;
using FluentValidation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace ExpenseManagementSystem.Infrastructure
{
    public static class DependencyInjection
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<ITokenGenerator, JwtTokenGenerator>();
            services.AddScoped<IAuthService, AuthManager>();
            services.AddScoped<ApplicationUserManager>();
            services.AddScoped<IUserService, UserValidationManagerDecator>(sp =>
            {
                var userService = sp.GetRequiredService<ApplicationUserManager>();
                var createUserValidator = sp.GetRequiredService<IValidator<CreateUserDto>>();
                var updateUserValidator = sp.GetRequiredService<IValidator<UpdateUserDto>>();
                return new UserValidationManagerDecator(userService, createUserValidator, updateUserValidator);
            });


            services.AddScoped<ICurrentUser, CurrentUserProvider>();
            
           
        }

    }
}
