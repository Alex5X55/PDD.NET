using System.Reflection;
using FluentValidation;
using MassTransit;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PDD.NET.Application.Common.Behaviors;

namespace PDD.NET.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationConfig(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddMediatR(option =>
        {
            option.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly());
        });
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));


        services.AddMassTransit(x =>
        {
            x.UsingRabbitMq((context, cfg) =>
            {
                cfg.Host("localhost", 5672,"/", h =>
                {
                    h.Username("guest");
                    h.Password("guest");
                });
            });
        });


        return services;
    }
}