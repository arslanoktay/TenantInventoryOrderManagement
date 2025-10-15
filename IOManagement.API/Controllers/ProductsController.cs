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
}
