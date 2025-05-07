using ExpenseManagementSystem.Application.Repositories;
using ExpenseManagementSystem.Domain.Entities.Identity;
using ExpenseManagementSystem.Domain.Interfaces;
using ExpenseManagementSystem.Persistence.Context;
using ExpenseManagementSystem.Persistence.Interceptors.ExpenseManagementSystem.Persistence.Interceptors;
using ExpenseManagementSystem.Persistence.Interceptors;
using ExpenseManagementSystem.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseManagementSystem.Persistence
{
    public static class DependencyInjection
    {
        public static void AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<IAuditableEntityInterceptor>();
            services.AddSingleton<ISoftDeletableEntityInterceptor>();

            services.AddDbContext<ApplicationDbContext>((sp, options) => {

                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));

                options.AddInterceptors(
                    sp.GetRequiredService<IAuditableEntityInterceptor>(),
                    sp.GetRequiredService<ISoftDeletableEntityInterceptor>());
            });

            services.AddScoped<IUnitOfWork>(sp=>sp.GetRequiredService<ApplicationDbContext>());
            services.AddScoped<IExpenseRepository, ExpenseRepository>();
            services.AddScoped<IExpenseRequestRepository, ExpenseRequestRepository>();
            services.AddScoped<IExpenseCategoryRepository, ExpenseCategoryRepository>();
            services.AddScoped<IPaymentRepository, PaymentRepository>();
            services.AddSingleton<IDapperContext, DapperContext>();
            services.AddScoped<IReportingRepository, ReportingRepository>();
            services.AddScoped<IExpenseDocumentRepository, ExpenseDocumentRepository>();



        }
    }
}
