using ProductStore.Application.Dto;

namespace ProductStore.Application.Features.AppUser.Commands.LoginUser;

public class LoginUserCommandResponse
{
    public Token Token { get; set; }
}