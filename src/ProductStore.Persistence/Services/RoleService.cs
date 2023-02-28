using Microsoft.AspNetCore.Identity;
using ProductStore.Application.Services;
using ProductStore.Domain.Entities.Identity;

namespace ProductStore.Persistance.Services;

public class RoleService : IRoleService
{
    readonly RoleManager<AppRole> _roleManager;

    public RoleService(RoleManager<AppRole> roleManager)
    {
        _roleManager = roleManager;
    }

    public async Task<bool> AddRole(string name)
    {
        IdentityResult result = await _roleManager.CreateAsync(new() { Id = Guid.NewGuid().ToString(), Name = name });

        return result.Succeeded;
    }

    public async Task<bool> DeleteRole(string id)
    {
        AppRole appRole = await _roleManager.FindByIdAsync(id);
        IdentityResult result = await _roleManager.DeleteAsync(appRole);
        return result.Succeeded;
    }

    public async Task<(string id, string name)> GetRoleById(string id)
    {
        string role = await _roleManager.GetRoleIdAsync(new() { Id = id });
        return (id, role);
    }

    public async Task<(string id, string name)> GetRoleByName(string roleName)
    {
        var role = await _roleManager.FindByNameAsync(roleName);
        return (role.Id, role.Name);
    }

    public async Task<bool> UpdateRole(string id, string name)
    {
        AppRole role = await _roleManager.FindByIdAsync(id);
        role.Name = name;
        IdentityResult result = await _roleManager.UpdateAsync(role);
        return result.Succeeded;
    }
}