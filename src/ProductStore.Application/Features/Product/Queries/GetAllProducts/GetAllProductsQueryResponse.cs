using ProductStore.Application.Dto.Product;

namespace ProductStore.Application.Features.Product.Queries.GetAllProducts;

public class GetAllProductsQueryResponse
{
    public object Products { get; set; }
    public int ProductCount { get; set; }
}
