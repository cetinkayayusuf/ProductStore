using AutoMapper;
using MediatR;
using ProductStore.Application.Repositories;
using ProductStore.Application.Services;

namespace ProductStore.Application.Features.ProductCollection.Commands.DeleteProductCollection
{
    public class DeleteProductCollectionCommandHandler : IRequestHandler<DeleteProductCollectionCommandRequest, DeleteProductCollectionCommandResponse>
    {
        private readonly IProductCollectionService _productCollectionService;

        public DeleteProductCollectionCommandHandler(IProductCollectionService productCollectionService)
        {
            _productCollectionService = productCollectionService;
        }

        public async Task<DeleteProductCollectionCommandResponse> Handle(DeleteProductCollectionCommandRequest request, CancellationToken cancellationToken)
        {
            await _productCollectionService.DeleteProductCollectionAsync(request.UserId, request.Id);
            return new();
        }
    }
}