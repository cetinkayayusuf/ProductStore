using MediatR;

namespace ProductStore.Application.Features.AppUser.Commands.RegisterUser;

public class RegisterUserCommandRequest : IRequest<RegisterUserCommandResponse>
{
    public string Username { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string PasswordConfirm { get; set; }
    public string CountryCode { get; set; }
}
