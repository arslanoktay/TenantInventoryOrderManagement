using AutoMapper;
using IOManagement.Application.Contracts.Persistence;
using IOManagement.Application.DTOs.Product;
using IOManagement.Domain.Entities;
using MediatR;

namespace IOManagement.Application.Features.Products.Queries.GetProductById
{
    public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, ProductDto?>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public GetProductByIdQueryHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<ProductDto?> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            Product? product = await _productRepository.GetByIdAsync(request.Id);

            if (product == null)
            {
                return null; // Ürün bulunamadıysa null dönebiliriz
            }

            return _mapper.Map<ProductDto>(product);
        }
    }
}
