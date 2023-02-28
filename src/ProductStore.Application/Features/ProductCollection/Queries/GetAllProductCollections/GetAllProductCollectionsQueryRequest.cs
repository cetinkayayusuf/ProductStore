using MediatR;
using ProductStore.Application.RequestParams;

namespace ProductStore.Application.Features.Product.Queries.GetAllProducts;

public class GetAllProductCollectionsQueryRequest : IRequest<GetAllProductCollectionsQueryResponse>
{
    public Pagination Pagination { get; set; }
    public String SearchParameter { get; set; }

    public String OrderBy { get; set; }
    public String FilterByCategory { get; set; }
    public String FilterByCreatedDate { get; set; }
    public String FilterByCompletedDate { get; set; }
}