using AutoMapper;
using MediatR;
using ProductStore.Application.Repositories;
using ProductStore.Domain.Entities.Enums;

namespace ProductStore.Application.Features.ProductCollection.Commands.RejectProductCollection
{
    public class RejectProductCollectionCommandHandler : IRequestHandler<RejectProductCollectionCommandRequest, RejectProductCollectionCommandResponse>
    {
        readonly IProductCollectionReadRepository _productCollectionReadRepository;
        readonly IProductCollectionWriteRepository _productCollectionWriteRepository;
        private readonly IMapper _mapper;

        public RejectProductCollectionCommandHandler(IProductCollectionReadRepository productCollectionReadRepository, IProductCollectionWriteRepository productCollectionWriteRepository, IMapper mapper)
        {
            _productCollectionReadRepository = productCollectionReadRepository;
            _productCollectionWriteRepository = productCollectionWriteRepository;
            _mapper = mapper;
        }

        public async Task<RejectProductCollectionCommandResponse> Handle(RejectProductCollectionCommandRequest request, CancellationToken cancellationToken)
        {
            var entity = await _productCollectionReadRepository.GetByIdAsync(request.Id);
            entity.Status = ProductCollectionStatus.Rejected;
            await _productCollectionWriteRepository.SaveAsync();
            return new();
        }
    }
}