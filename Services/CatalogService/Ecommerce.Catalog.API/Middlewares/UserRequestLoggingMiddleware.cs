namespace Ecommerce.Catalog.API.Middlewares;
public class UserRequestLoggingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<UserRequestLoggingMiddleware> _logger;

    public UserRequestLoggingMiddleware(RequestDelegate next, ILogger<UserRequestLoggingMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task Invoke(HttpContext context)
    {
        // Extract user info from JWT claims
        string? userId = context.User?.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
        string? email = context.User?.FindFirst(System.Security.Claims.ClaimTypes.Email)?.Value;

        // Log request with user info
        _logger.LogInformation("Request by UserId: {UserId}, Email: {Email}, Path: {Path}, Method: {Method}",
            userId ?? "Anonymous",
            email ?? "Anonymous",
            context.Request.Path,
            context.Request.Method);

        await _next(context);
    }
}
