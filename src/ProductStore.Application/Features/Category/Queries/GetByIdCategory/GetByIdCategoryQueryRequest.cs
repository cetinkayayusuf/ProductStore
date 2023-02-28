using MediatR;

namespace ProductStore.Application.Features.Category.Queries.GetCategoryById;

public class GetCategoryByIdQueryRequest : IRequest<GetCategoryByIdQueryResponse>
{
    public string Id { get; set; }
}