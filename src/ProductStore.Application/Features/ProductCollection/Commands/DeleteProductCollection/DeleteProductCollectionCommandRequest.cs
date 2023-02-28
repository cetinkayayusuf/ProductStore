using MediatR;

namespace ProductStore.Application.Features.ProductCollection.Commands.DeleteProductCollection;

public class DeleteProductCollectionCommandRequest : IRequest<DeleteProductCollectionCommandResponse>
{
    public string Id { get; set; }
}