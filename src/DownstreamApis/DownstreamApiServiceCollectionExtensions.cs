namespace Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;

public static class DownstreamApiServiceCollectionExtensions
{
    public static IServiceCollection ConfigureDownstreamApi(
        this IServiceCollection services,
        string name,
        Action<DownstreamApiOptions> configureOptions
    )
    {
        services.Configure(name, configureOptions);
        services.AddHttpClient(name);
        services.AddSingleton<
            IConfigureOptions<DownstreamApiOptions>,
            DownstreamApiOptionsConfigurator
        >();
        return services;
    }

    public static IServiceCollection ConfigureDownstreamApi(
        this IServiceCollection services,
        string name,
        IConfiguration configuration
    )
    {
        services.Configure<DownstreamApiOptions>(name, configuration);
        services.AddHttpClient(name);
        services.AddSingleton<
            IConfigureOptions<DownstreamApiOptions>,
            DownstreamApiOptionsConfigurator
        >();
        return services;
    }
    public static IServiceCollection ConfigureDownstreamApi(
        this IServiceCollection services,
        Action<DownstreamApiOptions> configureOptions
    )
    => services.ConfigureDownstreamApi(
        nameof(DownstreamApis),
        configureOptions
    );

    public static IServiceCollection ConfigureDownstreamApi(
        this IServiceCollection services,
        IConfiguration configuration
    )
    => services.ConfigureDownstreamApi(
        nameof(DownstreamApis),
        configuration
    );
}
