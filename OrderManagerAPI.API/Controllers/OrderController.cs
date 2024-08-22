using MediatR;
using Microsoft.AspNetCore.Mvc;
using OrderManagerAPI.Application.Commands;

namespace OrderManagerAPI.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrderController(ISender mediator) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> AddOrder([FromBody] CreateOrderCommand command)
    {
        var orderId = await mediator.Send(command);
        return Ok(orderId);
    }
}