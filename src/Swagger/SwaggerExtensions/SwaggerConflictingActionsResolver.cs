﻿/*
 * SwaggerConflictingActionsResolver.cs
 *
 *   Created: 2022-12-16-07:09:19
 *   Modified: 2022-12-16-07:09:20
 *
 *   Author: David G. Moore, Jr, <david@dgmjr.io>
 *
 *   Copyright © 2022-2023 David G. Moore, Jr,, All Rights Reserved
 *      License: MIT (https://opensource.org/licenses/MIT)
 */

using Microsoft.AspNetCore.Builder;

namespace Microsoft.Extensions.DependencyInjection;

internal static partial class InternalSwaggerExtensions
{
    public static WebApplicationBuilder AddSwaggerConflictingActionsResolver(
        this WebApplicationBuilder builder
    )
    {
        builder.Services.ConfigureSwaggerGen(
            options => options.ResolveConflictingActions(apiDescriptions => apiDescriptions.First())
        );
        return builder;
    }
}
