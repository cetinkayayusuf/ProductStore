
using ProductStore.Application.Dto.Notification;
using ProductStore.Application.Repositories;
using ProductStore.Application.Services;

namespace ProductStore.Persistance.Services;

public class NotificationService : INotificationService
{
    private readonly INotificationReadRepository _notificationReadRepository;

    public NotificationService(INotificationReadRepository notificationReadRepository)
    {
        _notificationReadRepository = notificationReadRepository;
    }

    public async Task<List<NotificationDto>> GetAllNotifications()
    {
        var entities = await _notificationReadRepository.GetAsync();
        var notifications = entities.Select(notification => new
        NotificationDto
        {
            Id = notification.Id,
            Message = notification.Message,
            Type = Enum.GetName(notification.Type),
            ReferenceId = notification.ReferenceId,
        });
        return notifications.ToList();
    }
}