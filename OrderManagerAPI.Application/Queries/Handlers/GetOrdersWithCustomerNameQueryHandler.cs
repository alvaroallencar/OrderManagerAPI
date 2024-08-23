using MediatR;
using OrderManagerAPI.Domain.Entities;
using OrderManagerAPI.Domain.Interfaces;

namespace OrderManagerAPI.Application.Queries.Handlers;

public class GetOrdersWithCustomerNameQueryHandler(IOrderRepository orderRepository)
    : IRequestHandler<GetOrdersWithCustomerNameQuery, IEnumerable<Order>>
{
    public async Task<IEnumerable<Order>> Handle(GetOrdersWithCustomerNameQuery request,
        CancellationToken cancellationToken)
    {
        return await orderRepository.GetOrdersWithCustomerNameAsync();
    }
}