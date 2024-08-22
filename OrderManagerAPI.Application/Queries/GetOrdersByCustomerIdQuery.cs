using MediatR;
using OrderManagerAPI.Domain.Entities;

namespace OrderManagerAPI.Application.Queries;

public class GetOrdersByCustomerIdQuery : IRequest<IEnumerable<Order>>
{
    public int CustomerId { get; set; }
}