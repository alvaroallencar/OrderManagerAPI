using MediatR;
using OrderManagerAPI.Domain.Entities;

namespace OrderManagerAPI.Application.Commands;

public class CreateOrderCommand : IRequest<Order>
{
    public int CustomerId { get; set; }
    public int Quantity { get; set; }
    public DateTime OrderDate { get; set; }
}