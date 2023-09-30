/*
 * DessribeHadhidsExtensions.cs
 *
 *   Created: 2022-12-20-01:11:23
 *   Modified: 2022-12-20-01:11:23
 *
 *   Author: David G. Moore, Jr, <david@dgmjr.io>
 *
 *   Copyright © 2022-2023 David G. Moore, Jr,, All Rights Reserved
 *      License: MIT (https://opensource.org/licenses/MIT)
 */
using System.Reflection;
using Dgmjr.AspNetCore.Hashids;
using Microsoft.AspNetCore.Builder;

namespace Microsoft.Extensions.DependencyInjection;

public static partial class DescribeHashidsExtensions
{
#if NET6_0_OR_GREATER
    public static WebApplicationBuilder DescribeHashids(
        this WebApplicationBuilder builder,
        params Assembly[]? assemblies
    )
    {
        builder.Services.DescribeHashids();
        return builder;
    }
#endif
}
