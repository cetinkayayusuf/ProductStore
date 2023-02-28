
namespace ProductStore.Application.Dto.Product;
public class ProductDetailDto
{
    public string Name { get; set; }
    public string Description { get; set; }
    public ICollection<string> Categories { get; set; }
}