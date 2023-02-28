using MediatR;
using ProductStore.Application.Services;

namespace ProductStore.Application.Features.ProductCollection.Queries.GetAllProductCollections
{
    public class GetAllProductCollectionsQueryHandler : IRequestHandler<GetAllProductCollectionsQueryRequest, GetAllProductCollectionsQueryResponse>
    {
        private readonly IProductCollectionService _productCollectionService;

        public GetAllProductCollectionsQueryHandler(IProductCollectionService productCollectionService)
        {
            _productCollectionService = productCollectionService;
        }

        public async Task<GetAllProductCollectionsQueryResponse> Handle(GetAllProductCollectionsQueryRequest request, CancellationToken cancellationToken)
        {
            var productCollections = await _productCollectionService.GetAllProductCollectionsAsync(request.UserId);
            return new()
            {
                ProductCollections = productCollections,
                ProductCollectionCount = productCollections.Count()
            };
        }
    }
}