using MediatR;
using OrderManagerAPI.Domain.Entities;
using OrderManagerAPI.Domain.Interfaces;

namespace OrderManagerAPI.Application.Queries.Handlers;

public class GetOrdersByQuantityQueryHandler : IRequestHandler<GetOrdersByQuantityQuery, IEnumerable<Order>>
{
    private readonly IOrderRepository _orderRepository;

    public GetOrdersByQuantityQueryHandler(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }

    public async Task<IEnumerable<Order>> Handle(GetOrdersByQuantityQuery request, CancellationToken cancellationToken)
    {
        return await _orderRepository.GetOrdersByQuantityAsync(request.Quantity);
    }
}