using ExpenseManagementSystem.Application.Repositories;
using ExpenseManagementSystem.Domain.Entities;
using ExpenseManagementSystem.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace ExpenseManagementSystem.Persistence.Repositories
{
    public class ExpenseDocumentRepository : IExpenseDocumentRepository
    {
        private readonly ApplicationDbContext _ctx;
        public ExpenseDocumentRepository(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }
        public async Task AddRangeAsync(IEnumerable<ExpenseDocument> docs)
        {
            await _ctx.ExpenseDocuments.AddRangeAsync(docs);
        }

        public async Task<List<ExpenseDocument>> GetByRequestIdAsync(int reqId)
        {
            return await _ctx.ExpenseDocuments
                  .Where(d => d.ExpenseRequestId == reqId)
                  .ToListAsync();
        }
    }

}
