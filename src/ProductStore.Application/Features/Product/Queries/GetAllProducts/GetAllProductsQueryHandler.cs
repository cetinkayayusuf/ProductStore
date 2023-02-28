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
            var entityCount = _productReadRepository.GetAll(false).Count();
            var entities = _productReadRepository.GetAll(false)
                .Select(c => new
                {
                    c.Id,
                    c.Name
                }).ToList();

            return new()
            {
                Products = entities,
                ProductCount = entityCount
            };
        }
    }
}