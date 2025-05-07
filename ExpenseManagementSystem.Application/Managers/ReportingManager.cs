using ExpenseManagementSystem.Application.Features.Reports;
using ExpenseManagementSystem.Application.Features.Reports.DTOs;
using ExpenseManagementSystem.Application.Features.Users;
using ExpenseManagementSystem.Application.Interfaces;
using ExpenseManagementSystem.Application.Repositories;

namespace ExpenseManagementSystem.Application.Managers
{
    public class ReportingManager : IReportingService
    {
        private readonly IReportingRepository _reportingRepository;
        private readonly ICurrentUser _currentUser;

        public ReportingManager(IReportingRepository reportingRepository, ICurrentUser currentUser)
        {
            _reportingRepository = reportingRepository;
            _currentUser = currentUser;
        }

        public Task<IEnumerable<DailyExpenseReportDto>> GetDailyExpensesAsync()
        {
            return _reportingRepository.GetDailyExpensesAsync();
        }

        public Task<IEnumerable<WeeklyExpenseReportDto>> GetWeeklyExpensesAsync()
        {
            return _reportingRepository.GetWeeklyExpensesAsync();
        }

        public Task<IEnumerable<MonthlyExpenseReportDto>> GetMonthlyExpensesAsync()
        {
            return _reportingRepository.GetMonthlyExpensesAsync();
        }

        public Task<IEnumerable<DailyPersonnelExpenseReportsDto>> GetDailyExpenseByUserAsync()
        {
            return _reportingRepository.GetDailyExpensesByUserAsync();
        }

        public Task<IEnumerable<WeeklyPersonnelExpensesReportDto>> GetWeeklyExpenseByUserAsync()
        {
            return _reportingRepository.GetWeeklyExpensesByUserAsync();
        }

        public Task<IEnumerable<MonthlyPersonnelExpensesReportDto>> GetMonthlyExpenseByUserAsync()
        {
            return _reportingRepository.GetMonthlyExpensesByUserAsync();
        }

        public Task<IEnumerable<DailyExpenseStatusReportDto>> GetDailyExpenseStatusAsync()
        {
            return _reportingRepository.GetDailyExpenseStatusAsync();
        }

        public Task<IEnumerable<WeeklyExpenseStatusReportDto>> GetWeeklyExpenseStatusAsync()
        {
            return _reportingRepository.GetWeeklyExpenseStatusAsync();
        }

        public Task<IEnumerable<MonthlyExpenseStatusReportDto>> GetMonthlyExpenseStatusAsync()
        {
            return _reportingRepository.GetMonthlyExpenseStatusAsync();
        }
   
        public Task<IEnumerable<ExpenseReportDto>> GetMyExpenseHistoryAsync()
        {
            return  _reportingRepository.GetUserExpensesAsync(_currentUser.UserId);
        }
    }
}
