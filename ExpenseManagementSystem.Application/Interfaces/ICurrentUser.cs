using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseManagementSystem.Application.Interfaces
{
    public interface ICurrentUser
    {
        bool IsAuthenticated { get; }
        string? UserId { get; }
        string? Username { get; }
    }
}
