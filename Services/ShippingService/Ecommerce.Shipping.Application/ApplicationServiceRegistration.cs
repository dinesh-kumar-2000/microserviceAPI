using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace Ecommerce.Shipping.Application;

public static class ApplicationServiceRegistration
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        // Register MediatR handlers, requests, and notifications
        services.AddMediatR(cfg =>
            cfg.RegisterServicesFromAssemblyContaining(typeof(ApplicationServiceRegistration)));





        // Register all FluentValidation validators in this assembly
        services.AddValidatorsFromAssemblyContaining(typeof(ApplicationServiceRegistration));

        // Register all AutoMapper profiles in the assembly (finds ProductMappingProfile automatically)
        //services.AddAutoMapper(typeof(UserMappingProfile).Assembly);

        return services;
    }
}
