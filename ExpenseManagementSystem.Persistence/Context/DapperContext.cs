using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace ExpenseManagementSystem.Persistence.Context
{
    public interface IDapperContext
    {
        IDbConnection CreateConnection();
    }

    public class DapperContext : IDapperContext
    {
        private readonly string _connString;
        public DapperContext(IConfiguration config)
        {
            _connString = config.GetConnectionString("DefaultConnection");
        }
        public IDbConnection CreateConnection()
            => new SqlConnection(_connString);
    }
}
