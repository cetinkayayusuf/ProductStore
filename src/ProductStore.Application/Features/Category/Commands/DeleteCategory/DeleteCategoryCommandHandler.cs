using MediatR;
using ProductStore.Application.Repositories;
using ProductStore.Application.Services;

namespace ProductStore.Application.Features.Category.Commands.DeleteCategory
{
    public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommandRequest, DeleteCategoryCommandResponse>
    {
        readonly ICategoryWriteRepository _categoryWriteRepository;
        readonly ICategoryService _categoryService;


        public DeleteCategoryCommandHandler(ICategoryWriteRepository categoryWriteRepository, ICategoryService categoryService)
        {
            _categoryWriteRepository = categoryWriteRepository;
            _categoryService = categoryService;
        }

        public async Task<DeleteCategoryCommandResponse> Handle(DeleteCategoryCommandRequest request, CancellationToken cancellationToken)
        {
            // await _categoryWriteRepository.RemoveAsync(request.Id);
            // await _categoryWriteRepository.SaveAsync();
            await _categoryService.DeleteAsync(request.Id);
            return new();
        }
    }
}