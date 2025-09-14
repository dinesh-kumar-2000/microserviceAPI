using Ecommerce.Catalog.Application.Interfaces;
using Ecommerce.Catalog.Application.Interfaces.Caching;
using Ecommerce.Catalog.Infrastructure.Auth;
using Ecommerce.Catalog.Infrastructure.Persistence.Dapper;
using Ecommerce.Catalog.Infrastructure.Persistence.Repositories;
using Ecommerce.Catalog.Infrastructure.Persistence.Repositories.DapperRepository;
using Ecommerce.Catalog.Infrastructure.Services.Caching;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Ecommerce.Catalog.Infrastructure;

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
        services.AddScoped<IProductRepository, ProductRepository>();


        return services;
    }
}
