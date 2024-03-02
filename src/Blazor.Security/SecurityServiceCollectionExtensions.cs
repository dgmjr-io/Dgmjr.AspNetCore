namespace Microsoft.Extensions.DependencyInjection;
using Dgmjr.Blazor.Security.Services;

public static class SecurityServiceCollectionExtensions
{
    public static IServiceCollection AddBlazorSecurityService(this IServiceCollection services)
    {
        services.AddScoped<ISecurityService, SecurityService>();
        return services;
    }
}
