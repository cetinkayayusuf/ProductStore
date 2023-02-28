using MediatR;
using ProductStore.Application.Services;

namespace ProductStore.Application.Features.ProductCollection.Commands.AddProductCollection
{
    public class AddProductCollectionCommandHandler : IRequestHandler<AddProductCollectionCommandRequest, AddProductCollectionCommandResponse>
    {
        private readonly IProductCollectionService _productCollectionService;

        public AddProductCollectionCommandHandler(IProductCollectionService productCollectionService)
        {
            _productCollectionService = productCollectionService;
        }

        public async Task<AddProductCollectionCommandResponse> Handle(AddProductCollectionCommandRequest request, CancellationToken cancellationToken)
        {
            await _productCollectionService.AddProductCollectionAsync(request.UserId, new()
            {
                Name = request.Name,
                Description = request.Description,
                CategoryIds = request.CategoryIds
            });
            return new();
        }
    }
}