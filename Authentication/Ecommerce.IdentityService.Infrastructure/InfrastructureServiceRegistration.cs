using Dapper;
using Ecommerce.IdentityService.Application.Interfaces;
using Ecommerce.IdentityService.Application.Interfaces.Caching;
using Ecommerce.IdentityService.Application.Interfaces.Dapper;
using Ecommerce.IdentityService.Application.Interfaces.Token;
using Ecommerce.IdentityService.Application.Interfaces.User;
using Ecommerce.IdentityService.Infrastructure.Auth;
using Ecommerce.IdentityService.Infrastructure.Persistence.Dapper;
using Ecommerce.IdentityService.Infrastructure.Persistence.Repositories.DapperRepository;
using Ecommerce.IdentityService.Infrastructure.Persistence.Repositories.User;
using Ecommerce.IdentityService.Infrastructure.Persistence.TypeHandlers;
using Ecommerce.IdentityService.Infrastructure.Services.Caching;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Ecommerce.IdentityService.Infrastructure;

public static class InfrastructureServiceRegistration
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration config)
    {
        SqlMapper.AddTypeHandler(new EmailTypeHandler());
        services.AddJwtAuthentication(config);
        services.AddSingleton<IDbConnectionFactory, DbConnectionFactory>();
        services.AddScoped(sp => sp.GetRequiredService<IDbConnectionFactory>().CreateConnection());
        services.AddMemoryCache();
        services.AddScoped<ICacheService, MemoryCacheService>();
        services.AddScoped<IDapperRepository,DapperRepository>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IRoleRepository, RoleRepository>();
        services.AddScoped<IRefreshTokenRepository, RefreshTokenRepository>();
        services.AddScoped<IUserRoleRepository, UserRoleRepository>();
        services.AddScoped<ITokenService, TokenService>();
        services.AddScoped<IPermissionRepository, PermissionRepository>();
        services.AddScoped<IResetTokenService, ResetTokenService>();

        return services;
    }
}