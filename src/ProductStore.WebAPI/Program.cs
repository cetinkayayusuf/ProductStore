using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using ProductStore.Application;
using ProductStore.Application.Services;
using ProductStore.Persistance;
using ProductStore.Persistence;
using ProductStore.WebApi.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddPersistenceServices();
builder.Services.AddApplicationServices();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "TestWebApi", Version = "v1" });

    c.AddSecurityDefinition(JwtBearerDefaults.AuthenticationScheme,
        new OpenApiSecurityScheme
        {
            Description = "JWT Authorization header using the Bearer scheme.",
            Name = "Authorization",
            In = ParameterLocation.Header,
            Type = SecuritySchemeType.Http,
            Scheme = "bearer"
        });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "JWT"
                }
            },
            new List<string>()
        }
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "ApiKey"
                }
            },
            new List<string>()
        }
    });
});

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
 {
     options.TokenValidationParameters = new()
     {
         ValidateAudience = true, // Genereted token will be used by which websites, domains (wwww.client.com, localhost, ... etc)
         ValidateIssuer = true, // Genereted token will be issued by our domain (wwww.mywebsite.com)
         ValidateLifetime = true,
         ValidateIssuerSigningKey = true,

         ValidAudience = builder.Configuration["Token:Audience"],
         ValidIssuer = builder.Configuration["Token:Issuer"],
         IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Token:SecurityKey"])),
     };
 });
builder.Services.AddAuthorization(cfg =>
{
    cfg.AddPolicy("Admin", policy => policy.RequireClaim("type", "Admin"));
    cfg.AddPolicy("User", policy => policy.RequireClaim("type", "User"));
});

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    await DbInitializer.InitializeAsync(scope.ServiceProvider);
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.ConfigureExceptionHandler(app.Services.GetRequiredService<ILoggerService>());

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
