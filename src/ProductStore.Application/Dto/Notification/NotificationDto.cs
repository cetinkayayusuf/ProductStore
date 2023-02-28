using ProductStore.Domain.Entities.Enums;

namespace ProductStore.Application.Dto.Notification;

public class NotificationDto
{
    public Guid Id { get; set; }
    public string Message { get; set; }
    public string Type { get; set; }
    public string ReferenceId { get; set; }
}