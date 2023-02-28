using MediatR;
using ProductStore.Application.Repositories;
using ProductStore.Application.Services;

namespace ProductStore.Application.Features.Category.Commands.AddCategory
{
    public class AddCategoryCommandHandler : IRequestHandler<AddCategoryCommandRequest, AddCategoryCommandResponse>
    {
        readonly ICategoryWriteRepository _categoryWriteRepository;

        public AddCategoryCommandHandler(ICategoryWriteRepository categoryWriteRepository)
        {
            _categoryWriteRepository = categoryWriteRepository;
        }

        public async Task<AddCategoryCommandResponse> Handle(AddCategoryCommandRequest request, CancellationToken cancellationToken)
        {
            await _categoryWriteRepository.AddAsync(new()
            {
                Name = request.Name,
            });
            await _categoryWriteRepository.SaveAsync();
            return new();
        }
    }
}