using ProductStore.Application.Repositories;
using ProductStore.Domain.Entities;
using ProductStore.Persistence.Context;
using ProductStore.Persistance.Repositories;

namespace ProductStore.Infrastructure.Persistance;
public class NotificationReadRepository : ReadRepository<Notification>, INotificationReadRepository
{
    public NotificationReadRepository(ApplicationDbContext context) : base(context)
    {
    }
}
