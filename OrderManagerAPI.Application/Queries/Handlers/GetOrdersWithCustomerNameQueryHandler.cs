using MediatR;
using OrderManagerAPI.Domain.Entities;
using OrderManagerAPI.Domain.Interfaces;

namespace OrderManagerAPI.Application.Queries.Handlers;

public class GetOrdersWithCustomerNameQueryHandler : IRequestHandler<GetOrdersWithCustomerNameQuery, IEnumerable<Order>>
{
    private readonly IOrderRepository _orderRepository;

    public GetOrdersWithCustomerNameQueryHandler(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }

    public async Task<IEnumerable<Order>> Handle(GetOrdersWithCustomerNameQuery request, CancellationToken cancellationToken)
    {
        return await _orderRepository.GetOrdersWithCustomerNameAsync();
    }
}