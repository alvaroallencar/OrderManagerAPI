using OrderManagerAPI.Domain.Entities;

namespace OrderManagerAPI.Domain.Interfaces;

public interface IOrderRepository
{
    Task<Order> AddOrderAsync(Order order);
    Task<IEnumerable<Order>> GetOrdersByCustomerIdAsync(int customerId);
    Task<IEnumerable<Order>> GetOrdersWithCustomerNameAsync();
    Task<IEnumerable<Order>> GetOrdersByQuantityAsync(int quantity);
}