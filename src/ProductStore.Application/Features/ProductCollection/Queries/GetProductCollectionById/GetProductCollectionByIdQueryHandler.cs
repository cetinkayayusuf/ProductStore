using AutoMapper;
using MediatR;
using ProductStore.Application.Repositories;

namespace ProductStore.Application.Features.ProductCollection.Queries.GetByIdProductCollection
{
    public class GetProductCollectionByIdQueryHandler : IRequestHandler<GetProductCollectionByIdQueryRequest, GetProductCollectionByIdQueryResponse>
    {
        private readonly IProductCollectionReadRepository _productCollectionReadRepository;
        private readonly IMapper _mapper;

        public GetProductCollectionByIdQueryHandler(IProductCollectionReadRepository productCollectionReadRepository, IMapper mapper)
        {
            _productCollectionReadRepository = productCollectionReadRepository;
            _mapper = mapper;
        }

        public async Task<GetProductCollectionByIdQueryResponse> Handle(GetProductCollectionByIdQueryRequest request, CancellationToken cancellationToken)
        {
            // var entity = await _productCollectionReadRepository.GetByIdAsync(request.Id);
            var collectionId = new Guid(request.Id);
            var entity = await _productCollectionReadRepository.GetAsync(filter: x => x.Id == collectionId, includeProperties: "Categories.Products");
            var collection = entity.ToList()[0];
            var productCollections = entity.Select(collection => new
            {
                collection.Name,
                collection.Description,
                satatus = Enum.GetName(collection.Status),
                categories = collection.Categories.Select(c => new { c.Id, c.Name }),
                products = collection.Categories.Select(c => c.Products.Select(p => new { p.Id, p.Name })),
            });
            return new()
            {
                ProductCollection = new
                {
                    collection.Id,
                    collection.Name,
                    collection.Description,
                    status = Enum.GetName(collection.Status),
                    categories = collection.Categories.Select(c => new { c.Id, c.Name }),
                    products = collection.Categories.SelectMany(c => c.Products.Select(p => new { p.Id, p.Name })),
                }
            };
        }
    }
}