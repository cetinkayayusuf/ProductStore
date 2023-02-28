using MediatR;

namespace ProductStore.Application.Features.Category.Commands.AddCategory;

public class AddCategoryCommandRequest : IRequest<AddCategoryCommandResponse>
{
    public string Name { get; set; }
}