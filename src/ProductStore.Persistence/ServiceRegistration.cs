using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using ProductStore.Persistence.Context;
using ProductStore.Persistance.Services;
using ProductStore.Application.Services;
using ProductStore.Application.Repositories;
using ProductStore.Infrastructure.Persistance;
using ProductStore.Persistence.Mappings;
using ProductStore.Domain.Entities.Identity;
using ProductStore.Application.Services.Token;
using Microsoft.AspNetCore.Identity;

namespace ProductStore.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceServices(this IServiceCollection services)
        {
            // services.AddDbContext<ApplicationDbContext>(options => options.UseLazyLoadingProxies().UseInMemoryDatabase(databaseName: "ProductStoreDb"));
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                var connectionString = Configuration.ConnectionString;
                options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
                options.UseTriggers(triggerOptions =>
                {
                    triggerOptions.AddAssemblyTriggers();
                });
            });

            services.AddIdentity<AppUser, AppRole>(opt =>
            {
                opt.Password.RequireDigit = false;
                opt.Password.RequiredLength = 3;
                opt.Password.RequiredUniqueChars = 0;
                opt.Password.RequireLowercase = false;
                opt.Password.RequireNonAlphanumeric = false;
                opt.Password.RequireUppercase = false;

                opt.User.RequireUniqueEmail = true;
            }).AddEntityFrameworkStores<ApplicationDbContext>()
            .AddDefaultTokenProviders();


            services.AddScoped<ICategoryReadRepository, CategoryReadRepository>();
            services.AddScoped<ICategoryWriteRepository, CategoryWriteRepository>();
            services.AddScoped<IProductReadRepository, ProductReadRepository>();
            services.AddScoped<IProductWriteRepository, ProductWriteRepository>();
            services.AddScoped<IProductCollectionReadRepository, ProductCollectionReadRepository>();
            services.AddScoped<IProductCollectionWriteRepository, ProductCollectionWriteRepository>();
            services.AddScoped<INotificationReadRepository, NotificationReadRepository>();
            services.AddScoped<INotificationWriteRepository, NotificationWriteRepository>();

            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.Decorate<ICategoryService, CachedCategoryService>();


            services.AddScoped<ITokenHandler, TokenHandler>();

            services.AddSingleton<ILoggerService, LoggerService>();

            services.AddMemoryCache();

            // services.AddAutoMapper(cfg =>
            // cfg.AddMaps(typeof(Profile).Assembly));

            services.AddAutoMapper(cfg =>
            {
                cfg.AddProfile(typeof(CategoryMappingProfile));
                cfg.AddProfile(typeof(ProductMappingProfile));
                cfg.AddProfile(typeof(ProductCollectionMappingProfile));
            });
        }
    }
}