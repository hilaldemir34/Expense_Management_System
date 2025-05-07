using ExpenseManagementSystem.Application.Features.ExpenseCategories;
using ExpenseManagementSystem.Application.Features.ExpenseCategories.DTOs;
using ExpenseManagementSystem.Application.Features.ExpenseDocuments;
using ExpenseManagementSystem.Application.Features.ExpenseDocuments.DTOs;
using ExpenseManagementSystem.Application.Features.ExpenseRequests;
using ExpenseManagementSystem.Application.Features.ExpenseRequests.DTOs;
using ExpenseManagementSystem.Application.Features.Expenses;
using ExpenseManagementSystem.Application.Features.Payments;
using ExpenseManagementSystem.Application.Features.Reports;
using ExpenseManagementSystem.Application.Interfaces;
using ExpenseManagementSystem.Application.Managers;
using ExpenseManagementSystem.Infrastructure.Channels;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;


namespace ExpenseManagementSystem.Application
{
    public static class DependencyInjection
    {
        public static void AddApplication(this IServiceCollection services)
        {
            services.AddValidatorsFromAssembly(
            Assembly.GetExecutingAssembly(),
            lifetime: ServiceLifetime.Scoped,
            includeInternalTypes: true);
            services.AddScoped<IExpenseOrchestrationService, ExpenseOrchestrationManager>();
            services.AddScoped<IExpenseService, ExpenseManager>();
            services.AddScoped<ExpenseRequestManager>();
            services.AddScoped<IExpenseRequestService, ExpenseRequestValidationManagerDecator>(sp => {
                var expenseRequestService = sp.GetRequiredService<ExpenseRequestManager>();
                var createExpenseRequestValidator = sp.GetRequiredService<IValidator<CreateExpenseRequestDto>>();
                var updateExpenseRequestValidator = sp.GetRequiredService<IValidator<UpdateExpenseRequestDto>>();
                var expenseRequestFilterValidator = sp.GetRequiredService<IValidator<ExpenseRequestFilterDto>>();
                var rejectionResponseValidator = sp.GetRequiredService<IValidator<RejectionResponseDto>>();
                return new ExpenseRequestValidationManagerDecator(expenseRequestService,
                    createExpenseRequestValidator, 
                    updateExpenseRequestValidator, 
                    expenseRequestFilterValidator, 
                    rejectionResponseValidator);

            });
            services.AddScoped<ExpenseDocumentManager>();
            services.AddScoped<IExpenseDocumentService, ExpenseDocumentValidationManagerDecator>(sp => {
                var expenseDocumentService = sp.GetRequiredService<ExpenseDocumentManager>();
                var createExpenseDocumentValidator = sp.GetRequiredService<IValidator<CreateExpenseRequestWithFilesDto>>();

                return new ExpenseDocumentValidationManagerDecator(expenseDocumentService,
                    createExpenseDocumentValidator);
            });



            services.AddScoped<IReportingService, ReportingManager>();
            services.AddScoped<IPaymentService, PaymentManager>();
            services.AddSingleton<IEftChannel, EftChannel>();
            services.AddScoped<IExpenseDocumentService, ExpenseDocumentManager>();


            services.AddScoped<ExpenseCategoryManager>();
            services.AddScoped<IExpenseCategoryService, ExpenseCategoryValidationManagerDecator>(sp => {
                var expenseCategoryService = sp.GetRequiredService<ExpenseCategoryManager>();
                var createExpenseCategoryValidator = sp.GetRequiredService<IValidator<CreateExpenseCategoryDto>>();
                var updateExpenseCategoryValidator = sp.GetRequiredService<IValidator<UpdateExpenseCategoryDto>>();
                return new ExpenseCategoryValidationManagerDecator(expenseCategoryService, createExpenseCategoryValidator, updateExpenseCategoryValidator);
            });
        }

    }
}
