/*
 * DownstreamApiServiceCollectionExtensions.cs
 *
 *   Created: 2023-17-31T14:17:16-05:00
 *   Modified: 2024-16-28T14:16:16-05:00
 *
 *   Author: David G. Moore, Jr. <david@dgmjr.io>
 *
 *   Copyright © 2024 David G. Moore, Jr., All Rights Reserved
 *      License: MIT (https://opensource.org/licenses/MIT)
 */

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
    ) => services.ConfigureDownstreamApi(nameof(DownstreamApis), configureOptions);

    public static IServiceCollection ConfigureDownstreamApi(
        this IServiceCollection services,
        IConfiguration configuration
    ) => services.ConfigureDownstreamApi(nameof(DownstreamApis), configuration);
}
