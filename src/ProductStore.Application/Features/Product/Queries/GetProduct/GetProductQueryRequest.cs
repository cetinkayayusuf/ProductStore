using MediatR;

namespace ProductStore.Application.Features.Category.Queries.GetProductById;

public class GetProductByIdQueryRequest : IRequest<GetProductByIdQueryResponse>
{
    public string Id { get; set; }
}