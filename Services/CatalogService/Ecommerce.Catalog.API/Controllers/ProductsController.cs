using Ecommerce.Catalog.Application.DTOs.Product;
using Ecommerce.Catalog.Application.Features.Product.Command;
using Ecommerce.Catalog.Application.Features.Product.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Catalog.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductsController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly ILogger<ProductsController> _logger;
    public ProductsController(IMediator mediator, ILogger<ProductsController> logger)
    {
        _mediator = mediator;
        _logger = logger;
    }

    // POST: api/products
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateProductCommand command)
    {
        var id = await _mediator.Send(command);
        return CreatedAtAction(nameof(GetById), new { id = id }, new { id });
    }

    // PUT: api/products/{id}
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] UpdateProductCommand command)
    {
        if (id != command.Id)
            return BadRequest("Mismatched product ID");
        var result = await _mediator.Send(command);
        return result ? NoContent() : NotFound();
    }

    // DELETE: api/products/{id}
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var command = new DeleteProductCommand { Id = id };
        var result = await _mediator.Send(command);
        return result ? NoContent() : NotFound();
    }

    // GET: api/products
    [HttpGet]
    public async Task<ActionResult<List<ProductDto>>> GetAll([FromQuery] int page = 1, [FromQuery] int pageSize = 20)
    {
        var query = new GetAllProductsQuery { Page = page, PageSize = pageSize };
        var products = await _mediator.Send(query);
        return Ok(products);
    }

    // GET: api/products/{id}
    [HttpGet("{id}")]
    public async Task<ActionResult<ProductDto>> GetById(Guid id)
    {
        var query = new GetProductByIdQuery { ProductId = id };
        var product = await _mediator.Send(query);
        if (product == null) return NotFound();
        return Ok(product);
    }

    // GET: api/products/by-sku/{sku}
    [HttpGet("by-sku/{sku}")]
    public async Task<ActionResult<ProductDto>> GetBySku(string sku)
    {
        var query = new GetProductBySkuQuery { Sku = sku };
        var product = await _mediator.Send(query);
        if (product == null) return NotFound();
        return Ok(product);
    }

    // Additional endpoints (search/filter, images, etc.) follow the same structure!
}