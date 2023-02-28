using ProductStore.Application.Dto.Product;

namespace ProductStore.Application.Features.Category.Queries.GetProductById;

public class GetProductByIdQueryResponse
{
    public string Name { get; set; }
    public string Description { get; set; }
    public object Categories { get; set; }
}
