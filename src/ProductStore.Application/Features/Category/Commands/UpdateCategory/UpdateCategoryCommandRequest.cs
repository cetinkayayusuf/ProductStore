using MediatR;

namespace ProductStore.Application.Features.Category.Commands.UpdateCategory;

public class UpdateCategoryCommandRequest : IRequest<UpdateCategoryCommandResponse>
{
    public string Id { get; set; }
    public string Name { get; set; }
}