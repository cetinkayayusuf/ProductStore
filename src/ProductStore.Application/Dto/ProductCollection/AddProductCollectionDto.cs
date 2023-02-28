
namespace ProductStore.Application.Dto.ProductCollection;
public class AddProductCollectionDto
{
    public string Name { get; set; }
    public string Description { get; set; }
    public List<string> CategoryIds { get; set; }
}