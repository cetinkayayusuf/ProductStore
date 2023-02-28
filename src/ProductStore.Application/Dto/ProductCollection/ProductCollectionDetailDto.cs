
namespace ProductStore.Application.Dto.ProductCollection;
public class ProductCollectionDetailDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Status { get; set; }
    public object Categories { get; set; }
    public object Products { get; set; }

}