using System.Security.Claims;

public static class ClaimsPrincipalExtensions
{
    public static string GetLoggedInUserId(this ClaimsPrincipal principal)
    {
        if (principal == null)
            throw new ArgumentNullException(nameof(principal));

        var userId = principal.FindFirstValue(ClaimTypes.NameIdentifier);
        if (userId == default)
            return "";
        return userId;
    }
}