using MediatR;
using OrderManagerAPI.Domain.Entities;

namespace OrderManagerAPI.Application.Commands;

public class CreateCustomerCommand : IRequest<Customer>
{
    public required string Name { get; set; }
}