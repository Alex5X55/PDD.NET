using Microsoft.EntityFrameworkCore;
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
        var connectionString = configuration.GetConnectionString("Sqlite");
        services.AddDbContext<DatabaseContext>(opt => opt.UseSqlite(connectionString));

        services.AddScoped<IUnitOfWork, UnitOfWork>();

        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IUserDetailRepository, UserDetailRepository>();
        services.AddScoped<IRoleRepository, RoleRepository>();
        services.AddScoped<IUserInRoleRepository, UserInRoleRepository>();

        services.AddScoped<IDataInitializer, EFDataInitializer>();

        var connectionStringAuth = configuration.GetConnectionString("Default");
        services.AddDbContext<ApiDbContext>(opt => opt.UseSqlite(connectionStringAuth));

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
            RequireExpirationTime = false
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

/*        services.AddDefaultIdentity<IdentityUser>(options => { options.SignIn.RequireConfirmedAccount = true; })
            .AddEntityFrameworkStores<ApiDbContext>();*/

        services.AddScoped<IJwtService, JwtService>();

        return services;
    }
}
