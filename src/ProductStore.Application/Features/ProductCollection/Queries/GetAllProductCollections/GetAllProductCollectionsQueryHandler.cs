using AutoMapper;
using MediatR;
using ProductStore.Application.Repositories;
using ProductStore.Application.RequestParams;
using ProductStore.Domain.Entities;
using ProductStore.Domain.Entities.Enums;

namespace ProductStore.Application.Features.ProductCollection.Queries.GetAllProductCollections
{
    public class GetAllProductCollectionsQueryHandler : IRequestHandler<GetAllProductCollectionsQueryRequest, GetAllProductCollectionsQueryResponse>
    {
        private readonly IProductCollectionReadRepository _productCollectionReadRepository;
        private readonly IMapper _mapper;

        public GetAllProductCollectionsQueryHandler(IProductCollectionReadRepository productCollectionReadRepository, IMapper mapper)
        {
            _productCollectionReadRepository = productCollectionReadRepository;
            _mapper = mapper;
        }

        public async Task<GetAllProductCollectionsQueryResponse> Handle(GetAllProductCollectionsQueryRequest request, CancellationToken cancellationToken)
        {
            var entities = await _productCollectionReadRepository.GetAsync(includeProperties: "Categories.Products");
            var entityCount = entities.Count();

            var productCollections = entities.Select(collection => new
            {
                collection.Id,
                collection.Name,
                collection.Description,
                status = Enum.GetName(collection.Status),
                productCount = collection.Categories.Select(c => c.Products.Select(p => new { p.Id, p.Name })).Count(),
            });
            return new()
            {
                ProductCollections = productCollections,
                ProductCollectionCount = entityCount
            };
        }
    }
}