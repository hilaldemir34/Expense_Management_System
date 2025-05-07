using ExpenseManagementSystem.Application.Features.Reports.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseManagementSystem.Application.Repositories
{
    public interface IReportingRepository
    {
        Task<IEnumerable<DailyExpenseReportDto>> GetDailyExpensesAsync();
        Task<IEnumerable<WeeklyExpenseReportDto>> GetWeeklyExpensesAsync();
        Task<IEnumerable<MonthlyExpenseReportDto>> GetMonthlyExpensesAsync();
        Task<IEnumerable<DailyPersonnelExpenseReportsDto>> GetDailyExpensesByUserAsync();
        Task<IEnumerable<WeeklyPersonnelExpensesReportDto>> GetWeeklyExpensesByUserAsync();
        Task<IEnumerable<MonthlyPersonnelExpensesReportDto>> GetMonthlyExpensesByUserAsync();
        Task<IEnumerable<DailyExpenseStatusReportDto>> GetDailyExpenseStatusAsync();
        Task<IEnumerable<WeeklyExpenseStatusReportDto>> GetWeeklyExpenseStatusAsync();
        Task<IEnumerable<MonthlyExpenseStatusReportDto>> GetMonthlyExpenseStatusAsync();
        Task<IEnumerable<ExpenseReportDto>> GetUserExpensesAsync(string userId);

    }
}
