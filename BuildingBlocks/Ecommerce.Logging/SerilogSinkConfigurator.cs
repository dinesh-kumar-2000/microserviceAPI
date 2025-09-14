using Microsoft.Extensions.Configuration;
using Serilog;

namespace Ecommerce.Logging.Logging;

public static class SerilogSinkConfigurator
{
    public static LoggerConfiguration AddConfiguredSinks(this LoggerConfiguration config, IConfiguration configuration)
    {
        // Example: conditional sink setup
        if (configuration.GetValue<bool>("Serilog:EnableFile"))
        {
            config.WriteTo.File("Logs/log-.txt", rollingInterval: RollingInterval.Day);
        }

        if (configuration.GetValue<bool>("Serilog:EnableConsole"))
        {
            config.WriteTo.Console();
        }

        return config;
    }
}
