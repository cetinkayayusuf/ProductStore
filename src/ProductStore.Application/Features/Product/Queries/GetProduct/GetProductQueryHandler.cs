using AutoMapper;
using MediatR;
using ProductStore.Application.Repositories;

namespace ProductStore.Application.Features.Category.Queries.GetProductById
{
    public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQueryRequest, GetProductByIdQueryResponse>
    {
        private readonly IProductReadRepository _productReadRepository;
        private readonly IMapper _mapper;

        public GetProductByIdQueryHandler(IProductReadRepository productReadRepository, IMapper mapper)
        {
            _productReadRepository = productReadRepository;
            _mapper = mapper;
        }

        public async Task<GetProductByIdQueryResponse> Handle(GetProductByIdQueryRequest request, CancellationToken cancellationToken)
        {
            var productId = new Guid(request.Id);
            var entity = await _productReadRepository.GetAsync(filter: x => x.Id == productId, includeProperties: "Categories");
            var product = entity.ToList()[0];

            return new()
            {
                Product = new
                {
                    product.Id,
                    product.Name,
                    product.Description,
                    categories = product.Categories.Select(c => new
                    {
                        c.Id,
                        c.Name
                    }).ToList()
                }
            };
        }
    }
}