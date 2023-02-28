using AutoMapper;
using MediatR;
using ProductStore.Application.Repositories;

namespace ProductStore.Application.Features.Product.Commands.UpdateProduct
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommandRequest, UpdateProductCommandResponse>
    {
        readonly IProductReadRepository _productReadRepository;
        readonly IProductWriteRepository _productWriteRepository;
        private readonly IMapper _mapper;

        public UpdateProductCommandHandler(IProductReadRepository productReadRepository, IProductWriteRepository productWriteRepository, IMapper mapper)
        {
            _productReadRepository = productReadRepository;
            _productWriteRepository = productWriteRepository;
            _mapper = mapper;
        }

        public async Task<UpdateProductCommandResponse> Handle(UpdateProductCommandRequest request, CancellationToken cancellationToken)
        {
            var entity = await _productReadRepository.GetByIdAsync(request.Id);
            entity.Name = request.Name;
            entity.Description = request.Description;
            entity.Categories = (List<Domain.Entities.Category>)request.CategoryIds.Select(categoryId => new Domain.Entities.Category() { Id = Guid.Parse(categoryId) }).ToList();
            await _productWriteRepository.SaveAsync();
            return new();
        }
    }
}