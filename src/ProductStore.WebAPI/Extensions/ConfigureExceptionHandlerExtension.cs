using System.Net;
using System.Net.Mime;
using System.Text.Json;
using Microsoft.AspNetCore.Diagnostics;
using ProductStore.Application.Services;

namespace ProductStore.WebApi.Extensions;
public static class ConfigureExceptionHandlerExtension
{
    public static void ConfigureExceptionHandler(this WebApplication app, ILoggerService logger)
    {
        app.UseExceptionHandler(builder =>
        {
            builder.Run(async context =>
            {
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                context.Response.ContentType = MediaTypeNames.Application.Json;

                var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                if (contextFeature != null)
                {
                    logger.LogError(contextFeature.Error.Message);

                    await context.Response.WriteAsJsonAsync(JsonSerializer.Serialize(new
                    {
                        StatusCode = context.Response.StatusCode,
                        Message = contextFeature.Error.Message,
                        Title = "Error"
                    }));
                }
            });
        });
    }
}