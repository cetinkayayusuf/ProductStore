using Microsoft.Extensions.Caching.Memory;
using ProductStore.Application.Dto.Category;
using ProductStore.Application.Services;

namespace ProductStore.Persistance.Services;

public class CachedCategoryService : ICategoryService
{
    private const string CategoryListCacheKey = "CategoryList";
    private MemoryCacheEntryOptions cacheOptions;

    private readonly IMemoryCache _memoryCache;
    private readonly ICategoryService _categoryService;

    public CachedCategoryService(ICategoryService categoryService, IMemoryCache memoryCache)
    {
        _categoryService = categoryService;
        _memoryCache = memoryCache;

        cacheOptions = new MemoryCacheEntryOptions()
           .SetSlidingExpiration(TimeSpan.FromSeconds(10))
           .SetAbsoluteExpiration(TimeSpan.FromSeconds(30));
    }

    public async Task AddAsync(AddCategoryDto addDto)
    {
        await _categoryService.AddAsync(addDto);
        _memoryCache.Remove(CategoryListCacheKey);
    }

    public async Task DeleteAsync(string id)
    {
        await _categoryService.DeleteAsync(id);
    }

    public async Task<IQueryable<CategoryDto>> GetAllAsync()
    {
        if (_memoryCache.TryGetValue(CategoryListCacheKey, out List<CategoryDto> categoryList))
            return categoryList.AsQueryable();

        var query = await _categoryService.GetAllAsync();

        _memoryCache.Set(CategoryListCacheKey, query.ToList(), cacheOptions);

        return query;
    }

    public async Task<CategoryDto> GetByIdAsync(string id)
    {
        return await _categoryService.GetByIdAsync(id);
    }

    public async Task UpdateAsync(UpdateCategoryDto updateDto)
    {
        await _categoryService.UpdateAsync(updateDto);
        _memoryCache.Remove(CategoryListCacheKey);
    }
}