using MediatR;

namespace ProductStore.Application.Features.ProductCollection.Commands.ApproveProductCollection;

public class ApproveProductCollectionCommandRequest : IRequest<ApproveProductCollectionCommandResponse>
{
    public string? UserId { get; set; }
    public string Id { get; set; }
}