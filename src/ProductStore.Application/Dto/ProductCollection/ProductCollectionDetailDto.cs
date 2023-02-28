
namespace ProductStore.Application.Dto.ProductCollection;
public class ProductCollectionDetailDto
{
    public string Name { get; set; }
    public string Description { get; set; }
    public ICollection<string> Categories { get; set; }
    public string Status { get; set; }
}