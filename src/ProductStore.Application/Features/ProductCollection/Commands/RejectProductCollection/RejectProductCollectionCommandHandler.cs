using AutoMapper;
using MediatR;
using ProductStore.Application.Repositories;
using ProductStore.Application.Services;
using ProductStore.Domain.Entities.Enums;

namespace ProductStore.Application.Features.ProductCollection.Commands.RejectProductCollection
{
    public class RejectProductCollectionCommandHandler : IRequestHandler<RejectProductCollectionCommandRequest, RejectProductCollectionCommandResponse>
    {
        private readonly IProductCollectionService _productCollectionService;

        public RejectProductCollectionCommandHandler(IProductCollectionService productCollectionService)
        {
            _productCollectionService = productCollectionService;
        }

        public async Task<RejectProductCollectionCommandResponse> Handle(RejectProductCollectionCommandRequest request, CancellationToken cancellationToken)
        {
            await _productCollectionService.RejectProductCollectionAsync(request.UserId, request.Id);
            return new();
        }
    }
}