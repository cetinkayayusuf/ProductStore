using AutoMapper;
using ProductStore.Application.Dto.ProductCollection;
using ProductStore.Domain.Entities;

namespace ProductStore.Persistence.Mappings
{
    public class ProductCollectionMappingProfile : Profile
    {
        public ProductCollectionMappingProfile()
        {
            CreateMap<AddProductCollectionDto, ProductCollection>();

            CreateMap<ProductCollection, ProductCollectionDto>();

            CreateMap<ProductCollection, ProductCollectionDetailDto>();
        }
    }
}