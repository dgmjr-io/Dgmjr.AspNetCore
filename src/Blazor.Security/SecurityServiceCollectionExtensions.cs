using Dgmjr.Blazor.Security.Services;

namespace Microsoft.Extensions.DependencyInjection;

public static class SecurityServiceCollectionExtensions
{
    public static IServiceCollection AddSecurityService(this IServiceCollection services)
    {
        services.AddScoped<ISecurityService, SecurityService>();
        return services;
    }
}
