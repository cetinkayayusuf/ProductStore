using AutoMapper;
using MediatR;
using ProductStore.Application.Repositories;
using ProductStore.Domain.Entities;
using ProductStore.Domain.Entities.Enums;

namespace ProductStore.Application.Features.ProductCollection.Commands.CompleteProductCollection
{
    public class CompleteProductCollectionCommandHandler : IRequestHandler<CompleteProductCollectionCommandRequest, CompleteProductCollectionCommandResponse>
    {
        readonly IProductCollectionReadRepository _productCollectionReadRepository;
        readonly IProductCollectionWriteRepository _productCollectionWriteRepository;
        readonly INotificationWriteRepository _notificationWriteRepository;

        private readonly IMapper _mapper;

        public CompleteProductCollectionCommandHandler(IProductCollectionReadRepository productCollectionReadRepository, IProductCollectionWriteRepository productCollectionWriteRepository, IMapper mapper, INotificationWriteRepository notificationWriteRepository)
        {
            _productCollectionReadRepository = productCollectionReadRepository;
            _productCollectionWriteRepository = productCollectionWriteRepository;
            _mapper = mapper;
            _notificationWriteRepository = notificationWriteRepository;
        }

        public async Task<CompleteProductCollectionCommandResponse> Handle(CompleteProductCollectionCommandRequest request, CancellationToken cancellationToken)
        {
            var entity = await _productCollectionReadRepository.GetByIdAsync(request.Id);
            entity.Status = ProductCollectionStatus.Pending;
            await _productCollectionWriteRepository.SaveAsync();
            await _notificationWriteRepository.AddAsync(new()
            {
                Message = "Product collection completed!",
                Type = NotificationType.ProductCollectionCompleted,
                ReferenceId = entity.Id.ToString()
            });
            await _notificationWriteRepository.SaveAsync();

            return new();
        }
    }
}