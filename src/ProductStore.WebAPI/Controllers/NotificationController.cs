using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProductStore.Application.Features.Notification.Queries.GetAllNotifications;

namespace ProductStore.Presentation.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    // [Authorize(Roles = "Admin,User")]
    public class NotificationController : ControllerBase
    {
        private readonly IMediator _mediator;

        public NotificationController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] GetAllNotificationsQueryRequest getAllNotificationsQueryRequest)
        {
            GetAllNotificationsQueryResponse response = await _mediator.Send(getAllNotificationsQueryRequest);
            return Ok(response);
        }
    }
}