using Microsoft.Extensions.DependencyInjection;

namespace ProductStore.Application;
public static class ServiceRegistration
{
    public static void AddApplicationServices(this IServiceCollection services)
    {
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(ServiceRegistration).Assembly));
    }
}