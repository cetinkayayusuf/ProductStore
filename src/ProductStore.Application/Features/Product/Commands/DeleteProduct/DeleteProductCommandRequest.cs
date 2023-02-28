using MediatR;

namespace ProductStore.Application.Features.Product.Commands.DeleteProduct;

public class DeleteProductCommandRequest : IRequest<DeleteProductCommandResponse>
{
    public string Id { get; set; }
}