using ProductStore.Domain.Common;
using ProductStore.Domain.Entities.Enums;

namespace ProductStore.Domain.Entities
{
    public class Notification : AuditableEntity
    {
        public string Message { get; set; }
        public NotificationType Type { get; set; }
        public string ReferenceId { get; set; }
    }
}