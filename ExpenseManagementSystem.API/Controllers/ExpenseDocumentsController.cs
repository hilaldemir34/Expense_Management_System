using ExpenseManagementSystem.Application.Features.ExpenseDocuments;
using ExpenseManagementSystem.Domain.Entities.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseManagementSystem.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ExpenseDocumentsController : ControllerBase
    {
        private readonly IExpenseDocumentService _docService;
        public ExpenseDocumentsController(IExpenseDocumentService docService)
        {
            _docService = docService;
        }

        [HttpPost("{expenseRequestId}/files")]
        [Authorize(Roles = ApplicationRole.Personnel)]
        [ProducesResponseType(StatusCodes.Status200OK)] 
        [ProducesResponseType(StatusCodes.Status400BadRequest)] 
        [ProducesResponseType(StatusCodes.Status404NotFound)] 
        public async Task<IActionResult> UploadFiles(int expenseRequestId, [FromForm] IFormFileCollection files)
        {
            await _docService.UploadAsync(expenseRequestId, files);
            return Ok();
        }

        [HttpGet("{expenseRequestId}/files")]
        [Authorize(Roles = ApplicationRole.Personnel + "," + ApplicationRole.Admin)]
        [ProducesResponseType(typeof(IEnumerable<string>), StatusCodes.Status200OK)] 
        [ProducesResponseType(StatusCodes.Status404NotFound)] 
        public async Task<IActionResult> GetFiles(int expenseRequestId)
        {
            var urls = await _docService.GetFileUrlsAsync(expenseRequestId);
            return Ok(urls);
        }
    }
}