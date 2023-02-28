using MediatR;
using ProductStore.Application.Services;

namespace ProductStore.Application.Features.AppUser.Commands.LoginUser;

public class LoginUserCommandHandler : IRequestHandler<LoginUserCommandRequest, LoginUserCommandResponse>
{
    private readonly IAuthService _authService;

    public LoginUserCommandHandler(IAuthService authService)
    {
        _authService = authService;
    }

    public async Task<LoginUserCommandResponse> Handle(LoginUserCommandRequest request, CancellationToken cancellationToken)
    {
        var response = await _authService.LoginAsync(new()
        {
            UsernameOrEmail = request.UsernameOrEmail,
            Password = request.Password,
        });
        return new()
        {
            Token = response.Token,
            CountryCode = response.CountryCode,
            FlagUrl = ""
        };
    }
}
