using MediatR;
using ProductStore.Application.Repositories;
using ProductStore.Application.Services;

namespace ProductStore.Application.Features.Category.Commands.UpdateCategory
{
    public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommandRequest, UpdateCategoryCommandResponse>
    {
        readonly ICategoryReadRepository _categoryReadRepository;
        readonly ICategoryWriteRepository _categoryWriteRepository;

        public UpdateCategoryCommandHandler(ICategoryReadRepository categoryReadRepository, ICategoryWriteRepository categoryWriteRepository)
        {
            _categoryReadRepository = categoryReadRepository;
            _categoryWriteRepository = categoryWriteRepository;
        }

        public async Task<UpdateCategoryCommandResponse> Handle(UpdateCategoryCommandRequest request, CancellationToken cancellationToken)
        {
            var entity = await _categoryReadRepository.GetByIdAsync(request.Id);
            entity.Name = request.Name;
            await _categoryWriteRepository.SaveAsync();
            return new();
        }
    }
}