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

namespace Microsoft.Extensions.DependencyInjection;

internal static class DgmjrHealthChecksExtensions
{
    public static IHealthChecksBuilder AddDgmjrHealthChecks(
        this WebApplicationBuilder webApplicationBuilder,
        Action<IHealthChecksBuilder>? configure = default!
    )
    {
        builder.Services.AddHealthChecks();
        return builder;
    }
}
