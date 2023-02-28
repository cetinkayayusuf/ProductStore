
using ProductStore.Application.Dto.Notification;

namespace ProductStore.Application.Services;

public interface INotificationService
{
    Task<List<NotificationDto>> GetAllNotifications();
}