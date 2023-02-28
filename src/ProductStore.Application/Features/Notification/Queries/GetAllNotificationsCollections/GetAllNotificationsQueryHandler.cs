using AutoMapper;
using MediatR;
using ProductStore.Application.Repositories;
using ProductStore.Application.Services;

namespace ProductStore.Application.Features.Notification.Queries.GetAllNotifications
{
    public class GetAllNotificationsQueryHandler : IRequestHandler<GetAllNotificationsQueryRequest, GetAllNotificationsQueryResponse>
    {
        private readonly INotificationService _notificationService;

        public GetAllNotificationsQueryHandler(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }

        public async Task<GetAllNotificationsQueryResponse> Handle(GetAllNotificationsQueryRequest request, CancellationToken cancellationToken)
        {
            var notifications = await _notificationService.GetAllNotifications();
            return new()
            {
                Notifications = notifications,
                NotificationCount = notifications.Count()
            };
        }
    }
}