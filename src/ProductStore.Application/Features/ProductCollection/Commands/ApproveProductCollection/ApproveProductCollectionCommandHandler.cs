using AutoMapper;
using MediatR;
using ProductStore.Application.Repositories;
using ProductStore.Application.Services;
using ProductStore.Domain.Entities.Enums;

namespace ProductStore.Application.Features.ProductCollection.Commands.ApproveProductCollection
{
    public class ApproveProductCollectionCommandHandler : IRequestHandler<ApproveProductCollectionCommandRequest, ApproveProductCollectionCommandResponse>
    {
        private readonly IProductCollectionService _productCollectionService;

        public ApproveProductCollectionCommandHandler(IProductCollectionService productCollectionService)
        {
            _productCollectionService = productCollectionService;
        }

        public async Task<ApproveProductCollectionCommandResponse> Handle(ApproveProductCollectionCommandRequest request, CancellationToken cancellationToken)
        {
            await _productCollectionService.ApproveProductCollectionAsync(request.UserId, request.Id);
            return new();
        }
    }
}