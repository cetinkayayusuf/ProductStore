namespace ProductStore.Application.Services;
public interface IRoleService
{
    Task<bool> AddRole(string name);
    Task<bool> DeleteRole(string id);
    Task<(string id, string name)> GetRoleById(string id);
    Task<(string id, string name)> GetRoleByName(string id);
    Task<bool> UpdateRole(string id, string name);
}