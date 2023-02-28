
namespace ProductStore.Application.Dto.Product;
public class UpdateProductDto
{
    public string? Name { get; set; }
    public string? Description { get; set; }
    public ICollection<int>? CategoryIds { get; set; }
}