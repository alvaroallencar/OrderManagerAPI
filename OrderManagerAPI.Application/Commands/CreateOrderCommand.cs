using MediatR;

namespace OrderManagerAPI.Application.Commands;

public class CreateOrderCommand : IRequest<int>
{
    public int CustomerId { get; set; }
    public int Quantity { get; set; }
    public DateTime OrderDate { get; set; }
}