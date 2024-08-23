using System.Data;
using Dapper;
using OrderManagerAPI.Domain.Entities;
using OrderManagerAPI.Domain.Interfaces;
using OrderManagerAPI.Infrastructure.Data;

namespace OrderManagerAPI.Infrastructure.Repositories;

public class OrderRepository(DapperDbContext dbContext) : IOrderRepository
{
    public async Task<int> AddOrderAsync(Order order)
    {
        const string sql = @"
        INSERT INTO Orders (CustomerId, Quantity, OrderDate) 
        VALUES (@CustomerId, @Quantity, @OrderDate); 

        SELECT CAST(SCOPE_IDENTITY() as int);
    ";

        using var connection = dbContext.CreateConnection();
        return await connection.QuerySingleAsync<int>(sql, order);
    }

    public async Task<IEnumerable<Order>> GetOrdersByCustomerIdAsync(int customerId)
    {
        using var connection = dbContext.CreateConnection();
        var parameters = new DynamicParameters();
        parameters.Add("@CustomerId", customerId);

        IEnumerable<Order> orders = await connection.QueryAsync<Order>(
            "GetOrdersByCustomer",
            parameters,
            commandType: CommandType.StoredProcedure
        );

        return orders;
    }

    public async Task<IEnumerable<Order>> GetOrdersWithCustomerNameAsync()
    {
        var sql = @"
            SELECT 
                o.OrderId, 
                o.Quantity, 
                o.OrderDate, 
                c.Name 
            FROM 
                Orders o 
            INNER JOIN 
                Customers c 
            ON 
                o.CustomerId = c.CustomerId;
        ";
        using var connection = dbContext.CreateConnection();
        return await connection.QueryAsync<Order>(sql);
    }

    public async Task<IEnumerable<Order>> GetOrdersByQuantityAsync(int quantity)
    {
        var sql = @"
            SELECT 
                o.OrderId, 
                o.Quantity, 
                o.OrderDate 
            FROM 
                Orders o 
            WHERE 
                o.Quantity > @Quantity;
        ";
        using var connection = dbContext.CreateConnection();
        return await connection.QueryAsync<Order>(sql, new { Quantity = quantity });
    }
}