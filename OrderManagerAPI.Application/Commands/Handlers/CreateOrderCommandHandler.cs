using MediatR;
using OrderManagerAPI.Domain.Entities;
using OrderManagerAPI.Domain.Interfaces;

namespace OrderManagerAPI.Application.Commands.Handlers;

public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, Order>
{
    private readonly IOrderRepository _orderRepository;

    public CreateOrderCommandHandler(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }

    public async Task<Order> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
    {
        var order = new Order
        {
            CustomerId = request.CustomerId,
            Quantity = request.Quantity,
            OrderDate = request.OrderDate
        };
        var createdOder = await _orderRepository.AddOrderAsync(order);
        return createdOder;
    }
}