using System.Reflection;
using FluentValidation;
using MassTransit;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using PDD.NET.Application.Broker;
using PDD.NET.Application.Common.Behaviors;

namespace PDD.NET.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationConfig(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddMediatR(option =>
        {
            option.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly());
        });
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));


        #region Rabbit

        var rabbitMqHost = Environment.GetEnvironmentVariable("RABBITMQ_HOST") ?? "localhost";
        var rabbitMqUser = Environment.GetEnvironmentVariable("RABBITMQ_USER") ?? "rabbit";
        var rabbitMqPass = Environment.GetEnvironmentVariable("RABBITMQ_PASS") ?? "rabbit";

        //services.AddAutoMapper(typeof(MessageDtoMapperProfile));
        services.AddMassTransit(x =>
        {
            x.AddConsumer<EventConsumer>();
            x.UsingRabbitMq((context, cfg) =>
            {
                cfg.Host(rabbitMqHost, "/", h =>
                {
                    h.Username(rabbitMqUser);
                    h.Password(rabbitMqPass);
                    RegisterEndPoints(cfg, context);

                });
            });
        });
        services.AddHostedService<MasstransitService>();
        #endregion
        return services;
    }


    /// <summary>
    /// регистрация эндпоинтов
    /// </summary>
    /// <param name="configurator"></param>
    /// <param name="provider"></param> // добавляем провайдер сервисов
    private static void RegisterEndPoints(IRabbitMqBusFactoryConfigurator configurator, IServiceProvider provider)
    {
        configurator.ReceiveEndpoint($"masstransit_event_queue_analitycs", e =>
        {
            // Используем фабрику для создания EventConsumer с необходимыми зависимостями
            e.Consumer<EventConsumer>(provider);

            e.UseMessageRetry(r =>
            {
                r.Incremental(3, TimeSpan.FromSeconds(1), TimeSpan.FromSeconds(1));
            });
            e.PrefetchCount = 1;
            e.UseConcurrencyLimit(1);
        });
    }

}