using AutoMapper;
using ProductStore.Application.Dto.Product;
using ProductStore.Domain.Entities;

namespace ProductStore.Persistence.Mappings
{
    public class ProductMappingProfile : Profile
    {
        public ProductMappingProfile()
        {
            CreateMap<AddProductDto, Product>();

            CreateMap<Product, ProductDto>();

            CreateMap<Product, ProductDetailDto>();
        }
    }
}