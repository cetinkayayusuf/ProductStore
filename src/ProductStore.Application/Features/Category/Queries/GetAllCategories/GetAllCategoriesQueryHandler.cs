using MediatR;
using ProductStore.Application.Repositories;

namespace ProductStore.Application.Features.Category.Queries.GetAllCategories
{
    public class GetAllCategoriesQueryHandler : IRequestHandler<GetAllCategoriesQueryRequest, GetAllCategoriesQueryResponse>
    {
        private readonly ICategoryReadRepository _categoryReadRepository;

        public GetAllCategoriesQueryHandler(ICategoryReadRepository categoryReadRepository)
        {
            _categoryReadRepository = categoryReadRepository;
        }

        public async Task<GetAllCategoriesQueryResponse> Handle(GetAllCategoriesQueryRequest request, CancellationToken cancellationToken)
        {
            var categoryCount = _categoryReadRepository.GetAll(false).Count();
            var categories = _categoryReadRepository.GetAll(false)
                .Select(c => new
                {
                    c.Id,
                    c.Name
                }).ToList();

            return new()
            {
                Categories = categories,
                CategoryCount = categoryCount
            };
        }
    }
}