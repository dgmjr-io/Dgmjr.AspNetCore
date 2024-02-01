using System.Security.Claims;

using Microsoft.Kiota.Abstractions.Authentication;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Dgmjr.Graph.TokenProviders;
using IAuthenticationProvider = Microsoft.Graph.IAuthenticationProvider;
using Microsoft.ApplicationInsights;
using Dgmjr.Graph.Configuration;

namespace Microsoft.Extensions.DependencyInjection;

public static class MicrosoftGraphServiceCollectionExtensions
{
    public static IServiceCollection AddMicrosoftGraph(
        this IServiceCollection services,
        IConfiguration config
    )
    {
        var configSection = config.GetSection(DownstreamApis_MicrosoftGraph);
        var options = configSection.Get<AzureAdB2CGraphOptions>();
        services
            .AddMicrosoftGraph(options => config.Bind(options))
            .AddMicrosoftIdentityConsentHandler()
            .ConfigureDownstreamApi(MicrosoftGraph, configSection);
        services.AddScoped<IUsersService, UsersService>();
        services.AddScoped<IDirectoryObjectsService, DirectoryObjectsService>();
        services.Configure<AzureAdB2CGraphOptions>(configSection);
        services.AddScoped<IApplicationService, ApplicationService>();
        services.AddPassphraseGenerator(config);
        services.AddSingleton<IConfigureOptions<MicrosoftIdentityOptions>, UserAppRolesConfigurator>();
        return services;
    }

    public static IServiceCollection AddPassphraseGenerator(
        this IServiceCollection services,
        IConfiguration config
    )
    {
        services.Configure<PassphraseGeneratorOptions>(
            config.GetSection(PassphraseGeneratorOptions.AppSettingsKey)
        );
        services.AddSingleton<IPassphraseGenerator, PassphraseGenerator>();
        return services;
    }
}
