using MediatR;
using ProductStore.Application.Repositories;
using ProductStore.Application.Services;

namespace ProductStore.Application.Features.Category.Queries.GetCategoryById
{
    public class GetCategoryByIdQueryHandler : IRequestHandler<GetCategoryByIdQueryRequest, GetCategoryByIdQueryResponse>
    {
        private readonly ICategoryReadRepository _categoryReadRepository;
        private readonly ICategoryService _categoryService;


        public GetCategoryByIdQueryHandler(ICategoryReadRepository categoryReadRepository, ICategoryService categoryService)
        {
            _categoryReadRepository = categoryReadRepository;
            _categoryService = categoryService;
        }

        public async Task<GetCategoryByIdQueryResponse> Handle(GetCategoryByIdQueryRequest request, CancellationToken cancellationToken)
        {
            var categoryId = new Guid(request.Id);
            var entity = await _categoryReadRepository.GetAsync(filter: x => x.Id == categoryId, includeProperties: "Products");
            var category = entity.ToList()[0];

            return new()
            {
                Category = new
                {
                    category.Id,
                    category.Name,
                    products = category.Products.Select(p => new
                    {
                        p.Id,
                        p.Name
                    }).ToList()
                }
            };
        }
    }
}