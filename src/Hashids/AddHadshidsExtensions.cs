using System.Collections.Immutable;

/*
 * AddHadshids.cs
 *
 *   Created: 2022-12-20-01:16:56
 *   Modified: 2022-12-20-01:16:56
 *
 *   Author: David G. Moore, Jr, <david@dgmjr.io>
 *
 *   Copyright © 2022-2023 David G. Moore, Jr,, All Rights Reserved
 *      License: MIT (https://opensource.org/licenses/MIT)
 */
namespace Microsoft.Extensions.DependencyInjection;

using global::AspNetCore.Hashids;
using global::AspNetCore.Hashids.Options;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;

public static class AddHashidsExtensions
{
    const string HashidsOptionsConfigKey = nameof(HashidsOptions);

#if NET6_0_OR_GREATER
    public static WebApplicationBuilder AddHashids(this WebApplicationBuilder builder)
    {
        builder.Services.AddHashids(builder.Configuration);
        return builder;
    }
#endif

    public static IServiceCollection AddHashids(
        this IServiceCollection services,
        IConfigurationRoot config
    )
    {
        services.Configure<HashidsOptions>(
            opts => config.GetSection(nameof(HashidsOptions)).Bind(opts)
        );
        return services;
    }
}
