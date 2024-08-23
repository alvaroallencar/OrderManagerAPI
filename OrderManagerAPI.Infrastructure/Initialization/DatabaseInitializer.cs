using Dapper;
using Microsoft.Extensions.Logging;
using OrderManagerAPI.Infrastructure.Data;

namespace OrderManagerAPI.Infrastructure.Initialization;

public class DatabaseInitializer(DapperDbContext dbContext, ILogger<DatabaseInitializer> logger)
{
    public async Task EnsureStoredProceduresAsync()
    {
        using var connection = dbContext.CreateConnection();
        var sql = @"
                IF NOT EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'GetOrdersByCustomer')
                BEGIN
                    EXEC('CREATE PROCEDURE GetOrdersByCustomer
                        @CustomerId INT
                    AS
                    BEGIN
                        SELECT * FROM Orders WHERE CustomerId = @CustomerId;
                    END')
                END";

        try
        {
            await connection.ExecuteAsync(sql);
            logger.LogInformation("Stored procedure 'GetOrdersByCustomer' created successfully.");
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "An error occurred while creating the stored procedure.");
        }
    }
}