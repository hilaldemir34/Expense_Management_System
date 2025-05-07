using ExpenseManagementSystem.Domain.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseManagementSystem.Application.Interfaces
{
    public interface ITokenGenerator
    {
        string GenerateAccessToken(ApplicationUser applicationUser,string role);
    }
}
