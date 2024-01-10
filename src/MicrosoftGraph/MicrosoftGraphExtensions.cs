namespace Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Identity.Web;
using Dgmjr.MicrosoftGraph;
using Dgmjr.Web.DownstreamApis;
using static Dgmjr.Graph.MsGraphConstants;

public static class MicrosoftGraphExtensions
{
    public static IServiceCollection AddMicrosoftGraph(this IServiceCollection services, IConfiguration config)
    {
        services.AddMicrosoftGraph(options => config.Bind(options))
            .ConfigureDownstreamApi(
                MicrosoftGraph,
                config.GetSection(DownstreamApis_MicrosoftGraph)
            );
        services.AddScoped<IUsersService, UsersService>();
        services.AddSingleton<IPassphraseGenerator, PassphraseGenerator>();
        return services;
    }

    public static IServiceCollection AddPassphraseGenerator(this IServiceCollection services, IConfiguration config)
    {
        services.Configure<PassphraseGeneratorOptions>(config.GetSection(PassphraseGeneratorOptions.AppSettingsKey));
        services.AddSingleton<IPassphraseGenerator, PassphraseGenerator>();
        return services;
    }
}
