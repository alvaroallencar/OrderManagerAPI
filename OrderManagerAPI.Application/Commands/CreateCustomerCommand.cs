using MediatR;

namespace OrderManagerAPI.Application.Commands;

public class CreateCustomerCommand : IRequest<int>
{
    public required string Name { get; set; }
}