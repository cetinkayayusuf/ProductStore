using MediatR;
using ProductStore.Application.RequestParams;

namespace ProductStore.Application.Features.Notification.Queries.GetAllNotifications;

public class GetAllNotificationsQueryRequest : IRequest<GetAllNotificationsQueryResponse>
{
    public Pagination? Pagination { get; set; }
}