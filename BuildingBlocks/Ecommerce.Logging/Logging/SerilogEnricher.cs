using Serilog.Core;
using Serilog.Events;

namespace Ecommerce.Logging.Logging;

public class CorrelationIdEnricher : ILogEventEnricher
{
    private readonly string _correlationId;

    public CorrelationIdEnricher(string correlationId)
    {
        _correlationId = correlationId ?? Guid.NewGuid().ToString();
    }

    public void Enrich(LogEvent logEvent, ILogEventPropertyFactory propertyFactory)
    {
        var property = propertyFactory.CreateProperty("CorrelationId", _correlationId);
        logEvent.AddOrUpdateProperty(property);
    }
}
