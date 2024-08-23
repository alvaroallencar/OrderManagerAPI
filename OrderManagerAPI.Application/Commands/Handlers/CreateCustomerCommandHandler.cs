using MediatR;
using OrderManagerAPI.Domain.Entities;
using OrderManagerAPI.Domain.Interfaces;

namespace OrderManagerAPI.Application.Commands.Handlers;

public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, Customer>
{
    private readonly ICustomerRepository _customerRepository;

    public CreateCustomerCommandHandler(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }

    public async Task<Customer> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
    {
        var customer = new Customer { Name = request.Name };
        var createdCustomer = await _customerRepository.AddCustomerAsync(customer);
        return createdCustomer;
    }
}