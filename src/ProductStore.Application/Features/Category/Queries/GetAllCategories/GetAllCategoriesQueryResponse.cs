using ProductStore.Application.Dto.Category;

namespace ProductStore.Application.Features.Category.Queries.GetAllCategories;

public class GetAllCategoriesQueryResponse
{
    public object Categories { get; set; }
    public int CategoryCount { get; set; }
}
