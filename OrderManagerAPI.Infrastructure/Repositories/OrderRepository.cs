using Dapper;
using OrderManagerAPI.Domain.Entities;
using OrderManagerAPI.Domain.Interfaces;
using OrderManagerAPI.Infrastructure.Data;

namespace OrderManagerAPI.Infrastructure.Repositories;

public class OrderRepository(DapperDbContext dbContext) : IOrderRepository
{
    public async Task<int> AddOrderAsync(Order order)
    {
        const string sql =
            "INSERT INTO Orders (CustomerId, Quantity, OrderDate) VALUES (@CustomerId, @Quantity, @OrderDate); SELECT CAST(SCOPE_IDENTITY() as int);";
        using var connection = dbContext.CreateConnection();
        return await connection.QuerySingleAsync<int>(sql, order);
    }

    public async Task<IEnumerable<Order>> GetOrdersByCustomerIdAsync(int customerId)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<Order>> GetOrdersWithCustomerNameAsync()
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<Order>> GetOrdersByQuantityAsync(int quantity)
    {
        throw new NotImplementedException();
    }
}