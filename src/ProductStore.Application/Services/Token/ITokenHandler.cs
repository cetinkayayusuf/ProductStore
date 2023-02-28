using System.Security.Claims;

namespace ProductStore.Application.Services.Token;

public interface ITokenHandler
{
    Dto.Token CreateAccessToken(List<Claim> authClaims, int expirationInMinutes);
}