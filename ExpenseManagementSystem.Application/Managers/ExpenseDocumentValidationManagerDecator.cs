using ExpenseManagementSystem.Application.Features.ExpenseDocuments;
using ExpenseManagementSystem.Application.Features.ExpenseDocuments.DTOs;
using ExpenseManagementSystem.Application.Features.ExpenseDocuments.Validator;
using ExpenseManagementSystem.Application.Validators;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseManagementSystem.Application.Managers
{
    public class ExpenseDocumentValidationManagerDecator : IExpenseDocumentService
    {
        private readonly IExpenseDocumentService _expenseDocumentService;
        private readonly IValidator<CreateExpenseRequestWithFilesDto> _createExpenseRequestWithFilesDtoValidator;

        public ExpenseDocumentValidationManagerDecator(IExpenseDocumentService expenseDocumentService, IValidator<CreateExpenseRequestWithFilesDto> createExpenseRequestWithFilesDtoValidator)
        {
            _expenseDocumentService = expenseDocumentService;
            _createExpenseRequestWithFilesDtoValidator = createExpenseRequestWithFilesDtoValidator;
        }

        public async Task<IEnumerable<string>> GetFileUrlsAsync(int expenseRequestId)
        {
            return await _expenseDocumentService.GetFileUrlsAsync(expenseRequestId);
        }

        public async Task UploadAsync(int expenseRequestId, IFormFileCollection files)
        {
            await _createExpenseRequestWithFilesDtoValidator.ValidateAndThrowAsync(
                new CreateExpenseRequestWithFilesDto
                {
                    Files = files
                });
            await _expenseDocumentService.UploadAsync(expenseRequestId, files);
        }
    }
}
