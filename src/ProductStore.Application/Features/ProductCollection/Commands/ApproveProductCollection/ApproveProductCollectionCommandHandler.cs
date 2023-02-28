using AutoMapper;
using MediatR;
using ProductStore.Application.Repositories;
using ProductStore.Domain.Entities.Enums;

namespace ProductStore.Application.Features.ProductCollection.Commands.ApproveProductCollection
{
    public class ApproveProductCollectionCommandHandler : IRequestHandler<ApproveProductCollectionCommandRequest, ApproveProductCollectionCommandResponse>
    {
        readonly IProductCollectionReadRepository _productCollectionReadRepository;
        readonly IProductCollectionWriteRepository _productCollectionWriteRepository;
        private readonly IMapper _mapper;

        public ApproveProductCollectionCommandHandler(IProductCollectionReadRepository productCollectionReadRepository, IProductCollectionWriteRepository productCollectionWriteRepository, IMapper mapper)
        {
            _productCollectionReadRepository = productCollectionReadRepository;
            _productCollectionWriteRepository = productCollectionWriteRepository;
            _mapper = mapper;
        }

        public async Task<ApproveProductCollectionCommandResponse> Handle(ApproveProductCollectionCommandRequest request, CancellationToken cancellationToken)
        {
            var entity = await _productCollectionReadRepository.GetByIdAsync(request.Id);
            entity.Status = ProductCollectionStatus.Approved;
            await _productCollectionWriteRepository.SaveAsync();
            return new();
        }
    }
}