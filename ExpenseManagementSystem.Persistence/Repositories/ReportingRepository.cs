using Dapper;
using ExpenseManagementSystem.Application.Features.Reports.DTOs;
using ExpenseManagementSystem.Application.Repositories;
using ExpenseManagementSystem.Persistence.Context;

namespace ExpenseManagementSystem.Persistence.Repositories
{
    public class ReportingRepository : IReportingRepository
    {
        private readonly IDapperContext _dapperContext;
        public ReportingRepository(IDapperContext dapperContext)
        {
            _dapperContext = dapperContext;
        }
        public async Task<IEnumerable<DailyExpenseReportDto>> GetDailyExpensesAsync()
        {
            using var conn = _dapperContext.CreateConnection();
            var list = await conn.QueryAsync<DailyExpenseReportDto>(
                @"SELECT 
                   CAST(PaidAt AS DATE) AS ExpenseDate,
                      COUNT(*) AS TotalPayments,
                         SUM(Amount) AS TotalAmount
                            FROM 
                              dbo.Payments
                                GROUP BY 
                                 CAST(PaidAt AS DATE)
                                    ORDER BY 
                                      ExpenseDate DESC;");
            return list;
        }

        public async Task<IEnumerable<WeeklyExpenseReportDto>> GetWeeklyExpensesAsync()
        {
            const string sql = @"SELECT Year,WeekNumber,TotalExpenses,TotalAmount FROM dbo.V_WeeklyExpenseDensityReport;";
            using var conn = _dapperContext.CreateConnection();
            return await conn.QueryAsync<WeeklyExpenseReportDto>(sql);
        }

        public async Task<IEnumerable<MonthlyExpenseReportDto>> GetMonthlyExpensesAsync()
        {
            const string sql = @"SELECT Year, Month, TotalExpenses, TotalAmount FROM dbo.V_MonthlyExpenseDensityReport;";
            using var conn = _dapperContext.CreateConnection();
            return await conn.QueryAsync<MonthlyExpenseReportDto>(sql);
        }
        public async Task<IEnumerable<DailyPersonnelExpenseReportsDto>> GetDailyExpensesByUserAsync()
        {
            const string sql = @"SELECT ExpenseDate, UserId, UserName, TotalExpenses, TotalAmount FROM dbo.V_DailyPersonnelExpenseDensityReport;";
            using var conn = _dapperContext.CreateConnection();
            return await conn.QueryAsync<DailyPersonnelExpenseReportsDto>(sql);
        }
        public async Task<IEnumerable<WeeklyPersonnelExpensesReportDto>> GetWeeklyExpensesByUserAsync()
        {
            const string sql = @"SELECT Year,Week,UserId, UserName, TotalAmount, TotalExpenses FROM dbo.V_WeeklyPersonnelExpenseDensityReport;";
            using var conn = _dapperContext.CreateConnection();
            return await conn.QueryAsync<WeeklyPersonnelExpensesReportDto>(sql);
        }
        public async Task<IEnumerable<MonthlyPersonnelExpensesReportDto>> GetMonthlyExpensesByUserAsync()
        {
            const string sql = @" SELECT UserId, UserName, Year, Month, TotalAmount, TotalExpenses  FROM dbo.V_MonthlyPersonnelExpenseDensityReport;";
            using var conn = _dapperContext.CreateConnection();
            return await conn.QueryAsync<MonthlyPersonnelExpensesReportDto>(sql);
        }

        public async Task<IEnumerable<DailyExpenseStatusReportDto>> GetDailyExpenseStatusAsync()
        {

            const string sql = @"SELECT ExpenseDate, ApprovedCount,ApprovedTotalAmount,RejectedCount,RejectedTotalAmount FROM dbo.V_DailyExpenseStatusReport;";
            using var conn = _dapperContext.CreateConnection();
            return await conn.QueryAsync<DailyExpenseStatusReportDto>(sql);

        }

        public async Task<IEnumerable<WeeklyExpenseStatusReportDto>> GetWeeklyExpenseStatusAsync()
        {

            const string sql = @"SELECT  Year, Week, ApprovedCount,ApprovedTotalAmount,RejectedCount,RejectedTotalAmount FROM dbo.V_WeeklyExpenseStatusReport;";
            using var conn = _dapperContext.CreateConnection();
            return await conn.QueryAsync<WeeklyExpenseStatusReportDto>(sql);
        }

        public async Task<IEnumerable<MonthlyExpenseStatusReportDto>> GetMonthlyExpenseStatusAsync()
        {
            const string sql = @"SELECT Year, Month, ApprovedCount,ApprovedTotalAmount,RejectedCount,RejectedTotalAmount FROM dbo.V_MonthlyExpenseStatusReport;";
            using var conn = _dapperContext.CreateConnection();
            return await conn.QueryAsync<MonthlyExpenseStatusReportDto>(sql);
        }

        public async Task<IEnumerable<ExpenseReportDto>> GetUserExpensesAsync(string userId)
        {
            const string sql = @"
            SELECT
              ExpenseRequestId,
              RequestDate,
              RequestStatus,
              RequestRejectionReason,
              ExpenseId,
              ExpenseAmount,
              ExpenseDescription,
              ExpenseCreatedDate,
              ExpenseCategoryName
            FROM V_UserExpenseReport
            WHERE RequesterUserId = @UserId
            ORDER BY RequestDate DESC, ExpenseCreatedDate DESC;";

            using var conn = _dapperContext.CreateConnection();
            return await conn.QueryAsync<ExpenseReportDto>(sql, new { UserId = userId });
        }

    }

}


