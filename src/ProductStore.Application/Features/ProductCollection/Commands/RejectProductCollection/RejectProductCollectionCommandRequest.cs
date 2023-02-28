using MediatR;

namespace ProductStore.Application.Features.ProductCollection.Commands.RejectProductCollection;

public class RejectProductCollectionCommandRequest : IRequest<RejectProductCollectionCommandResponse>
{
    public string Id { get; set; }
}