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
using Dgmjr.Mime;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.HttpLogging;
using Microsoft.Extensions.Logging;

namespace Microsoft.Extensions.DependencyInjection;

internal static class AddLoggingExtensions
{
    /// <summary>
    /// Extension method to add HTTP request and response logging to the WebApplicationBuilder.
    /// </summary>
    /// <param name="builder">The WebApplicationBuilder object.</param>
    /// <returns>The WebApplicationBuilder object with HTTP logging configured.</returns>
    public static WebApplicationBuilder AddHttpLogging(this WebApplicationBuilder builder)
    {
        // Add HTTP logging options to the services collection
        builder.Services.AddHttpLogging(opts =>
        {
            // Configure the options
            opts.LoggingFields = HttpLoggingFields.All;

            // Add request headers to log
            new[]
            {
                HReqH.Authorization.DisplayName,
                HReqH.ContentType.DisplayName,
                HReqH.UserAgent.DisplayName,
                HReqH.Accept.DisplayName,
                HReqH.Cookie.DisplayName
            }.ForEach(x => opts.RequestHeaders.Add(x));

            // Add response media types to log
            opts.MediaTypeOptions.AddText(ApplicationMediaType.Json.DisplayName);
            opts.MediaTypeOptions.AddText(TextMediaType.Plain.DisplayName);
            opts.MediaTypeOptions.AddText(ApplicationMediaType.Xml.DisplayName);

            // Add response headers to log
            _ = new[]
            {
                HResH.ContentType.DisplayName,
                HResH.Location.DisplayName,
                HResH.SetCookie.DisplayName
            }.Select(x => opts.RequestHeaders.Add(x));
        });

        return builder;
    }

    /// <summary>
    /// Extension method to add logging to the given IServiceCollection.
    /// </summary>
    /// <param name="services">The IServiceCollection to add logging to.</param>
    /// <returns>The same IServiceCollection with logging configured.</returns>
    public static IServiceCollection AddLogging(this IServiceCollection services)
    {
        // Add logging providers to the builder
        services.AddLogging(builder =>
        {
            // Add console logging provider
            builder.AddConsole();

            // Add debug logging provider
            builder.AddDebug();
        });

        return services;
    }
}
