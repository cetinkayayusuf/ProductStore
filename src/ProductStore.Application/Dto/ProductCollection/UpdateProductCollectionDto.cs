
using ProductStore.Domain.Entities.Enums;

namespace ProductStore.Application.Dto.ProductCollection;
public class UpdateProductCollectionDto
{
    public string? Name { get; set; }
    public string? Description { get; set; }
    public ICollection<int>? CategoryIds { get; set; }
    public ProductCollectionStatus? Status { get; set; }
}