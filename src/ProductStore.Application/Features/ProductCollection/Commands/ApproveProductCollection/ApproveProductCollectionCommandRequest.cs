using MediatR;

namespace ProductStore.Application.Features.ProductCollection.Commands.ApproveProductCollection;

public class ApproveProductCollectionCommandRequest : IRequest<ApproveProductCollectionCommandResponse>
{
    public string Id { get; set; }
}