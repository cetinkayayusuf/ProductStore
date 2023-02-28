using MediatR;

namespace ProductStore.Application.Features.Category.Commands.DeleteCategory;

public class DeleteCategoryCommandRequest : IRequest<DeleteCategoryCommandResponse>
{
    public string Id { get; set; }
}