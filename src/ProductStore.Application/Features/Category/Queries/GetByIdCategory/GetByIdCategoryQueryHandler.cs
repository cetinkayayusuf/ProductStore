using MediatR;
using ProductStore.Application.Repositories;

namespace ProductStore.Application.Features.Category.Queries.GetCategoryById
{
    public class GetCategoryByIdQueryHandler : IRequestHandler<GetCategoryByIdQueryRequest, GetCategoryByIdQueryResponse>
    {
        private readonly ICategoryReadRepository _categoryReadRepository;

        public GetCategoryByIdQueryHandler(ICategoryReadRepository categoryReadRepository)
        {
            _categoryReadRepository = categoryReadRepository;
        }

        public async Task<GetCategoryByIdQueryResponse> Handle(GetCategoryByIdQueryRequest request, CancellationToken cancellationToken)
        {
            var entity = await _categoryReadRepository.GetByIdAsync(request.Id);
            return new()
            {
                Name = entity.Name,
                Products = entity.Products.Select(p => new
                {
                    p.Id,
                    p.Name
                }).ToList()
            };
        }
    }
}