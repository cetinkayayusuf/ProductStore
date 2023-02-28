using AutoMapper;
using MediatR;
using ProductStore.Application.Repositories;
using ProductStore.Application.Services;
using ProductStore.Domain.Entities.Enums;

namespace ProductStore.Application.Features.ProductCollection.Commands.CompleteProductCollection
{
    public class CompleteProductCollectionCommandHandler : IRequestHandler<CompleteProductCollectionCommandRequest, CompleteProductCollectionCommandResponse>
    {
        private readonly IProductCollectionService _productCollectionService;

        public CompleteProductCollectionCommandHandler(IProductCollectionService productCollectionService)
        {
            _productCollectionService = productCollectionService;
        }

        public async Task<CompleteProductCollectionCommandResponse> Handle(CompleteProductCollectionCommandRequest request, CancellationToken cancellationToken)
        {
            await _productCollectionService.CompleteProductCollectionAsync(request.UserId, request.Id);
            return new();
        }
    }
}