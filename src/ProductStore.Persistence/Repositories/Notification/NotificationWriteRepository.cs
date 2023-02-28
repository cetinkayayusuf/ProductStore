using ProductStore.Application.Repositories;
using ProductStore.Domain.Entities;
using ProductStore.Persistence.Context;
using ProductStore.Persistance.Repositories;

namespace ProductStore.Infrastructure.Persistance;
public class NotificationWriteRepository : WriteRepository<Notification>, INotificationWriteRepository
{
    public NotificationWriteRepository(ApplicationDbContext context) : base(context)
    {
    }
}
