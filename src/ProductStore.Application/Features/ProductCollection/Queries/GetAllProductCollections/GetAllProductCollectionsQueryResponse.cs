using ProductStore.Application.Dto.Product;

namespace ProductStore.Application.Features.Product.Queries.GetAllProducts;

public class GetAllProductCollectionsQueryResponse
{
    public object Products { get; set; }
    public int ProductCount { get; set; }
}
