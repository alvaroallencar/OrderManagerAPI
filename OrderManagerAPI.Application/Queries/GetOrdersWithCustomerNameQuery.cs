using MediatR;
using OrderManagerAPI.Domain.Entities;

namespace OrderManagerAPI.Application.Queries;

public class GetOrdersWithCustomerNameQuery : IRequest<IEnumerable<Order>>
{
}