using OrderManagerAPI.Domain.Entities;

namespace OrderManagerAPI.Domain.Interfaces;

public interface ICustomerRepository
{
    Task AddCustomerAsync(Customer customer);
    Task<Customer> GetCustomerByIdAsync(int customerId);
}