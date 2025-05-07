using ExpenseManagementSystem.API.RequestDTOs;
using ExpenseManagementSystem.Application.Features.ExpenseCategories;
using ExpenseManagementSystem.Application.Features.ExpenseCategories.DTOs;
using ExpenseManagementSystem.Domain.Entities.Identity;
using Mapster;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseManagementSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Policy = "AdminAndPersonnel")]

    public class ExpenseCategoryController : ControllerBase
    {
        private readonly IExpenseCategoryService _expenseCategoryService;
        public ExpenseCategoryController(IExpenseCategoryService expenseCategoryService)
        {
            _expenseCategoryService = expenseCategoryService;
        }


        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<ExpenseCategoryDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllExpenseCategories()
        {
            var expenseCategories = await _expenseCategoryService.GetAllAsync();
            return Ok(expenseCategories);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ExpenseCategoryDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetExpenseCategoryById(int id)
        {
            var expenseCategory = await _expenseCategoryService.GetByIdAsync(id);
            if (expenseCategory == null)
            {
                return NotFound();
            }
            return Ok(expenseCategory);
        }
        [HttpPost]
        [Authorize(Roles = ApplicationRole.Admin)]
        [ProducesResponseType(typeof(ExpenseCategoryDto), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)] 
        public async Task<IActionResult> CreateExpenseCategory([FromBody] CreateExpenseCategoryDto createExpenseCategoryDto)
        {
            if (createExpenseCategoryDto == null)
            {
                return BadRequest("Invalid data.");
            }
            var createdExpenseCategory = await _expenseCategoryService.CreateAsync(createExpenseCategoryDto);
            return CreatedAtAction(nameof(GetExpenseCategoryById), new { id = createdExpenseCategory.Id }, createdExpenseCategory);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = ApplicationRole.Admin)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteExpenseCategory(int id)
        {
            await _expenseCategoryService.DeleteAsync(id);
            return NoContent();
        }

        [HttpPut("{id}")]
        [Authorize(Roles = ApplicationRole.Admin)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)] 
        [ProducesResponseType(StatusCodes.Status404NotFound)] 
        public async Task<IActionResult> UpdateExpenseCategory(int id, [FromBody] UpdateExpenseCategoryRequestDto dto)
        {
            var updateExpenseRequest = dto.Adapt<UpdateExpenseCategoryDto>();
            updateExpenseRequest.Id = id;
            await _expenseCategoryService.UpdateAsync(updateExpenseRequest);
            return NoContent();
        }


    }
}
