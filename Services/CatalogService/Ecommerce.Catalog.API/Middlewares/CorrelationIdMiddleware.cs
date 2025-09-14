using Ecommerce.Logging.Logging;

namespace Ecommerce.Catalog.API.Middlewares;

public class CorrelationIdMiddleware
{
    private readonly RequestDelegate _next;
    public CorrelationIdMiddleware(RequestDelegate next) => _next = next;

    public async Task Invoke(HttpContext context)
    {
        const string header = "X-Correlation-ID";
        var correlationId = context.Request.Headers.ContainsKey(header)
            ? context.Request.Headers[header].ToString()
            : Guid.NewGuid().ToString();

        // Attach correlation ID to logging context
        using (Serilog.Context.LogContext.Push(new CorrelationIdEnricher(correlationId)))
        {
            context.Response.Headers[header] = correlationId;
            await _next(context);
        }
    }
}
