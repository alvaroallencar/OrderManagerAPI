using MediatR;
using Microsoft.AspNetCore.Mvc;
using OrderManagerAPI.Application.Commands;
using OrderManagerAPI.Application.Queries;

namespace OrderManagerAPI.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CustomersController(ISender mediator) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> AddCustomer([FromBody] CreateCustomerCommand command)
    {
        var customerId = await mediator.Send(command);
        return Ok(customerId);
    }

    [HttpGet("{customerId:required}/orders")]
    public async Task<IActionResult> GetOrdersByCustomer(int customerId)
    {
        var query = new GetOrdersByCustomerIdQuery { CustomerId = customerId };
        var orders = await mediator.Send(query);
        return Ok(orders);
    }
}