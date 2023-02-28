
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using ProductStore.Application.Dto;
using ProductStore.Application.Services.Token;

namespace ProductStore.Persistance.Services;

public class TokenHandler : ITokenHandler
{
    readonly IConfiguration _configuration;

    public TokenHandler(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public Token CreateAccessToken(List<Claim> authClaims, int expirationInMinutes)
    {
        Application.Dto.Token token = new();
        SymmetricSecurityKey securityKey = new(Encoding.UTF8.GetBytes(_configuration["Token:SecurityKey"]));
        SigningCredentials signingCredentials = new(securityKey, SecurityAlgorithms.HmacSha256);

        token.Expiration = DateTime.UtcNow.AddMinutes(expirationInMinutes);
        JwtSecurityToken securityToken = new(
            audience: _configuration["Token:Audience"],
            issuer: _configuration["Token:Issuer"],
            expires: token.Expiration,
            notBefore: DateTime.UtcNow,
            claims: authClaims,
            signingCredentials: signingCredentials
            );

        JwtSecurityTokenHandler tokenHandler = new();
        token.AccessToken = tokenHandler.WriteToken(securityToken);

        return token;
    }
}
