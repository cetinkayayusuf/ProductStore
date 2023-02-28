
using ProductStore.Application.Dto.ProductCollection;
using ProductStore.Application.Exceptions;
using ProductStore.Application.Repositories;
using ProductStore.Application.Services;
using ProductStore.Domain.Entities.Enums;

namespace ProductStore.Persistance.Services;

public class ProductCollectionService : IProductCollectionService
{
    private readonly IProductCollectionReadRepository _productCollectionReadRepository;
    private readonly IProductCollectionWriteRepository _productCollectionWriteRepository;
    private readonly ICategoryReadRepository _categoryReadRepository;
    private readonly INotificationWriteRepository _notificationWriteRepository;


    public ProductCollectionService(IProductCollectionWriteRepository productCollectionWriteRepository, IProductCollectionReadRepository productCollectionReadRepository, ICategoryReadRepository categoryReadRepository, INotificationWriteRepository notificationWriteRepository)
    {
        _productCollectionWriteRepository = productCollectionWriteRepository;
        _productCollectionReadRepository = productCollectionReadRepository;
        _categoryReadRepository = categoryReadRepository;
        _notificationWriteRepository = notificationWriteRepository;
    }

    public async Task AddProductCollectionAsync(string ownerId, AddProductCollectionDto addDto)
    {
        var categories = _categoryReadRepository.GetWhere(x => addDto.CategoryIds.Contains(x.Id.ToString())).ToList();
        await _productCollectionWriteRepository.AddAsync(new()
        {
            CreatorId = ownerId,
            Name = addDto.Name,
            Description = addDto.Description,
            Categories = categories
        });
        await _productCollectionWriteRepository.SaveAsync();
    }

    public async Task UpdateProductCollectionAsync(string ownerId, UpdateProductCollectionDto updateDto)
    {
        var entity = await _productCollectionReadRepository.GetByIdAsync(updateDto.Id);
        if (entity.CreatorId != ownerId && ownerId != "")
            throw new NotOwnedResourceAccessException();
        entity.Name = string.IsNullOrEmpty(updateDto.Name) ? updateDto.Name : entity.Name;
        entity.Description = string.IsNullOrEmpty(updateDto.Description) ? updateDto.Description : entity.Description;
        entity.Categories = updateDto.CategoryIds == default ? entity.Categories : (List<Domain.Entities.Category>)updateDto.CategoryIds.Select(categoryId => new Domain.Entities.Category() { Id = Guid.Parse(categoryId) }).ToList();
        await _productCollectionWriteRepository.SaveAsync();
    }

    public async Task DeleteProductCollectionAsync(string ownerId, string id)
    {
        var entity = await _productCollectionReadRepository.GetByIdAsync(id);
        if (entity == default)
            throw new ResourceNotFoundException();
        if (entity.CreatorId != ownerId && ownerId != "")
            throw new NotOwnedResourceAccessException();
        await _productCollectionWriteRepository.RemoveAsync(id);
        await _productCollectionWriteRepository.SaveAsync();
    }

    public async Task<List<ProductCollectionDto>> GetAllProductCollectionsAsync(string ownerId)
    {
        var entities = await _productCollectionReadRepository.GetAsync(filter: x => x.CreatorId == ownerId || ownerId == "", includeProperties: "Categories.Products");

        var productCollections = entities.Select(collection => new ProductCollectionDto()
        {
            Id = collection.Id,
            Name = collection.Name,
            Description = collection.Description,
            Status = Enum.GetName(collection.Status),
            ProductCount = collection.Categories.Select(c => c.Products.Select(p => new { p.Id, p.Name })).Count(),
        });
        return productCollections.ToList();
    }

    public async Task<ProductCollectionDetailDto> GetProductCollectionAsync(string ownerId, string id)
    {
        var collectionId = new Guid(id);
        var entity = await _productCollectionReadRepository.GetAsync(filter: x => (x.CreatorId == ownerId || ownerId == "") && x.Id == collectionId, includeProperties: "Categories.Products");
        var collection = entity.ToList()[0];
        return new ProductCollectionDetailDto
        {
            Id = collection.Id,
            Name = collection.Name,
            Description = collection.Description,
            Status = Enum.GetName(collection.Status),
            Categories = collection.Categories.Select(c => new { c.Id, c.Name }),
            Products = collection.Categories.SelectMany(c => c.Products.Select(p => new { p.Id, p.Name })),
        };
    }

    public async Task CompleteProductCollectionAsync(string ownerId, string id)
    {
        var entity = await _productCollectionReadRepository.GetByIdAsync(id);
        if (entity == default)
            throw new ResourceNotFoundException();
        if (entity.CreatorId != ownerId && ownerId != "")
            throw new NotOwnedResourceAccessException();

        entity.Status = ProductCollectionStatus.Pending;
        await _productCollectionWriteRepository.SaveAsync();
    }

    public async Task ApproveProductCollectionAsync(string ownerId, string id)
    {
        var entity = await _productCollectionReadRepository.GetByIdAsync(id);
        if (entity == default)
            throw new ResourceNotFoundException();
        if (entity.CreatorId != ownerId && ownerId != "")
            throw new NotOwnedResourceAccessException();

        entity.Status = ProductCollectionStatus.Approved;
        await _productCollectionWriteRepository.SaveAsync();
        await _notificationWriteRepository.AddAsync(new()
        {
            Message = "Product collection completed!",
            Type = NotificationType.ProductCollectionCompleted,
            ReferenceId = entity.Id.ToString()
        });
        await _notificationWriteRepository.SaveAsync();
    }

    public async Task RejectProductCollectionAsync(string ownerId, string id)
    {
        var entity = await _productCollectionReadRepository.GetByIdAsync(id);
        if (entity == default)
            throw new ResourceNotFoundException();
        if (entity.CreatorId != ownerId && ownerId != "")
            throw new NotOwnedResourceAccessException();

        entity.Status = ProductCollectionStatus.Rejected;
        await _productCollectionWriteRepository.SaveAsync();
    }
}