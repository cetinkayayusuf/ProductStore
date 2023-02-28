using AutoMapper;
using MediatR;
using ProductStore.Application.Repositories;

namespace ProductStore.Application.Features.Product.Commands.AddProduct
{
    public class AddProductCommandHandler : IRequestHandler<AddProductCommandRequest, AddProductCommandResponse>
    {
        private readonly IProductWriteRepository _productWriteRepository;
        private readonly ICategoryReadRepository _categoryReadRepository;
        private readonly IMapper _mapper;

        public AddProductCommandHandler(IProductWriteRepository productWriteRepository, IMapper mapper, ICategoryReadRepository categoryReadRepository)
        {
            _productWriteRepository = productWriteRepository;
            _mapper = mapper;
            _categoryReadRepository = categoryReadRepository;
        }

        public async Task<AddProductCommandResponse> Handle(AddProductCommandRequest request, CancellationToken cancellationToken)
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