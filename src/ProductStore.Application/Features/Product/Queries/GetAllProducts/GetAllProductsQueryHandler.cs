using AutoMapper;
using MediatR;
using ProductStore.Application.Repositories;

namespace ProductStore.Application.Features.Product.Queries.GetAllProducts
{
    public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQueryRequest, GetAllProductsQueryResponse>
    {
        private readonly IProductReadRepository _productReadRepository;
        private readonly IMapper _mapper;

        public GetAllProductsQueryHandler(IProductReadRepository productReadRepository, IMapper mapper)
        {
            _productReadRepository = productReadRepository;
            _mapper = mapper;
        }

        public async Task<GetAllProductsQueryResponse> Handle(GetAllProductsQueryRequest request, CancellationToken cancellationToken)
        {
            var entities = await _productReadRepository.GetAsync(includeProperties: "Categories");
            var entityCount = entities.Count();

            var products = entities.Select(product => new
            {
                product.Id,
                product.Name,
                Categories = product.Categories.Select(c => c.Name),
            });
            return new()
            {
                Products = products,
                ProductCount = entityCount
            };
        }
    }
}