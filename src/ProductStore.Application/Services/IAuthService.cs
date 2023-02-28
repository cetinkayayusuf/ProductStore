using ProductStore.Application.Dto.Category;

namespace ProductStore.Application.Services;

public interface IAuthService
{
    Task<LoginResponseDto> LoginAsync(LoginDto loginDto);
}