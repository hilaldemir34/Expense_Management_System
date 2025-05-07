using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseManagementSystem.Application.Features.ExpenseDocuments
{
    public interface IExpenseDocumentService
    {
        Task UploadAsync(int expenseRequestId, IFormFileCollection files);
        Task<IEnumerable<string>> GetFileUrlsAsync(int expenseRequestId);
    }
}
