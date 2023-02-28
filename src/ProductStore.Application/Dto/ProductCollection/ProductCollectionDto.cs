
namespace ProductStore.Application.Dto.ProductCollection;
public class ProductCollectionDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Status { get; set; }
    public int ProductCount { get; set; }
}