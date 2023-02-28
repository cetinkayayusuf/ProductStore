using AutoMapper;
using MediatR;
using ProductStore.Application.Repositories;

namespace ProductStore.Application.Features.Product.Commands.AddProduct
{
    public class AddProductCollectionCommandHandler : IRequestHandler<AddProductCollectionCommandRequest, AddProductCollectionCommandResponse>
    {
        private readonly IProductWriteRepository _productWriteRepository;
        private readonly ICategoryReadRepository _categoryReadRepository;
        private readonly IMapper _mapper;

        public AddProductCollectionCommandHandler(IProductWriteRepository productWriteRepository, IMapper mapper, ICategoryReadRepository categoryReadRepository)
        {
            _productWriteRepository = productWriteRepository;
            _mapper = mapper;
            _categoryReadRepository = categoryReadRepository;
        }

        public async Task<AddProductCollectionCommandResponse> Handle(AddProductCollectionCommandRequest request, CancellationToken cancellationToken)
        {
            var categories = _categoryReadRepository.GetWhere(x => request.CategoryIds.Contains(x.Id.ToString())).ToList();
            await _productWriteRepository.AddAsync(new()
            {
                Name = request.Name,
                Description = request.Description,
                Categories = categories
            });
            await _productWriteRepository.SaveAsync();
            return new();
        }
    }
}