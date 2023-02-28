using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProductStore.Domain.Entities.Enums;
using ProductStore.Domain.Entities.Identity;
using ProductStore.Persistance.Services;
using ProductStore.Persistence.Context;

namespace ProductStore.Persistance;

public static class DbInitializer
{
    public static async Task InitializeAsync(IServiceProvider serviceProvider)
    {
        var context = serviceProvider
                .GetRequiredService<ApplicationDbContext>();
        context.Database.EnsureCreated();

        var roleManager = serviceProvider
                .GetRequiredService<RoleManager<AppRole>>();

        var adminRole = Enum.GetName(AppUserRole.Admin);

        IdentityResult result;
        var roleExist = await roleManager.RoleExistsAsync(adminRole);
        if (!roleExist)
        {
            result = await roleManager
                .CreateAsync(new()
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = adminRole
                });
            if (result.Succeeded)
            {
                var userManager = serviceProvider
                    .GetRequiredService<UserManager<AppUser>>();
                var config = serviceProvider
                    .GetRequiredService<IConfiguration>();
                var admin = await userManager
                    .FindByEmailAsync(config["AdminCredentials:Email"]);

                var userService = new UserService(userManager);

                if (admin == null)
                {
                    var response = await userService.AddAsync(new()
                    {
                        Username = config["AdminCredentials:Email"],
                        Email = config["AdminCredentials:Email"],
                        Password = config["AdminCredentials:Password"],
                        CountryCode = config["AdminCredentials:CountryCode"],
                    });
                    var user = await userManager.FindByEmailAsync(config["AdminCredentials:Email"]);
                    if (response.Succeeded)
                    {
                        await userService
                            .AssignRoleAsync(user.Id, new[] { adminRole });

                    }
                }
            }
            else
                throw new Exception("Cant add admin role to roles");
        }

        var userRole = Enum.GetName(AppUserRole.User);

        roleExist = await roleManager.RoleExistsAsync(userRole);
        if (!roleExist)
        {
            result = await roleManager
                .CreateAsync(new()
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = userRole
                });
            if (!result.Succeeded)
                throw new Exception("Cant add user role to roles");
        }
    }
}