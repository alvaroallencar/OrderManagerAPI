using MediatR;
using OrderManagerAPI.Domain.Entities;
using OrderManagerAPI.Domain.Interfaces;

namespace OrderManagerAPI.Application.Queries.Handlers;

public class GetOrdersByCustomerIdQueryHandler(IOrderRepository orderRepository)
    : IRequestHandler<GetOrdersByCustomerIdQuery, IEnumerable<Order>>
{
    public async Task<IEnumerable<Order>> Handle(GetOrdersByCustomerIdQuery request,
        CancellationToken cancellationToken)
    {
        return await orderRepository.GetOrdersByCustomerIdAsync(request.CustomerId);
    }
}