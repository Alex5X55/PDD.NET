using PDD.NET.Application;
using PDD.NET.Persistence;
using PDD.NET.Application.Repositories;
using PDD.NET.WebApi.Extensions;
using PDD.NET.Domain.Constants;

namespace PDD.NET.WebApi;

public class Startup
{
    #region Fields
    private IConfiguration Configuration { get; }
    private ILogger<Startup>? _logger;
    #endregion Fields

    #region Constructors
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }
    #endregion Constructors

    #region Methods
    public void ConfigureServices(IServiceCollection services)
    {
        services
            .AddApplicationConfig()
            .AddInfrastructureConfig(Configuration)
            .AddPresentationConfig(Configuration)
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

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IDataInitializer dataInitializer, ILogger<Startup> logger, IHostApplicationLifetime lifetime)
    {
        _logger = logger;
        _logger?.LogInformation(MessageConstants.IS_STARTED_TEXT);

        //if (env.IsDevelopment())
        //{
            app.UseCors("AllowReactApp");
            app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI();
        //}
        //else
        //{
            app.UseHsts();
        //}

        app.UseErrorHandler();

        app.UseHttpsRedirection();

        dataInitializer.InitData();

        app.UseRouting();

        app.UseAuthentication();
        app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
        lifetime.ApplicationStopping.Register(OnShutdown);
    }
    private void OnShutdown()
    {
        _logger?.LogInformation(MessageConstants.IS_STOPPED_TEXT);
    }
    #endregion Methods
}