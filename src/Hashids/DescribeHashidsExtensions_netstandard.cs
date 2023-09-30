/*
 * DescribeHashidsExtensions_netstandard.cs
 *
 *   Created: 2023-01-05-06:20:53
 *   Modified: 2023-01-05-06:21:06
 *
 *   Author: David G. Moore, Jr, <david@dgmjr.io>
 *
 *   Copyright © 2022-2023 David G. Moore, Jr,, All Rights Reserved
 *      License: MIT (https://opensource.org/licenses/MIT)
 */
using System.Reflection;

namespace Microsoft.Extensions.DependencyInjection;

using Dgmjr.AspNetCore.Hashids;

public static partial class DescribeHashidsExtensions
{
    public static IServiceCollection DescribeHashids(
        this IServiceCollection services,
        params Assembly[]? assemblies
    )
    {
        services.ConfigureSwaggerGen(options => options.OperationFilter<HashidsOperationFilter>());
        // assemblies ??= AppDomain.CurrentDomain.GetAssemblies();
        // builder.Services.DescribeHashidsFromAssemblies(assemblies);
        return services;
    }
}
