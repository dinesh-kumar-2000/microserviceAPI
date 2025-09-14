using Ecommerce.IdentityService.Application.Mapper;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace Ecommerce.IdentityService.Application;

public static class ApplicationServiceRegistration
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(UserMappingProfile).Assembly);
        services.AddMediatR(cfg =>
            cfg.RegisterServicesFromAssemblyContaining(typeof(ApplicationServiceRegistration)));
        services.AddValidatorsFromAssemblyContaining(typeof(ApplicationServiceRegistration));
        return services;
    }
}
