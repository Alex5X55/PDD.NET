using System.Reflection;
using FluentValidation;
using MassTransit;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PDD.NET.Application.Broker;
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
            x.AddConsumer<EventConsumer>();
            x.UsingRabbitMq((context, cfg) =>
            {
                cfg.Host("localhost", 5672, "/", h =>
                {
                    h.Username("guest");
                    h.Password("guest");
                    RegisterEndPoints(cfg);

                });
            });
        });
        services.AddHostedService<MasstransitService>();

        return services;
    }

    /// <summary>
    /// регистрация эндпоинтов
    /// </summary>
    /// <param name="configurator"></param>
    private static void RegisterEndPoints(IRabbitMqBusFactoryConfigurator configurator)
    {
        configurator.ReceiveEndpoint($"masstransit_event_queue_analitycs", e =>
        {
            e.Consumer<EventConsumer>();
            e.UseMessageRetry(r =>
            {
                r.Incremental(3, TimeSpan.FromSeconds(1), TimeSpan.FromSeconds(1));
            });
            e.PrefetchCount = 1;
            e.UseConcurrencyLimit(1);
        });

    }
}