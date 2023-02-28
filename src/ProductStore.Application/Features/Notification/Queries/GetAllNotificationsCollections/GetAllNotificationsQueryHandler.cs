using AutoMapper;
using MediatR;
using ProductStore.Application.Repositories;

namespace ProductStore.Application.Features.Notification.Queries.GetAllNotifications
{
    public class GetAllNotificationsQueryHandler : IRequestHandler<GetAllNotificationsQueryRequest, GetAllNotificationsQueryResponse>
    {
        private readonly INotificationReadRepository _notificationReadRepository;
        private readonly IMapper _mapper;

        public GetAllNotificationsQueryHandler(INotificationReadRepository notificationReadRepository, IMapper mapper)
        {
            _notificationReadRepository = notificationReadRepository;
            _mapper = mapper;
        }

        public async Task<GetAllNotificationsQueryResponse> Handle(GetAllNotificationsQueryRequest request, CancellationToken cancellationToken)
        {
            var entities = await _notificationReadRepository.GetAsync();
            var entityCount = entities.Count();

            var notifications = entities.Select(notification => new
            {
                notification.Id,
                notification.Message,
                Type = Enum.GetName(notification.Type),
                notification.ReferenceId,
            });
            return new()
            {
                Notifications = notifications,
                NotificationCount = entityCount
            };
        }
    }
}