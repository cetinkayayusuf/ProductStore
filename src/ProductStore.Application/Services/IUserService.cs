using ProductStore.Application.Dto.Category;

namespace ProductStore.Application.Services;

public interface IUserService
{
    Task<AddUserResponseDto> AddAsync(AddUserDto addUserDto);
    Task AssignRoleAsync(string userId, string[] roles);
}