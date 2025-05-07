using ExpenseManagementSystem.Application.Features.ExpenseRequests.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseManagementSystem.Application.Interfaces
{
    public interface IExpenseOrchestrationService
    {
        Task CreateAsync(CreateExpenseRequestDto dto);


    }
}
