using MediatR;
using ProductStore.Application.Repositories;
using ProductStore.Application.Services;

namespace ProductStore.Application.Features.Category.Commands.DeleteCategory
{
    public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommandRequest, DeleteCategoryCommandResponse>
    {
        readonly ICategoryWriteRepository _categoryWriteRepository;

        public DeleteCategoryCommandHandler(ICategoryWriteRepository categoryWriteRepository)
        {
            _categoryWriteRepository = categoryWriteRepository;
        }

        public async Task<DeleteCategoryCommandResponse> Handle(DeleteCategoryCommandRequest request, CancellationToken cancellationToken)
        {
            await _categoryWriteRepository.RemoveAsync(request.Id);
            await _categoryWriteRepository.SaveAsync();
            return new();
        }
    }
}