/*
 * Logging.cs
 *
 *   Created: 2022-12-10-11:38:03
 *   Modified: 2022-12-10-11:38:03
 *
 *   Author: David G. Moore, Jr, <david@dgmjr.io>
 *
 *   Copyright © 2022-2023 David G. Moore, Jr,, All Rights Reserved
 *      License: MIT (https://opensource.org/licenses/MIT)
 */

using System.Net.Http.Headers;
using System.Net.Mime.MediaTypes;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.HttpLogging;
using Microsoft.Extensions.Logging;

namespace Microsoft.Extensions.DependencyInjection;

public static class AddLoggingExtensions
{
    public static WebApplicationBuilder AddHttpLogging(this WebApplicationBuilder builder)
    {
        builder.Services.AddHttpLogging(opts =>
        {
            opts.LoggingFields = HttpLoggingFields.All;
            new[]
            {
                HttpRequestHeaderNames.Authorization,
                HttpRequestHeaderNames.ContentType,
                HttpRequestHeaderNames.UserAgent,
                HttpRequestHeaderNames.Accept,
                HttpRequestHeaderNames.Cookie
            }.Select(x => opts.RequestHeaders.Add(x));
            opts.MediaTypeOptions.AddText(ApplicationMediaTypeNames.Json);
            opts.MediaTypeOptions.AddText(TextMediaTypeNames.Plain);
            opts.MediaTypeOptions.AddText(ApplicationMediaTypeNames.Xml);
            new[]
            {
                HttpResponseHeaderNames.ContentType,
                HttpResponseHeaderNames.Location,
                HttpResponseHeaderNames.SetCookie
            }.Select(x => opts.RequestHeaders.Add(x));
            ;
        });
        return builder;
    }

    public static IServiceCollection AddLogging(this IServiceCollection services)
    {
        services.AddLogging(builder =>
        {
            builder.AddConsole();
            builder.AddDebug();
        });
        return services;
    }
}
