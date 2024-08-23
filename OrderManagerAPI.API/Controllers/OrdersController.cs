using MediatR;
using Microsoft.AspNetCore.Mvc;
using OrderManagerAPI.Application.Commands;
using OrderManagerAPI.Application.Queries;

namespace OrderManagerAPI.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrdersController(ISender mediator) : ControllerBase
{
    [HttpPost("")]
    public async Task<IActionResult> AddOrder([FromBody] CreateOrderCommand command)
    {
        var order = await mediator.Send(command);
        return Created(string.Empty, order);
    }

    [HttpGet("")]
    public async Task<IActionResult> GetOrders([FromQuery] int? quantity)
    {
        if (quantity.HasValue)
        {
            var query = new GetOrdersByQuantityQuery { Quantity = quantity.Value };
            var orders = await mediator.Send(query);
            return Ok(orders);
        }
        else
        {
            var query = new GetOrdersWithCustomerNameQuery();
            var orders = await mediator.Send(query);
            return Ok(orders);
        }
    }
}