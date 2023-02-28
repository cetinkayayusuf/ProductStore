using MediatR;

namespace ProductStore.Application.Features.Category.Queries.GetProductById;

public class GetProductCollectionByIdQueryRequest : IRequest<GetProductCollectionByIdQueryResponse>
{
    public string Id { get; set; }
}