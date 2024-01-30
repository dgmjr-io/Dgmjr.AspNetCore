using System.Security.Claims;

using Microsoft.Kiota.Abstractions.Authentication;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Dgmjr.Graph.TokenProviders;
using IAuthenticationProvider = Microsoft.Graph.IAuthenticationProvider;
using Microsoft.ApplicationInsights;

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
        services.Configure<AzureAdB2CGraphOptions>(configSection);
        services.AddScoped<IApplicationService, ApplicationService>();
        services.ConfigureAll<MicrosoftIdentityOptions>(options =>
        {
            options.Events.OnTokenValidated = OnTokenValidated;
        });
        services.AddPassphraseGenerator(config);
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

    private static async Task OnTokenValidated(TokenValidatedContext context)
    {
        using var scope = context.HttpContext.RequestServices.CreateScope();
        using var activity = Dgmjr.Graph.Telemetry.Activities.TokenAcquisitionActivitySource.StartActivity(
            nameof(OnTokenValidated),
            ActivityKind.Client
        );
        var logger = scope.ServiceProvider.GetRequiredService<ILogger<MicrosoftGraphAutoConfigurator>>();
        logger.BeginningSupplementaryTokenAcquisitionAndCreation(context.Principal);
        activity.AddTag("UserObjectId", context.Principal.GetObjectId());
        activity.AddTag("UserTenantId", context.Principal.GetTenantId());

        var services = scope.ServiceProvider;
        var tokenAcquisition = services.GetRequiredService<ITokenAcquisition>();
        var graphClientOptions = services.GetRequiredService<IOptions<AzureAdB2CGraphOptions>>().Value;

        var graphClient = new GraphServiceClient(
            new BaseBearerTokenAuthenticationProvider(
                new TokenAcquisitionTokenProvider(
                    tokenAcquisition,
                    [MsGraphScopes.Default],
                    context.Principal
                )
            ) as IAuthenticationProvider
        );
        var me = await graphClient.Me.Request().GetAsync();
        var app = await graphClient.Applications[graphClientOptions.AzureAdB2CExtensionsApplicationId.ToString()].Request().GetAsync();
        var appRoles = app.AppRoles;
        var myAppRoles = me.AppRoleAssignments.Where(x => x.ResourceId == graphClientOptions.AzureAdB2CExtensionsApplicationId).ToList();
        var claims = new List<Claim>();
        foreach (var appRole in myAppRoles)
        {
            var theAppRole = appRoles.FirstOrDefault(x => x.Id.ToString() == appRole.Id);
            if(theAppRole != null)
            {
                claims.Add(new(ClaimTypes.Role, theAppRole.Value));
            }
        }
        logger.SupplementaryTokenAcquisitionAndCreationComplete(context.Principal);
    }
}
