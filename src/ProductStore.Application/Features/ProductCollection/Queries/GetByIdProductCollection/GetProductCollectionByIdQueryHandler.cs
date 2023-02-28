using AutoMapper;
using MediatR;
using ProductStore.Application.Services;

namespace ProductStore.Application.Features.ProductCollection.Queries.GetByIdProductCollection
{
    public class GetProductCollectionByIdQueryHandler : IRequestHandler<GetProductCollectionByIdQueryRequest, GetProductCollectionByIdQueryResponse>
    {
        private readonly IProductCollectionService _productCollectionService;

        public GetProductCollectionByIdQueryHandler(IProductCollectionService productCollectionService)
        {
            _productCollectionService = productCollectionService;
        }

        public async Task<GetProductCollectionByIdQueryResponse> Handle(GetProductCollectionByIdQueryRequest request, CancellationToken cancellationToken)
        {
            var collection = await _productCollectionService.GetProductCollectionAsync(request.UserId, request.Id);

            return new()
            {
                ProductCollection = collection
            };
        }
    }
}