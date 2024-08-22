using Dapper;
using OrderManagerAPI.Domain.Entities;
using OrderManagerAPI.Domain.Interfaces;
using OrderManagerAPI.Infrastructure.Data;

namespace OrderManagerAPI.Infrastructure.Repositories;

public class CustomerRepository : ICustomerRepository
{
    private readonly DapperDbContext _dbContext;

    public CustomerRepository(DapperDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task AddCustomerAsync(Customer customer)
    {
        var sql = "INSERT INTO Customers (Name) VALUES (@Name); SELECT CAST(SCOPE_IDENTITY() as int)";
        using var connection = _dbContext.CreateConnection();
        customer.CustomerId = await connection.QuerySingleAsync<int>(sql, customer);
    }

    public async Task<Customer> GetCustomerByIdAsync(int customerId)
    {
        throw new NotImplementedException();
    }
}