using CRM.Api.Features.Product;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CRM.Api.Controllers;
[ApiController]
[Route("product")]
public class ProductController: ControllerBase
{
    private readonly IMediator _mediator;

    public ProductController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetProductsAndStandardPrice(GetProductsAndStandardPriceQuery request)
    {
        await _mediator.Send(request);
        return Ok();
    }
}