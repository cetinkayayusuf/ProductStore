using AutoMapper;
using MediatR;
using ProductStore.Application.Repositories;
using ProductStore.Application.Services;

namespace ProductStore.Application.Features.Product.Commands.DeleteProduct
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommandRequest, DeleteProductCommandResponse>
    {
        private readonly IProductWriteRepository _productWriteRepository;
        private readonly IMapper _mapper;

        public DeleteProductCommandHandler(IProductWriteRepository productWriteRepository, IMapper mapper)
        {
            _productWriteRepository = productWriteRepository;
            _mapper = mapper;
        }

        public async Task<DeleteProductCommandResponse> Handle(DeleteProductCommandRequest request, CancellationToken cancellationToken)
        {
            await _productWriteRepository.RemoveAsync(request.Id);
            await _productWriteRepository.SaveAsync();
            return new();
        }
    }
}