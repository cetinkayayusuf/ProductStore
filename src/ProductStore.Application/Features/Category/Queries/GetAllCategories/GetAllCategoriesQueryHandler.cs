using MediatR;
using ProductStore.Application.Repositories;
using ProductStore.Application.Services;

namespace ProductStore.Application.Features.Category.Queries.GetAllCategories
{
    public class GetAllCategoriesQueryHandler : IRequestHandler<GetAllCategoriesQueryRequest, GetAllCategoriesQueryResponse>
    {
        private readonly ICategoryReadRepository _categoryReadRepository;
        private readonly ICategoryService _categoryService;


        public GetAllCategoriesQueryHandler(ICategoryReadRepository categoryReadRepository, ICategoryService categoryService)
        {
            _categoryReadRepository = categoryReadRepository;
            _categoryService = categoryService;
        }

        public async Task<GetAllCategoriesQueryResponse> Handle(GetAllCategoriesQueryRequest request, CancellationToken cancellationToken)
        {
            // var categoryCount = _categoryReadRepository.GetAll(false).Count();
            // var categories = _categoryReadRepository.GetAll(false)
            //     .Select(c => new
            //     {
            //         c.Id,
            //         c.Name
            //     }).ToList();
            var categories = await _categoryService.GetAllAsync();
            return new()
            {
                Categories = categories,
                CategoryCount = categories.Count()
            };
        }
    }
}