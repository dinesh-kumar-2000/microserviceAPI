using Ecommerce.Shipping.Application.Interfaces.Caching;
using Ecommerce.Shipping.Infrastructure.Auth;
using Ecommerce.Shipping.Infrastructure.Persistence.Dapper;
using Ecommerce.Shipping.Infrastructure.Persistence.Repositories.DapperRepository;
using Ecommerce.Shipping.Infrastructure.Services.Caching;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Ecommerce.IdentityService.Infrastructure;

public static class InfrastructureServiceRegistration
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration config)
    {
        services.AddJwtAuthentication(config);
        services.AddSingleton<IDbConnectionFactory, DbConnectionFactory>();
        services.AddScoped(sp => sp.GetRequiredService<IDbConnectionFactory>().CreateConnection());
        services.AddMemoryCache();
        services.AddScoped<ICacheService, MemoryCacheService>();
        services.AddScoped<DapperRepository>();


        return services;
    }
}