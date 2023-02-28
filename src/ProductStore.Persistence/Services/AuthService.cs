
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.JsonWebTokens;
using ProductStore.Application.Dto;
using ProductStore.Application.Dto.Category;
using ProductStore.Application.Exceptions;
using ProductStore.Application.Services;
using ProductStore.Application.Services.Token;

namespace ProductStore.Persistance.Services;

public class AuthService : IAuthService
{
    private readonly UserManager<Domain.Entities.Identity.AppUser> _userManager;
    private readonly SignInManager<Domain.Entities.Identity.AppUser> _signInManager;
    private readonly ITokenHandler _tokenHandler;

    public AuthService(UserManager<Domain.Entities.Identity.AppUser> userManager, SignInManager<Domain.Entities.Identity.AppUser> signInManager, ITokenHandler tokenHandler)
    {
        // _userService = userService;
        _userManager = userManager;
        _signInManager = signInManager;
        _tokenHandler = tokenHandler;
    }

    public async Task<LoginResponseDto> LoginAsync(LoginDto loginDto)
    {
        Domain.Entities.Identity.AppUser user = await _userManager.FindByNameAsync(loginDto.UsernameOrEmail);
        if (user == null)
            user = await _userManager.FindByEmailAsync(loginDto.UsernameOrEmail);

        if (user == null)
            throw new NotFoundUserException();

        var result = await _signInManager.CheckPasswordSignInAsync(user, loginDto.Password, false);
        if (result.Succeeded)
        {
            var userRoles = await _userManager.GetRolesAsync(user);

            var authClaims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            };
            foreach (var userRole in userRoles)
            {
                authClaims.Add(new Claim(ClaimTypes.Role, userRole));
            }

            Token token = _tokenHandler.CreateAccessToken(authClaims, 60);
            return new()
            {
                Token = token
            };
        }

        throw new AuthenticationFailedException();
    }
}
