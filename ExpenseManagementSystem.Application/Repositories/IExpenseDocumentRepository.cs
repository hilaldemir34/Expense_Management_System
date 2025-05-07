using ExpenseManagementSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseManagementSystem.Application.Repositories
{
    public interface IExpenseDocumentRepository
    {
        Task AddRangeAsync(IEnumerable<ExpenseDocument> docs);
        Task<List<ExpenseDocument>> GetByRequestIdAsync(int reqId);
    }
}
