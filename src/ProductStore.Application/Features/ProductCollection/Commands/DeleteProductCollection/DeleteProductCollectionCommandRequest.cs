using MediatR;

namespace ProductStore.Application.Features.Product.Commands.DeleteProduct;

public class DeleteProductCollectionCommandRequest : IRequest<DeleteProductCollectionCommandResponse>
{
    public string Id { get; set; }
}