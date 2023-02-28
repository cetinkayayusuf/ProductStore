using MediatR;

namespace ProductStore.Application.Features.ProductCollection.Queries.GetByIdProductCollection;

public class GetProductCollectionByIdQueryRequest : IRequest<GetProductCollectionByIdQueryResponse>
{
    public string? UserId { get; set; }
    public string Id { get; set; }
}