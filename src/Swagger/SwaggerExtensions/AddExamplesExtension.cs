﻿/*
 * AddExamplesExtension.cs
 *
 *   Created: 2022-12-19-05:33:50
 *   Modified: 2022-12-19-05:33:50
 *
 *   Author: David G. Moore, Jr, <david@dgmjr.io>
 *
 *   Copyright © 2022-2023 David G. Moore, Jr,, All Rights Reserved
 *      License: MIT (https://opensource.org/licenses/MIT)
 */

using Microsoft.AspNetCore.Builder;
using Swashbuckle.AspNetCore.Filters;

namespace Microsoft.Extensions.DependencyInjection;

internal static partial class InternalSwaggerExtensions
{
    public static WebApplicationBuilder AddSwaggerExamples(
        this WebApplicationBuilder builder,
        params Assembly[]? assemblies
    )
    {
        assemblies ??= CurrentDomain.GetAssemblies();
        builder.Services.AddSwaggerExamplesFromAssemblies(assemblies);
        return builder;
    }
}
