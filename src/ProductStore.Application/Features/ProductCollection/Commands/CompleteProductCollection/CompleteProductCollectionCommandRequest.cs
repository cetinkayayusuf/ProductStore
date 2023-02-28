using MediatR;

namespace ProductStore.Application.Features.ProductCollection.Commands.CompleteProductCollection;

public class CompleteProductCollectionCommandRequest : IRequest<CompleteProductCollectionCommandResponse>
{
    public string? UserId { get; set; }
    public string Id { get; set; }
}