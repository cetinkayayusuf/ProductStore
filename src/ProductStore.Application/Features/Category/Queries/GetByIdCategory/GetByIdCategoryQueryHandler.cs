using MediatR;
using ProductStore.Application.Repositories;
using ProductStore.Application.Services;

namespace ProductStore.Application.Features.Category.Queries.GetCategoryById
{
    public class GetCategoryByIdQueryHandler : IRequestHandler<GetCategoryByIdQueryRequest, GetCategoryByIdQueryResponse>
    {
        private readonly ICategoryReadRepository _categoryReadRepository;
        private readonly IProductReadRepository _productReadRepository;

        private readonly ICategoryService _categoryService;


        public GetCategoryByIdQueryHandler(ICategoryReadRepository categoryReadRepository, ICategoryService categoryService, IProductReadRepository productReadRepository)
        {
            _categoryReadRepository = categoryReadRepository;
            _categoryService = categoryService;
            _productReadRepository = productReadRepository;
        }

        public async Task<GetCategoryByIdQueryResponse> Handle(GetCategoryByIdQueryRequest request, CancellationToken cancellationToken)
        {
            // var entity = await _categoryReadRepository.GetByIdAsync(request.Id, false);
            var entity = await _categoryService.GetByIdAsync(request.Id);
            return new()
            {
                Name = entity.Name,
                // Products = entity.Products.Select(p => new
                // {
                //     p.Id,
                //     p.Name
                // }).ToList()
            };
        }
    }
}