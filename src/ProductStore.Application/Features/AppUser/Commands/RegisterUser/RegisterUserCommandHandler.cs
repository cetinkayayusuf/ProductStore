using MediatR;
using Microsoft.AspNetCore.Identity;
using ProductStore.Application.Services;
using ProductStore.Domain.Entities.Enums;

namespace ProductStore.Application.Features.AppUser.Commands.RegisterUser;

public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommandRequest, RegisterUserCommandResponse>
{
    private readonly IUserService _userService;
    private readonly UserManager<Domain.Entities.Identity.AppUser> _userManager;

    public RegisterUserCommandHandler(IUserService userService, UserManager<Domain.Entities.Identity.AppUser> userManager)
    {
        _userService = userService;
        _userManager = userManager;
    }

    public async Task<RegisterUserCommandResponse> Handle(RegisterUserCommandRequest request, CancellationToken cancellationToken)
    {
        var response = await _userService.AddAsync(new Dto.Category.AddUserDto()
        {
            Username = request.Username,
            Email = request.Email,
            Password = request.Password,
            PasswordConfirm = request.PasswordConfirm,
            CountryCode = request.CountryCode
        });
        var user = await _userManager.FindByEmailAsync(request.Email);
        await _userService.AssignRoleAsync(user.Id, new[] { Enum.GetName(AppUserRole.User) });
        return new()
        {
            Succeeded = response.Succeeded,
            Message = response.Message
        };
    }
}
