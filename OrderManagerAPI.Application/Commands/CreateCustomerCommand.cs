using MediatR;

namespace OrderManagerAPI.Application.Commands;

public class CreateCustomerCommand : IRequest<int>
{
    public string Name { get; set; }
}