using MediatR;

namespace ProductStore.Application.Features.Product.Commands.UpdateProduct;

public class UpdateProductCommandRequest : IRequest<UpdateProductCommandResponse>
{
    public string Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public List<string>? CategoryIds { get; set; }
}