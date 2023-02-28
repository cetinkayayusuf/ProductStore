
using ProductStore.Application.Dto.Category;

namespace ProductStore.Application.Services;

public interface ICategoryService
{
    Task AddAsync(AddCategoryDto addDto);
    Task DeleteAsync(string id);
    Task UpdateAsync(UpdateCategoryDto updateDto);
    Task<IQueryable<CategoryDto>> GetAllAsync();

    Task<CategoryDto> GetByIdAsync(string id);

}