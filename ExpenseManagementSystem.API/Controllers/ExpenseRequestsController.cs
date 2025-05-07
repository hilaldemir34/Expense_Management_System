using ExpenseManagementSystem.API.RequestDTOs;
using ExpenseManagementSystem.Application.Features.ExpenseRequests;
using ExpenseManagementSystem.Application.Features.ExpenseRequests.DTOs;
using ExpenseManagementSystem.Application.Features.Expenses;
using ExpenseManagementSystem.Application.Features.Payments.DTOs;
using ExpenseManagementSystem.Application.Interfaces;
using ExpenseManagementSystem.Domain.Entities;
using ExpenseManagementSystem.Domain.Entities.Identity;
using ExpenseManagementSystem.Domain.Interfaces;
using ExpenseManagementSystem.Persistence.Context;
using Mapster;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ExpenseManagementSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExpenseRequestsController : ControllerBase
    {
        private readonly IExpenseRequestService _expenseRequestService;
        private readonly IExpenseOrchestrationService _expenseOrchestrationService;

        public ExpenseRequestsController(IExpenseRequestService expenseRequestService, IExpenseOrchestrationService expenseOrchestrationService)
        {
            _expenseRequestService = expenseRequestService;
            _expenseOrchestrationService = expenseOrchestrationService;
        }


        [HttpGet]
        [Authorize(Roles = ApplicationRole.Admin)]
        [ProducesResponseType(typeof(IEnumerable<GetExpenseRequestDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllExpenseRequests()
        {
            var expenseRequests = await _expenseRequestService.GetAllExpenseRequestsAsync();
            return Ok(expenseRequests);
        }

        [HttpPost]
        [Authorize(Roles = ApplicationRole.Personnel)]
        [ProducesResponseType(StatusCodes.Status200OK)] 
        [ProducesResponseType(StatusCodes.Status400BadRequest)] 
        public async Task<IActionResult> CreateExpenseRequestAsync([FromBody] CreateExpenseRequestRequestDto request)
        {
            await _expenseOrchestrationService.CreateAsync(request.Adapt<CreateExpenseRequestDto>());
            return Ok();
        }

        [HttpGet("{id}")]
        [Authorize(Roles = ApplicationRole.Admin)]
        [ProducesResponseType(typeof(GetExpenseRequestDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)] 
        public async Task<IActionResult> GetById(int id)
        {
            var expenseRequest = await _expenseRequestService.GetByIdAsync(id);

            if (expenseRequest == null) return NotFound();

            return Ok(expenseRequest);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = ApplicationRole.Admin)]
        [ProducesResponseType(StatusCodes.Status200OK)] 
        [ProducesResponseType(StatusCodes.Status400BadRequest)] 
        [ProducesResponseType(StatusCodes.Status404NotFound)] 
        public async Task<IActionResult> UpdateExpenseRequestAsync(int id, [FromBody] UpdateExpenseRequestRequestDto dto)
        {
            var updateExpenseRequest = dto.Adapt<UpdateExpenseRequestDto>();
            updateExpenseRequest.Id = id;
            await _expenseRequestService.UpdateAsync(updateExpenseRequest);
            return Ok($"{id}. masraf isteği güncellenmiştir.");
        }

        [HttpPost("approve/{id}")]
        [Authorize(Roles = ApplicationRole.Admin)]
        [ProducesResponseType(typeof(EftRequestDto), StatusCodes.Status200OK)] 
        [ProducesResponseType(StatusCodes.Status404NotFound)] 
        public async Task<ActionResult<EftRequestDto>> ApproveExpenseRequest(int id)
        {
            var response = await _expenseRequestService.ApproveAsync(id);
            return Ok(response);
        }


        [HttpPost("reject/{id}")]
        [Authorize(Roles = ApplicationRole.Admin)]
        [ProducesResponseType(typeof(RejectionResponseDto), StatusCodes.Status200OK)] 
        [ProducesResponseType(StatusCodes.Status400BadRequest)] 
        [ProducesResponseType(StatusCodes.Status404NotFound)] 
        public async Task<ActionResult<RejectionResponseDto>> RejectExpenseRequest(int id, [FromBody] RejectExpenseRequestDto request)
        {
            var response = await _expenseRequestService.RejectAsync(id, request.RejectionReason);
            return Ok(response);
        }

        [HttpGet("me")]
        [Authorize(Roles = ApplicationRole.Personnel)]
        [ProducesResponseType(typeof(IEnumerable<GetExpenseRequestDto>), StatusCodes.Status200OK)] 
        [ProducesResponseType(StatusCodes.Status400BadRequest)] 
        public async Task<IActionResult> FilterMyExpenses([FromQuery] ExpenseRequestFilterDto filter)
        {
            var filtered = await _expenseRequestService.FilterMyRequestsAsync(filter);
            return Ok(filtered);
        }

    }
}