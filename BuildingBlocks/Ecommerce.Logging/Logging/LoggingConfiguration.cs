using Ecommerce.Logging.Settings;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Serilog;

namespace Ecommerce.Logging.Logging;

public static class LoggingConfiguration
{
    public static void ConfigureSerilog(HostBuilderContext context, LoggerConfiguration config)
    {
        var settings = context.Configuration.GetSection("Logging").Get<LoggingOptions>();

        config
            .ReadFrom.Configuration(context.Configuration)
            .Enrich.FromLogContext()
            .Enrich.WithProperty("Application", context.HostingEnvironment.ApplicationName)
            .WriteTo.Console()
            .WriteTo.File("Logs/log-.txt", rollingInterval: RollingInterval.Day);
    }
}

