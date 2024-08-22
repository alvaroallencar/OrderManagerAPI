using MediatR;
using Microsoft.AspNetCore.Mvc;
using OrderManagerAPI.Application.Commands;

namespace OrderManagerAPI.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CustomerController(ISender mediator) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> AddCustomer([FromBody] CreateCustomerCommand command)
    {
        var customerId = await mediator.Send(command);
        return Ok(customerId);
    }
}