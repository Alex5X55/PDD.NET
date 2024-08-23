using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PDD.NET.Application.Repositories;
using PDD.NET.Persistence.Repositories;

namespace PDD.NET.Persistence;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureConfig(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection");
        services.AddDbContext<DatabaseContext>(opt => opt.UseNpgsql(connectionString));
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);


        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IAnalyticsDataRepository, AnalyticsDataRepository>();

        services.AddScoped<IDataInitializer, EFDataInitializer>();

        return services;
    }
}
