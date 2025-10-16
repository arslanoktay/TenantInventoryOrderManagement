using AutoMapper;
using IOManagement.Application.Features.Products.Commands.CreateProduct;
using IOManagement.Domain.Entities;

namespace IOManagement.Application.MappingProfiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            // Domain Entity -> DTO
            CreateMap<Domain.Entities.Product, DTOs.Product.ProductDto>().ReverseMap();
            CreateMap<CreateProductCommand, Product>();
        }
    }
}
