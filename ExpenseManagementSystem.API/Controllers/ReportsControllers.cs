using ExpenseManagementSystem.Application.Features.Reports;
using ExpenseManagementSystem.Application.Features.Reports.DTOs;
using ExpenseManagementSystem.Domain.Entities.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace ExpenseManagementSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class ReportsController : ControllerBase
    {
        private readonly IReportingService _reportingService;

        public ReportsController(IReportingService reportingService)
        {
            _reportingService = reportingService;
        }

        [Authorize(Roles = ApplicationRole.Admin)]
        [HttpGet("expenses-daily")]
        [ProducesResponseType(typeof(IEnumerable<DailyExpenseReportDto>), StatusCodes.Status200OK)] 
        public async Task<IActionResult> GetDailyPaymentReport()
        {
            var result = await _reportingService.GetDailyExpensesAsync();
            return Ok(result);
        }

        [Authorize(Roles = ApplicationRole.Admin)]
        [HttpGet("expenses-weekly")]
        [ProducesResponseType(typeof(IEnumerable<WeeklyExpenseReportDto>), StatusCodes.Status200OK)] 
        public async Task<IActionResult> GetWeeklyPayments()
            => Ok(await _reportingService.GetWeeklyExpensesAsync());

        [Authorize(Roles = ApplicationRole.Admin)]
        [HttpGet("expenses-monthly")]
        [ProducesResponseType(typeof(IEnumerable<MonthlyExpenseReportDto>), StatusCodes.Status200OK)] 
        public async Task<IActionResult> GetMonthlyPayments()
            => Ok(await _reportingService.GetMonthlyExpensesAsync());

        [Authorize(Roles = ApplicationRole.Admin)]
        [HttpGet("daily-personnel-expenses")]
        [ProducesResponseType(typeof(IEnumerable<DailyPersonnelExpenseReportsDto>), StatusCodes.Status200OK)] 
        public async Task<IActionResult> GetDailyByUser()
        {
            var dailySpendingReport = await _reportingService.GetDailyExpenseByUserAsync();
            return Ok(dailySpendingReport);
        }

        [Authorize(Roles = ApplicationRole.Admin)]
        [HttpGet("weekly-personnel-expenses")]
        [ProducesResponseType(typeof(IEnumerable<WeeklyPersonnelExpensesReportDto>), StatusCodes.Status200OK)] 
        public async Task<IActionResult> GetWeeklyByUser()
        {
            var weeklySpendingReport = await _reportingService.GetWeeklyExpenseByUserAsync();
            return Ok(weeklySpendingReport);
        }

        [Authorize(Roles = ApplicationRole.Admin)]
        [HttpGet("monthly-personnel-expenses")]
        [ProducesResponseType(typeof(IEnumerable<MonthlyPersonnelExpensesReportDto>), StatusCodes.Status200OK)] 
        public async Task<IActionResult> GetMonthlyByUser()
        {
            var monthlySpendingReport = await _reportingService.GetMonthlyExpenseByUserAsync();
            return Ok(monthlySpendingReport);
        }

        [Authorize(Roles = ApplicationRole.Admin)]
        [HttpGet("daily-expense-status")]
        [ProducesResponseType(typeof(IEnumerable<DailyExpenseStatusReportDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetDailyExpenseSummary()
        {
            var dailyExpenseApprove = await _reportingService.GetDailyExpenseStatusAsync();
            return Ok(dailyExpenseApprove);
        }

        [Authorize(Roles = ApplicationRole.Admin)]
        [HttpGet("weekly-expense-status")]
        [ProducesResponseType(typeof(IEnumerable<WeeklyExpenseStatusReportDto>), StatusCodes.Status200OK)] 
        public async Task<IActionResult> GetWeeklyExpenseSummary()
        {
            var weeklyExpenseApprove = await _reportingService.GetWeeklyExpenseStatusAsync();
            return Ok(weeklyExpenseApprove);
        }

        [Authorize(Roles = ApplicationRole.Admin)]
        [HttpGet("monthly-expense-status")]
        [ProducesResponseType(typeof(IEnumerable<MonthlyExpenseStatusReportDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetMonthlyExpenseSummary()
        {
            var monthlyExpenseApprove = await _reportingService.GetMonthlyExpenseStatusAsync();
            return Ok(monthlyExpenseApprove);
        }

        [HttpGet("my-expenses")]
        [Authorize(Roles = ApplicationRole.Personnel)]
        public async Task<IActionResult> GetMyExpenses()
        {
            var result = await _reportingService.GetMyExpenseHistoryAsync();
            return Ok(result);
        }
    }
}
