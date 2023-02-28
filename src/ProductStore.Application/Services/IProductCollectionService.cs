
using ProductStore.Application.Dto.ProductCollection;

namespace ProductStore.Application.Services;

public interface IProductCollectionService
{
    Task<List<ProductCollectionDto>> GetAllProductCollectionsAsync(string ownerId);

    Task<ProductCollectionDetailDto> GetProductCollectionAsync(string ownerId, string id);

    Task AddProductCollectionAsync(string ownerId, AddProductCollectionDto addDto);
    Task UpdateProductCollectionAsync(string ownerId, UpdateProductCollectionDto updateDto);
    Task DeleteProductCollectionAsync(string ownerId, string id);
    Task CompleteProductCollectionAsync(string ownerId, string id);
    Task ApproveProductCollectionAsync(string ownerId, string id);
    Task RejectProductCollectionAsync(string ownerId, string id);
}