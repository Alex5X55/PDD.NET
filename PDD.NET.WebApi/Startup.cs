using PDD.NET.Application;
using PDD.NET.Persistence;
using PDD.NET.Application.Repositories;

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
            .AddApplicationConfig()
            .AddInfrastructureConfig(Configuration)
            .AddPresentationConfig();
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IDataInitializer dataInitializer)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI();
        }
        else
        {
            app.UseHsts();
        }

        app.UseHttpsRedirection();

        dataInitializer.InitData();

        app.UseRouting();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }
}