using OrderManagerAPI.Domain.Entities;

namespace OrderManagerAPI.Domain.Interfaces;

public interface ICustomerRepository
{
    Task<Customer> AddCustomerAsync(Customer customer);
}