using AutoMapper;
using MediatR;
using ProductStore.Application.Repositories;

namespace ProductStore.Application.Features.ProductCollection.Commands.UpdateProductCollection
{
    public class UpdateProductCollectionCommandHandler : IRequestHandler<UpdateProductCollectionCommandRequest, UpdateProductCollectionCommandResponse>
    {
        readonly IProductCollectionReadRepository _productCollectionReadRepository;
        readonly IProductCollectionWriteRepository _productCollectionWriteRepository;
        private readonly IMapper _mapper;

        public UpdateProductCollectionCommandHandler(IProductCollectionReadRepository productCollectionReadRepository, IProductCollectionWriteRepository productCollectionWriteRepository, IMapper mapper)
        {
            _productCollectionReadRepository = productCollectionReadRepository;
            _productCollectionWriteRepository = productCollectionWriteRepository;
            _mapper = mapper;
        }

        public async Task<UpdateProductCollectionCommandResponse> Handle(UpdateProductCollectionCommandRequest request, CancellationToken cancellationToken)
        {
            var entity = await _productCollectionReadRepository.GetByIdAsync(request.Id);
            entity.Name = string.IsNullOrEmpty(request.Name) ? request.Name : entity.Name;
            entity.Description = string.IsNullOrEmpty(request.Description) ? request.Description : entity.Description;
            entity.Categories = request.CategoryIds == default ? entity.Categories : (List<Domain.Entities.Category>)request.CategoryIds.Select(categoryId => new Domain.Entities.Category() { Id = Guid.Parse(categoryId) }).ToList();
            await _productCollectionWriteRepository.SaveAsync();
            return new();
        }
    }
}