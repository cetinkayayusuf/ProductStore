
using Microsoft.AspNetCore.Identity;

namespace ProductStore.Domain.Entities.Identity;

public class AppUser : IdentityUser<string>
{
    public string CountryCode { get; set; }
}