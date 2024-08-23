using MediatR;
using OrderManagerAPI.Domain.Entities;
using OrderManagerAPI.Domain.Interfaces;

namespace OrderManagerAPI.Application.Queries.Handlers;

public class GetOrdersByQuantityQueryHandler(IOrderRepository orderRepository)
    : IRequestHandler<GetOrdersByQuantityQuery, IEnumerable<Order>>
{
    public async Task<IEnumerable<Order>> Handle(GetOrdersByQuantityQuery request, CancellationToken cancellationToken)
    {
        return await orderRepository.GetOrdersByQuantityAsync(request.Quantity);
    }
}