/*
 * DI.cs
 *
 *   Created: 2022-12-06-10:43:40
 *   Modified: 2022-12-06-10:43:40
 *
 *   Author: David G. Moore, Jr, <david@dgmjr.io>
 *
 *   Copyright © 2022-2023 David G. Moore, Jr,, All Rights Reserved
 *      License: MIT (https://opensource.org/licenses/MIT)
 */
#pragma warning disable

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Microsoft.Extensions.DependencyInjection;

public static class DI
{
    public static IServiceCollection AddJsonPatch(this IServiceCollection services) =>
        services
            .AddControllers(options =>
            {
                options.InputFormatters.Insert(
                    0,
                    MyJsonPatchInputFormatter.GetJsonPatchInputFormatter()
                );
            })
            .Services;

    public static WebApplicationBuilder AddJsonPatch(this WebApplicationBuilder builder)
    {
        builder.Services.AddControllers(options =>
        {
            options.InputFormatters.Insert(
                0,
                MyJsonPatchInputFormatter.GetJsonPatchInputFormatter()
            );
        });
        return builder;
    }
}

public static class MyJsonPatchInputFormatter
{
    public static NewtonsoftJsonPatchInputFormatter GetJsonPatchInputFormatter()
    {
        var builder = new ServiceCollection()
            .AddLogging()
            .AddMvc()
            .AddNewtonsoftJson()
            .Services.BuildServiceProvider();

        return builder
            .GetRequiredService<IOptions<MvcOptions>>()
            .Value.InputFormatters.OfType<NewtonsoftJsonPatchInputFormatter>()
            .First();
    }
}
