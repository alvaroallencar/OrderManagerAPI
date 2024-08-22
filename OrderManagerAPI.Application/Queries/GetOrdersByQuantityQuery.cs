using MediatR;
using OrderManagerAPI.Domain.Entities;

namespace OrderManagerAPI.Application.Queries;

public class GetOrdersByQuantityQuery : IRequest<IEnumerable<Order>>
{
    public int Quantity { get; set; }
}