using MediatR;

namespace ProductStore.Application.Features.ProductCollection.Queries.GetByIdProductCollection;

public class GetProductCollectionByIdQueryRequest : IRequest<GetProductCollectionByIdQueryResponse>
{
    public string Id { get; set; }
}