using AutoMapper;

namespace IOManagement.Application.MappingProfiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            // Domain Entity -> DTO
            CreateMap<Domain.Entities.Product, DTOs.Product.ProductDto>().ReverseMap();
        }
    }
}
