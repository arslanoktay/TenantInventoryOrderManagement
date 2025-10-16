using IOManagement.Application.Features.Products.Commands.CreateProduct;
using IOManagement.Application.Features.Products.Queries.GetProductById;
using Microsoft.AspNetCore.Mvc;

namespace IOManagement.API.Controllers;



public class ProductsController : ApiControllerBase
{
    [HttpGet("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetProductById(Guid id)
    {
       var query = new GetProductByIdQuery(id); // Bir sorgu nesnesi oluşturuyoruz
        var result = await Mediator.Send(query); // Sorguyu handler a gönder

       return result is not null ? Ok(result) : NotFound();
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CreateProduct([FromBody] CreateProductCommand command)
    {
        var result = await Mediator.Send(command);
        return CreatedAtAction(nameof(GetProductById), new { id = result.Id }, result);
    }
}
