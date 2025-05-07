using ExpenseManagementSystem.Application.Features.ExpenseRequests;
using ExpenseManagementSystem.Application.Features.ExpenseRequests.DTOs;
using ExpenseManagementSystem.Application.Features.Payments.DTOs;
using ExpenseManagementSystem.Domain.Entities;
using ExpenseManagementSystem.Domain.Enums;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseManagementSystem.Application.Managers
{
    public class ExpenseRequestValidationManagerDecator : IExpenseRequestService
    {
        private readonly IExpenseRequestService _expenseRequestService;
        private readonly IValidator<CreateExpenseRequestDto> _createExpenseRequestValidator;
        private readonly IValidator<UpdateExpenseRequestDto> _updateExpenseRequestValidator;
        private readonly IValidator<ExpenseRequestFilterDto> _expenseRequestFilterValidator;
        private readonly IValidator<RejectionResponseDto> _rejectionResponseValidator;

        public ExpenseRequestValidationManagerDecator(IExpenseRequestService expenseRequestService, IValidator<CreateExpenseRequestDto> createExpenseRequestValidator, IValidator<UpdateExpenseRequestDto> updateExpenseRequestValidator, IValidator<ExpenseRequestFilterDto> expenseRequestFilterValidator, IValidator<RejectionResponseDto> rejectionResponseValidator)
        {
            _expenseRequestService = expenseRequestService;
            _createExpenseRequestValidator = createExpenseRequestValidator;
            _updateExpenseRequestValidator = updateExpenseRequestValidator;
            _expenseRequestFilterValidator = expenseRequestFilterValidator;
            _rejectionResponseValidator = rejectionResponseValidator;
        }

        public async Task<EftRequestDto> ApproveAsync(int id)
        {
           return await _expenseRequestService.ApproveAsync(id);
        }

        public async Task<ExpenseRequest> CreateAsync(CreateExpenseRequestDto createExpenseRequestDto)
        {
            await _createExpenseRequestValidator.ValidateAndThrowAsync(createExpenseRequestDto);
            return await _expenseRequestService.CreateAsync(createExpenseRequestDto);
        }

        public async Task DeleteAsync(int id)
        {
            await _expenseRequestService.DeleteAsync(id);
        }

        public async Task<IEnumerable<GetExpenseRequestDto>> FilterMyRequestsAsync(ExpenseRequestFilterDto filter)
        {
            await _expenseRequestFilterValidator.ValidateAndThrowAsync(filter);
            return await _expenseRequestService.FilterMyRequestsAsync(filter);
        }

        public async Task<IEnumerable<GetExpenseRequestDto>> GetAllExpenseRequestsAsync()
        {
            return await _expenseRequestService.GetAllExpenseRequestsAsync();
        }

        public async Task<IEnumerable<ExpenseRequest>> GetApprovedExpenseRequestsAsync()
        {
            return await _expenseRequestService.GetApprovedExpenseRequestsAsync();
        }

        public async Task<GetExpenseRequestDto?> GetByIdAsync(int id)
        {
          return  await _expenseRequestService.GetByIdAsync(id);
        }

        public async Task<List<GetExpenseRequestDto>> GetExpensesByUserIdAsync()
        {
            return await _expenseRequestService.GetExpensesByUserIdAsync();
        }

        public async Task<IEnumerable<ExpenseRequest>> GetPendingExpenseRequestsAsync()
        {
            return await _expenseRequestService.GetPendingExpenseRequestsAsync();
        }

        public async Task<IEnumerable<ExpenseRequest>> GetRejectedExpenseRequestsAsync()
        {
            return await _expenseRequestService.GetRejectedExpenseRequestsAsync();
        }

        public async Task<RejectionResponseDto> RejectAsync(int id, string rejectionReason)
        {
            await _rejectionResponseValidator.ValidateAndThrowAsync(new RejectionResponseDto { RejectionReason = rejectionReason });
            return await _expenseRequestService.RejectAsync(id, rejectionReason);
        }


        public async Task UpdateAsync(UpdateExpenseRequestDto dto)
        {
           await _updateExpenseRequestValidator.ValidateAndThrowAsync(dto);
            await _expenseRequestService.UpdateAsync(dto);
        }
    }
}
