using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseManagementSystem.Application.Features.Auths
{
    public interface IAuthService
    {
        Task<string> RegisterAsync(string email, string password,string nameSurname);
        Task<string> LoginAsync(string email, string password);
    }
}
