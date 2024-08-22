CREATE PROCEDURE GetOrdersByCustomerId
@CustomerId INT
AS
BEGIN
    SELECT o.OrderId, o.Quantity, o.OrderDate, c.Name
    FROM Orders o
             INNER JOIN Customers c ON o.CustomerId = c.CustomerId
    WHERE o.CustomerId = @CustomerId
END