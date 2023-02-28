
using ProductStore.Domain.Entities.Enums;

namespace ProductStore.Application.Dto.ProductCollection;
public class UpdateProductCollectionDto
{
    public string Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public List<string>? CategoryIds { get; set; }
}