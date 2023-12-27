/*
 * AddHealthChecks.cs
 *
 *   Created: 2023-01-03-07:17:59
 *   Modified: 2023-01-03-07:17:59
 *
 *   Author: David G. Moore, Jr, <david@dgmjr.io>
 *
 *   Copyright © 2022-2023 David G. Moore, Jr,, All Rights Reserved
 *      License: MIT (https://opensource.org/licenses/MIT)
 */

using Microsoft.AspNetCore.Builder;

namespace Microsoft.Extensions.DependencyInjection;

public static class DgmjrHealthChecksExtensions
{
    public static IHealthChecksBuilder AddDgmjrHealthChecks(
        this WebApplicationBuilder webApplicationBuilder,
        Action<IHealthChecksBuilder>? configure = default!
    )
    {
        var healthChecksBuilder = webApplicationBuilder.Services.AddHealthChecks();
        configure?.Invoke(healthChecksBuilder);
        return healthChecksBuilder;
    }
}
