/*
 * AutoMapper.cs
 *
 *   Created: 2022-12-10-08:55:12
 *   Modified: 2022-12-10-08:55:13
 *
 *   Author: David G. Moore, Jr, <david@dgmjr.io>
 *
 *   Copyright © 2022-2023 David G. Moore, Jr,, All Rights Reserved
 *      License: MIT (https://opensource.org/licenses/MIT)
 */

namespace Microsoft.Extensions.DependencyInjection;

public static class AddAutoMapperExtensions
{
    public static IServiceCollection AddAutoMapper<T>(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(T));
        return services;
    }
}
