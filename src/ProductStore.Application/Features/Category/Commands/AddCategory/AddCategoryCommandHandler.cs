using MediatR;
using ProductStore.Application.Repositories;
using ProductStore.Application.Services;

namespace ProductStore.Application.Features.Category.Commands.AddCategory
{
    public class AddCategoryCommandHandler : IRequestHandler<AddCategoryCommandRequest, AddCategoryCommandResponse>
    {
        readonly ICategoryWriteRepository _categoryWriteRepository;
        readonly ICategoryService _categoryService;


        public AddCategoryCommandHandler(ICategoryWriteRepository categoryWriteRepository, ICategoryService categoryService)
        {
            _categoryWriteRepository = categoryWriteRepository;
            _categoryService = categoryService;
        }

        public async Task<AddCategoryCommandResponse> Handle(AddCategoryCommandRequest request, CancellationToken cancellationToken)
        {
            // await _categoryWriteRepository.AddAsync(new()
            // {
            //     Name = request.Name,
            // });
            // await _categoryWriteRepository.SaveAsync();
            await _categoryService.AddAsync(new()
            {
                Name = request.Name
            });
            return new();
        }
    }
}