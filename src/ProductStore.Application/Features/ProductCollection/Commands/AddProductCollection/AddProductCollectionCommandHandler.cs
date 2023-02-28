using AutoMapper;
using MediatR;
using ProductStore.Application.Repositories;

namespace ProductStore.Application.Features.ProductCollection.Commands.AddProductCollection
{
    public class AddProductCollectionCommandHandler : IRequestHandler<AddProductCollectionCommandRequest, AddProductCollectionCommandResponse>
    {
        private readonly IProductCollectionWriteRepository _productCollectionWriteRepository;
        private readonly ICategoryReadRepository _categoryReadRepository;
        private readonly IMapper _mapper;

        public AddProductCollectionCommandHandler(IProductCollectionWriteRepository productCollectionWriteRepository, IMapper mapper, ICategoryReadRepository categoryReadRepository)
        {
            _productCollectionWriteRepository = productCollectionWriteRepository;
            _mapper = mapper;
            _categoryReadRepository = categoryReadRepository;
        }

        public async Task<AddProductCollectionCommandResponse> Handle(AddProductCollectionCommandRequest request, CancellationToken cancellationToken)
        {
            var categories = _categoryReadRepository.GetWhere(x => request.CategoryIds.Contains(x.Id.ToString())).ToList();
            await _productCollectionWriteRepository.AddAsync(new()
            {
                Name = request.Name,
                Description = request.Description,
                Categories = categories
            });
            await _productCollectionWriteRepository.SaveAsync();
            return new();
        }
    }
}