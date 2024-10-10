using CRM.Api.Features.Customer;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace CRM.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class WebhookController: ControllerBase
{
    private readonly IMediator _mediator;

    public WebhookController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("customer-created")]
    public async Task<IActionResult> HandlerRegisterCustomerNotification(
                            [FromBody]RegisterCustomerCommand command, [FromQuery] string validationToken)
    {
        
        if (!validationToken.IsNullOrEmpty())
        {
            return Content(validationToken, "text/plain");
        }

        await _mediator.Send(command);
        return Ok();
    }
    
    [HttpPost("lead-converted")]
    public async Task<IActionResult> HandlerConvertedFromLeadToCustomerNotification(
                                    [FromBody]ConvertedFromLeadToCustomerCommand command,
                                    [FromQuery] string validationToken)
    {
        if (!validationToken.IsNullOrEmpty())
        {
            return Content(validationToken, "text/plain");
        }

        await _mediator.Send(command);
        return Ok();
    }
}