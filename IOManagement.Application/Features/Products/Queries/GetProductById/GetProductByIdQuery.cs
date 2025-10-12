using IOManagement.Application.DTOs.Product;
using MediatR;

namespace IOManagement.Application.Features.Products.Queries.GetProductById
{

    // IRequest<ProductDto>, MediatR'a "Bu sorgu çalıştırıldığında bir ProductDto dönecek" diyecek!
    public record GetProductByIdQuery(Guid Id) : IRequest<ProductDto?>;

  
}
