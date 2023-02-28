using MediatR;

namespace ProductStore.Application.Features.Product.Queries.GetAllProducts;

public class GetAllProductsQueryRequest : IRequest<GetAllProductsQueryResponse>
{
}