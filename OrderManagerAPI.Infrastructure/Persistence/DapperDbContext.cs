using System.Data;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace OrderManagerAPI.Infrastructure.Data;

public class DapperDbContext
{
    private readonly string _connectionString;

    public DapperDbContext(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException();
    }

    public IDbConnection CreateConnection() => new SqlConnection(_connectionString);
}