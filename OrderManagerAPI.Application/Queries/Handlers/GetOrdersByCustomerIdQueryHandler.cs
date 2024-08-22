using MediatR;
using OrderManagerAPI.Domain.Entities;
using OrderManagerAPI.Domain.Interfaces;

namespace OrderManagerAPI.Application.Queries.Handlers;

public class GetOrdersByCustomerIdQueryHandler : IRequestHandler<GetOrdersByCustomerIdQuery, IEnumerable<Order>>
{
    private readonly IOrderRepository _orderRepository;

    public GetOrdersByCustomerIdQueryHandler(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }

    public async Task<IEnumerable<Order>> Handle(GetOrdersByCustomerIdQuery request,
        CancellationToken cancellationToken)
    {
        return await _orderRepository.GetOrdersByCustomerIdAsync(request.CustomerId);
    }
}