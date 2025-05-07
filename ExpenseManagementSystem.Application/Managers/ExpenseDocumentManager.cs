using ExpenseManagementSystem.Application.Features.ExpenseDocuments;
using ExpenseManagementSystem.Application.Repositories;
using ExpenseManagementSystem.Domain.Entities;
using ExpenseManagementSystem.Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseManagementSystem.Application.Managers
{
    public class ExpenseDocumentManager : IExpenseDocumentService
    {
        private readonly IExpenseDocumentRepository _docRepo;
        private readonly IUnitOfWork _unitOfWork;

        public ExpenseDocumentManager(IExpenseDocumentRepository docRepo, IUnitOfWork unitOfWork)
        {
            _docRepo = docRepo;
            _unitOfWork = unitOfWork;
        }

        public async Task UploadAsync(int expenseRequestId, IFormFileCollection files)
        {
            var today = DateTime.UtcNow.ToString("yyyy-MM-dd");
            var uploadDir = Path.Combine("wwwroot/uploads", today);
            Directory.CreateDirectory(uploadDir);

            var docs = new List<ExpenseDocument>();
            foreach (var file in files ?? Enumerable.Empty<IFormFile>())
            {
                var ext = Path.GetExtension(file.FileName);
                var guid = Guid.NewGuid();
                var fileName = guid + ext;
                var fullPath = Path.Combine(uploadDir, fileName);
                using var stream = new FileStream(fullPath, FileMode.Create);
                await file.CopyToAsync(stream);

                docs.Add(new ExpenseDocument
                {
                    ExpenseRequestId = expenseRequestId,
                    FileId = guid,
                    FileName = file.FileName,
                    Location = $"/uploads/{today}/{fileName}"
                });
            }
            await _docRepo.AddRangeAsync(docs);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<IEnumerable<string>> GetFileUrlsAsync(int expenseRequestId)
        {
            var docs = await _docRepo.GetByRequestIdAsync(expenseRequestId);
            return docs.Select(d => d.Location);
        }
    }
}
