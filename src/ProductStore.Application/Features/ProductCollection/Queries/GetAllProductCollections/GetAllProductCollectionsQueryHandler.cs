using AutoMapper;
using MediatR;
using ProductStore.Application.Repositories;
using ProductStore.Application.RequestParams;
using ProductStore.Domain.Entities;

namespace ProductStore.Application.Features.Product.Queries.GetAllProducts
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
            var entityCount = _productCollectionReadRepository.GetAll(false).Count();
            var entities = _productCollectionReadRepository.GetAsync(
                orderBy: p => p.OrderBy(p => typeof(ProductCollection).GetProperty(request.OrderBy).GetValue(p, null)),
                page: request.Pagination.Page,
                pageSize: request.Pagination.Size
            );
            return new()
            {
                Products = entities,
                ProductCount = entityCount
            };
        }
    }
}