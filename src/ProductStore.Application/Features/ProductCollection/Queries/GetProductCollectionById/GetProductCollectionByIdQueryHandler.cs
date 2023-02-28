using AutoMapper;
using MediatR;
using ProductStore.Application.Repositories;

namespace ProductStore.Application.Features.Category.Queries.GetProductById
{
    public class GetProductCollectionByIdQueryHandler : IRequestHandler<GetProductCollectionByIdQueryRequest, GetProductCollectionByIdQueryResponse>
    {
        private readonly IProductReadRepository _productReadRepository;
        private readonly IMapper _mapper;

        public GetProductCollectionByIdQueryHandler(IProductReadRepository productReadRepository, IMapper mapper)
        {
            _productReadRepository = productReadRepository;
            _mapper = mapper;
        }

        public async Task<GetProductCollectionByIdQueryResponse> Handle(GetProductCollectionByIdQueryRequest request, CancellationToken cancellationToken)
        {
            var entity = await _productReadRepository.GetByIdAsync(request.Id);
            return new()
            {
                Name = entity.Name,
                Description = entity.Description,
                Categories = entity.Categories.Select(c => new
                {
                    c.Id,
                    c.Name
                }).ToList()
            };
        }
    }
}