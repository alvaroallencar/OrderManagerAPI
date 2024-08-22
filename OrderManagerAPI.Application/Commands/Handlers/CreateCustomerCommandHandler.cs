using MediatR;
using OrderManagerAPI.Domain.Entities;
using OrderManagerAPI.Domain.Interfaces;

namespace OrderManagerAPI.Application.Commands.Handlers;

public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, int>
{
    private readonly ICustomerRepository _customerRepository;

    public CreateCustomerCommandHandler(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }

    public async Task<int> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
    {
        var customer = new Customer { Name = request.Name };
        await _customerRepository.AddCustomerAsync(customer);
        return customer.CustomerId;
    }
}