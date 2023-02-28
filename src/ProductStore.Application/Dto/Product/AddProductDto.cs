
namespace ProductStore.Application.Dto.Product;
public class AddProductDto
{
    public string Name { get; set; }
    public string Description { get; set; }
    public List<int> CategoryIds { get; set; }
}