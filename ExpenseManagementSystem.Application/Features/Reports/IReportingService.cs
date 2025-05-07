using ExpenseManagementSystem.Application.Features.Reports.DTOs;

namespace ExpenseManagementSystem.Application.Features.Reports
{
    public interface IReportingService
    {

        Task<IEnumerable<DailyExpenseReportDto>> GetDailyExpensesAsync();
        Task<IEnumerable<WeeklyExpenseReportDto>> GetWeeklyExpensesAsync();
        Task<IEnumerable<MonthlyExpenseReportDto>> GetMonthlyExpensesAsync();
        Task<IEnumerable<DailyPersonnelExpenseReportsDto>> GetDailyExpenseByUserAsync();
        Task<IEnumerable<WeeklyPersonnelExpensesReportDto>> GetWeeklyExpenseByUserAsync();
        Task<IEnumerable<MonthlyPersonnelExpensesReportDto>> GetMonthlyExpenseByUserAsync();
        Task<IEnumerable<DailyExpenseStatusReportDto>> GetDailyExpenseStatusAsync();
        Task<IEnumerable<WeeklyExpenseStatusReportDto>> GetWeeklyExpenseStatusAsync();
        Task<IEnumerable<MonthlyExpenseStatusReportDto>> GetMonthlyExpenseStatusAsync();
        Task<IEnumerable<ExpenseReportDto>> GetMyExpenseHistoryAsync();


    }
}
