using System.Reflection;
using FluentValidation;
using MassTransit;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
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

        var rabbitMqHost = Environment.GetEnvironmentVariable("RABBITMQ_HOST");
        var rabbitMqUser = Environment.GetEnvironmentVariable("RABBITMQ_USER");
        var rabbitMqPass = Environment.GetEnvironmentVariable("RABBITMQ_PASS");

        //Console.WriteLine(rabbitMqHost);
        //Console.WriteLine(rabbitMqUser);
        //Console.WriteLine(rabbitMqPass);

        services.AddMassTransit(x =>
        {
            x.UsingRabbitMq((context, cfg) =>
            {
                cfg.Host(rabbitMqHost, "/", h =>
                {
                    h.Username(rabbitMqUser);
                    h.Password(rabbitMqPass);
                });
            });
        });



        #endregion

        return services;
    }
}