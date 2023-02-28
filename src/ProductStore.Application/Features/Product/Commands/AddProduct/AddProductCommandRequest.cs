using MediatR;

namespace ProductStore.Application.Features.Product.Commands.AddProduct;

public class AddProductCommandRequest : IRequest<AddProductCommandResponse>
{
    public string Name { get; set; }
    public string Description { get; set; }
    public List<string> CategoryIds { get; set; }
}