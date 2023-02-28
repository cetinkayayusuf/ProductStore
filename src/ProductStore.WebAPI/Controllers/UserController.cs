using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProductStore.Application.Features.AppUser.Commands.RegisterUser;
using ProductStore.Application.Features.AppUser.Commands.LoginUser;

namespace ProductStore.Presentation.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Register(RegisterUserCommandRequest registerUserCommandRequest)
        {
            RegisterUserCommandResponse response = await _mediator.Send(registerUserCommandRequest);
            return Ok(response);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Login(LoginUserCommandRequest loginUserCommandRequest)
        {
            LoginUserCommandResponse response = await _mediator.Send(loginUserCommandRequest);
            return Ok(response);
        }
    }
}