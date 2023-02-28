
using Microsoft.AspNetCore.Identity;
using ProductStore.Application.Dto.Category;
using ProductStore.Application.Exceptions;
using ProductStore.Application.Services;
using ProductStore.Domain.Entities.Identity;

namespace ProductStore.Persistance.Services;

public class UserService : IUserService
{
    private readonly UserManager<Domain.Entities.Identity.AppUser> _userManager;

    public UserService(UserManager<Domain.Entities.Identity.AppUser> userManager)
    {
        _userManager = userManager;
    }
    public async Task<AddUserResponseDto> AddAsync(AddUserDto addUserDto)
    {
        var result = await _userManager.CreateAsync(new()
        {
            Id = Guid.NewGuid().ToString(),
            UserName = addUserDto.Username,
            Email = addUserDto.Email,
        }, addUserDto.Password);
        if (result.Succeeded)
            return new()
            {
                Succeeded = true,
                Message = "User registeration succeded"
            };
        foreach (var error in result.Errors)
            Console.WriteLine(error.Description);
        throw new UserRegisterFailedException();
    }

    public async Task AssignRoleAsync(string userId, string[] roles)
    {
        AppUser user = await _userManager.FindByIdAsync(userId);
        if (user != null)
        {
            var userRoles = await _userManager.GetRolesAsync(user);
            await _userManager.RemoveFromRolesAsync(user, userRoles);

            await _userManager.AddToRolesAsync(user, roles);
        }
    }
}
