using ExpenseManagementSystem.Application.Features.ExpenseCategories.DTOs;

namespace ExpenseManagementSystem.Application.Features.ExpenseCategories
{
    public interface IExpenseCategoryService
    {

        Task<ExpenseCategoryDto?> GetByIdAsync(int id);
        Task<ExpenseCategoryDto> CreateAsync(CreateExpenseCategoryDto CreateExpenseCategoryDto);
        Task UpdateAsync(UpdateExpenseCategoryDto updateExpenseCategoryDto);
        Task DeleteAsync(int id);
        Task<IEnumerable<ExpenseCategoryDto>> GetAllAsync();


    }
}
