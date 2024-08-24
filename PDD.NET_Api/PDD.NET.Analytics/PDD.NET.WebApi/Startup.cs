using PDD.NET.Application;
using PDD.NET.Persistence;
using PDD.NET.Application.Repositories;
using PDD.NET.WebApi.Extensions;

namespace PDD.NET.WebApi;

public class Startup
{
    private IConfiguration Configuration { get; }

    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public void ConfigureServices(IServiceCollection services)
    {
        services
            .AddApplicationConfig(Configuration)
            .AddInfrastructureConfig(Configuration)
            .AddPresentationConfig()
            .AddCors(options =>
            {
                options.AddPolicy("AllowReactApp",
                    builder =>
                    {
                        builder.WithOrigins("http://localhost:3000")
                               .AllowAnyHeader()
                               .AllowAnyMethod();
                    });
            });
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IDataInitializer dataInitializer)
    {
        if (env.IsDevelopment())
        {
            app.UseCors("AllowReactApp");
            app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI();
        }
        else
        {
            app.UseHsts();
        }

        app.UseErrorHandler();

        app.UseHttpsRedirection();

        dataInitializer.InitData();

        app.UseRouting();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }
}