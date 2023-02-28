using AutoMapper;
using ProductStore.Application.Dto.Category;
using ProductStore.Domain.Entities;

namespace ProductStore.Persistence.Mappings
{
    public class CategoryMappingProfile : Profile
    {
        public CategoryMappingProfile()
        {
            CreateMap<AddCategoryDto, Category>();

            CreateMap<Category, CategoryDto>();

            CreateMap<Category, CategoryDetailDto>();
        }
    }
}