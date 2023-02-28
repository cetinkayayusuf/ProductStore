using MediatR;

namespace ProductStore.Application.Features.ProductCollection.Commands.DeleteProductCollection;

public class DeleteProductCollectionCommandRequest : IRequest<DeleteProductCollectionCommandResponse>
{
    public string? UserId { get; set; }
    public string Id { get; set; }
}