using IOManagement.Application.DTOs.Product;
using MediatR;

namespace IOManagement.Application.Features.Products.Commands.CreateProduct;

// When this command is sent, it will return a ProductDto object as a response.
public class CreateProductCommand : IRequest<ProductDto>
{
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public int StockQuantity { get; set; }
}
