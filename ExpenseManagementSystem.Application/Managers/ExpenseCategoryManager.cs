using ExpenseManagementSystem.Application.Features.ExpenseCategories;
using ExpenseManagementSystem.Application.Features.ExpenseCategories.DTOs;
using ExpenseManagementSystem.Application.Repositories;
using ExpenseManagementSystem.Domain.Entities;
using ExpenseManagementSystem.Domain.Interfaces;

namespace ExpenseManagementSystem.Application.Managers
{
    public class ExpenseCategoryManager : IExpenseCategoryService
    {
        private readonly IExpenseCategoryRepository _expenseCategoryRepository;
        private readonly IUnitOfWork _unitOfWork;
        public ExpenseCategoryManager(IExpenseCategoryRepository expenseCategoryRepository, IUnitOfWork unitOfWork)
        {
            _expenseCategoryRepository = expenseCategoryRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<ExpenseCategoryDto> CreateAsync(CreateExpenseCategoryDto createExpenseCategoryDto)
        {
            var expenseCategory = new ExpenseCategory
            {
                Name = createExpenseCategoryDto.ExpenseCategoryName
            };
            await _expenseCategoryRepository.AddAsync(expenseCategory);
            await _unitOfWork.SaveChangesAsync();
            return new ExpenseCategoryDto
            {
                Id = expenseCategory.Id,
                Name = expenseCategory.Name
            };
        }

        public async Task DeleteAsync(int id)
        {
            var expenseCategory = await _expenseCategoryRepository.GetDomainByIdAsync(id);
            if (expenseCategory != null)
            {
                _expenseCategoryRepository.Delete(expenseCategory);
                await _unitOfWork.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<ExpenseCategoryDto>> GetAllAsync()
        {
            var expenseCategories = await _expenseCategoryRepository.GetAllAsync();
            return expenseCategories.Select(ec => new ExpenseCategoryDto
            {
                Id = ec.Id,
                Name = ec.Name
            }).ToList();
        }

        public async Task<ExpenseCategoryDto?> GetByIdAsync(int id)
        {
            return await _expenseCategoryRepository.GetByIdAsync(id);
        }

        public async Task UpdateAsync(UpdateExpenseCategoryDto dto)
        {
            var entity = await _expenseCategoryRepository.GetDomainByIdAsync(dto.Id);
            entity.Name = dto.CategoryName;
            _expenseCategoryRepository.Update(entity);
            await _unitOfWork.SaveChangesAsync();
        }

    }
}
