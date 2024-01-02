namespace Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Identity.Web;
using Dgmjr.MicrosoftGraph;
using Dgmjr.Web.DownstreamApis;

public static class MicrosoftGraphExtensions
{
    public static IServiceCollection AddMicrosoftGraph(this IServiceCollection services, IConfiguration config)
    {
        services.AddMicrosoftGraph(options => config.Bind(options))
            .ConfigureDownstreamApi(
                Dgmjr.MicrosoftGraph.MicrosoftGraphOptions.AppSettingsKey,
                config.GetSection($"{DownstreamApisBase.AppSettingsKey}:{Dgmjr.MicrosoftGraph.MicrosoftGraphOptions.AppSettingsKey}")
            );
        return services;
    }
}
