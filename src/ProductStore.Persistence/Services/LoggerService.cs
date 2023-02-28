
using Microsoft.AspNetCore.Identity;
using ProductStore.Application.Dto.Category;
using ProductStore.Application.Services;

namespace ProductStore.Persistance.Services;

public class LoggerService : ILoggerService
{
    public void LogError(string message)
    {
        Console.WriteLine(message);
    }
}
