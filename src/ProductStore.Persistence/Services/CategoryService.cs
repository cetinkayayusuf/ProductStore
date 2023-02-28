using Microsoft.Extensions.Caching.Memory;
using ProductStore.Application.Dto.Category;
using ProductStore.Application.Repositories;
using ProductStore.Application.Services;

namespace ProductStore.Persistance.Services;

public class CategoryService : ICategoryService
{
    readonly ICategoryWriteRepository _categoryWriteRepository;
    private readonly ICategoryReadRepository _categoryReadRepository;


    public CategoryService(ICategoryWriteRepository categoryWriteRepository, ICategoryReadRepository categoryReadRepository)
    {
        _categoryWriteRepository = categoryWriteRepository;
        _categoryReadRepository = categoryReadRepository;
    }

    public async Task AddAsync(AddCategoryDto addDto)
    {
        await _categoryWriteRepository.AddAsync(new()
        {
            Name = addDto.Name,
        });
        await _categoryWriteRepository.SaveAsync();
    }

    public async Task DeleteAsync(string id)
    {
        await _categoryWriteRepository.RemoveAsync(id);
        await _categoryWriteRepository.SaveAsync();
    }

    public async Task<IQueryable<CategoryDto>> GetAllAsync()
    {
        List<CategoryDto> categories = (List<CategoryDto>)_categoryReadRepository.GetAll(false).Select(c => new CategoryDto()
        {
            Id = c.Id.ToString(),
            Name = c.Name
        }).ToList();
        return categories.AsQueryable();
    }

    public async Task<CategoryDto> GetByIdAsync(string id)
    {
        var entity = await _categoryReadRepository.GetByIdAsync(id, false);
        return new()
        {
            Name = entity.Name
        };
    }

    public async Task UpdateAsync(UpdateCategoryDto updateDto)
    {
        var entity = await _categoryReadRepository.GetByIdAsync(updateDto.Id);
        entity.Name = updateDto.Name;
        await _categoryWriteRepository.SaveAsync();
    }
}