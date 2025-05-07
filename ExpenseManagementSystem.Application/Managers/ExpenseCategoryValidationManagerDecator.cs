using ExpenseManagementSystem.Application.Features.ExpenseCategories.DTOs;
using ExpenseManagementSystem.Application.Features.ExpenseCategories;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseManagementSystem.Application.Managers
{
    public class ExpenseCategoryValidationManagerDecator : IExpenseCategoryService
    {
        private readonly IExpenseCategoryService _expenseCategoryService;
        private readonly IValidator<CreateExpenseCategoryDto> _createExpenseCategoryValidator;
        private readonly IValidator<UpdateExpenseCategoryDto> _updateExpenseCategoryValidator;

        public ExpenseCategoryValidationManagerDecator(IExpenseCategoryService expenseCategoryService, IValidator<CreateExpenseCategoryDto> createExpenseCategoryValidator, IValidator<UpdateExpenseCategoryDto> updateExpenseCategoryValidator)
        {
            _expenseCategoryService = expenseCategoryService;
            this._createExpenseCategoryValidator = createExpenseCategoryValidator;
            this._updateExpenseCategoryValidator = updateExpenseCategoryValidator;
        }

        public async Task<ExpenseCategoryDto> CreateAsync(CreateExpenseCategoryDto createExpenseCategoryDto)
        {
            await _createExpenseCategoryValidator.ValidateAndThrowAsync(createExpenseCategoryDto);
            return await _expenseCategoryService.CreateAsync(createExpenseCategoryDto);
        }

        public Task DeleteAsync(int id)
        {
            return _expenseCategoryService.DeleteAsync(id);
        }

        public Task<IEnumerable<ExpenseCategoryDto>> GetAllAsync()
        {
            return _expenseCategoryService.GetAllAsync();
        }

        public Task<ExpenseCategoryDto?> GetByIdAsync(int id)
        {
            return _expenseCategoryService.GetByIdAsync(id);
        }

        public async Task UpdateAsync(UpdateExpenseCategoryDto updateExpenseCategoryDto)
        {
            await _updateExpenseCategoryValidator.ValidateAndThrowAsync(updateExpenseCategoryDto);
            await _expenseCategoryService.UpdateAsync(updateExpenseCategoryDto);
        }
    }
}
