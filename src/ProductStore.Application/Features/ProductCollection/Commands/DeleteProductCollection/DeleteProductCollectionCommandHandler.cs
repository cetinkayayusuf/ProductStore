using AutoMapper;
using MediatR;
using ProductStore.Application.Repositories;

namespace ProductStore.Application.Features.ProductCollection.Commands.DeleteProductCollection
{
    public class DeleteProductCollectionCommandHandler : IRequestHandler<DeleteProductCollectionCommandRequest, DeleteProductCollectionCommandResponse>
    {
        private readonly IProductCollectionWriteRepository _productCollectionWriteRepository;
        private readonly IMapper _mapper;

        public DeleteProductCollectionCommandHandler(IProductCollectionWriteRepository productCollectionWriteRepository, IMapper mapper)
        {
            _productCollectionWriteRepository = productCollectionWriteRepository;
            _mapper = mapper;
        }

        public async Task<DeleteProductCollectionCommandResponse> Handle(DeleteProductCollectionCommandRequest request, CancellationToken cancellationToken)
        {
            await _productCollectionWriteRepository.RemoveAsync(request.Id);
            await _productCollectionWriteRepository.SaveAsync();
            return new();
        }
    }
}