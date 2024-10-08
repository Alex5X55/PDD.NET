﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PDD.NET.Application.Repositories;
using PDD.NET.Persistence.Repositories;
using PDD.NET.Persistence.Services;
using System.Text;
using PDD.NET.Domain.Entities;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace PDD.NET.Persistence;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureConfig(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("PgUser");
        services.AddDbContext<DatabaseContext>(opt =>
        {
            //opt.EnableSensitiveDataLogging();
            opt.UseNpgsql(connectionString);
            //opt.EnableDetailedErrors();
        });

        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

        services.AddScoped<IUnitOfWork, UnitOfWork>();

        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IUserDetailRepository, UserDetailRepository>();
        services.AddScoped<IRoleRepository, RoleRepository>();
        services.AddScoped<IUserInRoleRepository, UserInRoleRepository>();

        services.AddScoped<IDataInitializer, EFDataInitializer>();

        var connectionStringAuth = configuration.GetConnectionString("PgAuth");
        services.AddDbContext<AuthDbContext>(opt =>
        {
            opt.EnableSensitiveDataLogging();
            opt.UseNpgsql(connectionStringAuth);
            //opt.EnableDetailedErrors();
        });

        //JWT Config
        var jwtConfig = configuration.GetSection("JwtConfig:Secret");
        services.Configure<JwtConfig>(configuration.GetSection("JwtConfig"));
        // Validation params

        Byte[]? key = Encoding.ASCII.GetBytes(jwtConfig.Value.ToCharArray());
        TokenValidationParameters? tokenValidationParams = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(key),
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidateLifetime = true,
            RequireExpirationTime = true
        };

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

        services.AddSingleton(tokenValidationParams);

        services.AddScoped<IJwtService, JwtService>();

        return services;
    }
}
