using MediatR;
using ProductStore.Application.Services;

namespace ProductStore.Application.Features.ProductCollection.Commands.UpdateProductCollection
{
    public class UpdateProductCollectionCommandHandler : IRequestHandler<UpdateProductCollectionCommandRequest, UpdateProductCollectionCommandResponse>
    {
        private readonly IProductCollectionService _productCollectionService;

        public UpdateProductCollectionCommandHandler(IProductCollectionService productCollectionService)
        {
            _productCollectionService = productCollectionService;
        }

        public async Task<UpdateProductCollectionCommandResponse> Handle(UpdateProductCollectionCommandRequest request, CancellationToken cancellationToken)
        {
            await _productCollectionService.UpdateProductCollectionAsync(request.UserId, new()
            {
                Name = request.Name,
                Description = request.Description,
                CategoryIds = request.CategoryIds
            });
            return new();
        }
    }
}