using MediatR;

namespace ProductStore.Application.Features.AppUser.Commands.LoginUser;

public class LoginUserCommandRequest : IRequest<LoginUserCommandResponse>
{
    public string UsernameOrEmail { get; set; }
    public string Password { get; set; }
}