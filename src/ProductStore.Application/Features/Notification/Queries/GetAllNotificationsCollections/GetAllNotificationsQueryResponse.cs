using ProductStore.Application.Dto.Product;

namespace ProductStore.Application.Features.Notification.Queries.GetAllNotifications;

public class GetAllNotificationsQueryResponse
{
    public object Notifications { get; set; }
    public int NotificationCount { get; set; }
}
