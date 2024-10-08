using Dapper;
using OrderManagerAPI.Domain.Entities;
using OrderManagerAPI.Domain.Interfaces;
using OrderManagerAPI.Infrastructure.Data;

namespace OrderManagerAPI.Infrastructure.Repositories;

public class CustomerRepository(DapperDbContext dbContext) : ICustomerRepository
{
    public async Task<Customer> AddCustomerAsync(Customer customer)
    {
        var sql = @"
                INSERT INTO Customers (Name) 
                VALUES (@Name); 
                SELECT CAST(SCOPE_IDENTITY() as int);
            ";

        using var connection = dbContext.CreateConnection();
        customer.CustomerId = await connection.QuerySingleAsync<int>(sql, customer);

        return customer;
    }
}