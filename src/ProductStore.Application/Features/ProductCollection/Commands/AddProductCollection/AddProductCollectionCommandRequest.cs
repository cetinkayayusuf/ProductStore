using MediatR;

namespace ProductStore.Application.Features.Product.Commands.AddProduct;

public class AddProductCollectionCommandRequest : IRequest<AddProductCollectionCommandResponse>
{
    public string Name { get; set; }
    public string Description { get; set; }
    public List<string> CategoryIds { get; set; }
}