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
        var connectionString = configuration.GetConnectionString("Sqlite");
        services.AddDbContext<DatabaseContext>(opt => opt.UseSqlite(connectionString));

        services.AddScoped<IUnitOfWork, UnitOfWork>();

        services.AddScoped<IAnswerRepository, AnswerRepository>();
        services.AddScoped<IQuestionRepository, QuestionRepository>();
        services.AddScoped<IQuestionCategoryRepository, QuestionCategoryRepository>();

        services.AddScoped<IDataInitializer, EFDataInitializer>();

        return services;
    }
}
