using CRM.Api.Features.Customer;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CRM.Api.Controllers;

[ApiController]
[Route("customer")]
public class CustomerController: ControllerBase
{
    private readonly IMediator _mediator;

    public CustomerController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> RegisterCustomers(RegisterCustomerCommand command)
    {
        await _mediator.Send(command);
        return Ok();
    }
    
}