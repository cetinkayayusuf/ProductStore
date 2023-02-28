using ProductStore.Application.Dto.Product;

namespace ProductStore.Application.Features.ProductCollection.Queries.GetAllProductCollections;

public class GetAllProductCollectionsQueryResponse
{
    public object ProductCollections { get; set; }
    public int ProductCollectionCount { get; set; }
}
