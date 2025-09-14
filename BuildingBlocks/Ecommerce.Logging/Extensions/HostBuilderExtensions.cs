using Ecommerce.Logging.Logging;
using Microsoft.Extensions.Hosting;
using Serilog;

namespace Ecommerce.Logging.Extensions;

public static class HostBuilderExtensions
{
    public static IHostBuilder UseLogging(this IHostBuilder builder)
    {
        return builder.UseSerilog((context, services, configuration) =>
        {
            LoggingConfiguration.ConfigureSerilog(context, configuration);
        });
    }
}

