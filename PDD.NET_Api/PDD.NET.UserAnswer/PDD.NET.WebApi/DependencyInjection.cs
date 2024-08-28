using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using PDD.NET.Application.Common.Constants;
using PDD.NET.Domain.Entities;
using System.Data;
using System.Reflection;
using System.Security.Claims;
using System.Text;

namespace PDD.NET.WebApi;

public static class DependencyInjection
{
    public static IServiceCollection AddPresentationConfig(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddControllers();

        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen(options =>
        {
            options.SwaggerDoc("v1", new OpenApiInfo
            {
                Version = "v1",
                Title = "PDD.NET API",
            });

            var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
        });

        // Отключаем автоматическую обработку ошибок на ApiController для реализации собственных обработчиков
        services.Configure<ApiBehaviorOptions>(options =>
        {
            options.SuppressModelStateInvalidFilter = true;
        });

        // Пока отключаем все политики Cors
        services.AddCors(opt =>
        {
            opt.AddDefaultPolicy(builder => builder
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());
        });

        var Key = configuration.GetSection("JwtConfig:Secret").Value;
        Byte[]? key = Encoding.ASCII.GetBytes(Key.ToCharArray());
        TokenValidationParameters? tokenValidationParams = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(key),
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidateLifetime = true,
            RequireExpirationTime = true
        };
        services.AddAuthorization();

        services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(jwt =>
        {
            jwt.SaveToken = true;
            jwt.TokenValidationParameters = tokenValidationParams;
        });

        return services;
    }
}
