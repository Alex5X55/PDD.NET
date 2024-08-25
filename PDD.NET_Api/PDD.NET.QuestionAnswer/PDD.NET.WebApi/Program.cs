using Microsoft.Extensions.Configuration;
using PDD.NET.Domain.Constants;
using NLog;
using NLog.Web;

namespace PDD.NET.WebApi;

public class Program
{
    private static IConfiguration Configuration { get; set; } = null!;
    public static void Main(string[] args)
    {

        var logConfig = LogManager.Setup().LoadConfigurationFromFile(Path.Combine(Directory.GetCurrentDirectory(), "nlog.config"));
        var logger = logConfig.GetCurrentClassLogger();

        logger.Info(MessageConstants.INIT_TEXT);
        var builder = new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile("appsettings.json", true);
        Configuration = builder.Build();
        CreateHostBuilder(args).Build().Run();
    }

    public static IHostBuilder CreateHostBuilder(string[] args) =>
      Host.CreateDefaultBuilder(args)
          .ConfigureWebHostDefaults(webBuilder =>
          {
              webBuilder.UseKestrel()
                  .UseConfiguration(Configuration)
                  .UseStaticWebAssets()
                  .UseStartup<Startup>()
                .ConfigureLogging(logging =>
                {
                    logging.ClearProviders();
                    logging.SetMinimumLevel(Microsoft.Extensions.Logging.LogLevel.Trace);
                })
                  .UseNLog();// NLog: setup NLog for Dependency injection
          }).UseSystemd();
}
