/*
 * StartupExtensions.cs
 *
 *   Created: 2022-12-10-04:48:32
 *   Modified: 2022-12-10-04:48:32
 *
 *   Author: David G. Moore, Jr, <david@dgmjr.io>
 *
 *   Copyright © 2022-2023 David G. Moore, Jr,, All Rights Reserved
 *      License: MIT (https://opensource.org/licenses/MIT)
 */

namespace Microsoft.Extensions.DependencyInjection;
using Dgmjr.AspNetCore.Formatters;
using MessagePack;
using MessagePack.AspNetCoreMvcFormatter;
using MessagePack.Resolvers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc.Formatters;

internal static class StartupExtensions
{
    public static WebApplicationBuilder AddFormatters(this WebApplicationBuilder builder)
    {
        _ = builder.Services
            .AddControllers(options =>
            {
                options.RespectBrowserAcceptHeader = true;
                options.ReturnHttpNotAcceptable = true;

                options.OutputFormatters.Insert(
                    0,
                    new Dgmjr.Payloads.Formatters.PlainTextPayloadFormatter()
                );
                options.InputFormatters.Insert(0, new PlainTextInputFormatter());

                options.OutputFormatters.Insert(0, new XmlSerializerOutputFormatter());
                options.OutputFormatters.Insert(0, new XmlDataContractSerializerOutputFormatter());
                options.OutputFormatters.Insert(0, new BsonOutputFormatter());
                options.OutputFormatters.Insert(0, new PlainTextProblemDetailsOutputFormatter());
                options.OutputFormatters.Insert(0, new PlainTextOutputFormatter());

                options.OutputFormatters.Insert(
                    0,
                    new MessagePackOutputFormatter(
                        new MessagePackSerializerOptions(ContractlessStandardResolver.Instance)
                    )
                );
                options.InputFormatters.Insert(
                    0,
                    new MessagePackInputFormatter(
                        new MessagePackSerializerOptions(ContractlessStandardResolver.Instance)
                    )
                );

                // options.InutFormatters.Add(new XmlSerializerInputFormatter());
            })
            .AddXmlSerializerFormatters()
            .AddXmlDataContractSerializerFormatters();
        _ = builder.AddPayloadFormatters();
        _ = builder.AddInputFormatters();
        return builder;
    }

    public static WebApplicationBuilder AddInputFormatters(this WebApplicationBuilder builder)
    {
        _ = builder.Services.AddControllers(options => { });
        return builder;
    }

    // public static WebApplicationBuilder AddApiAuthentication(this WebApplicationBuilder builder, Action<ApiKeyAuthenticationOptions> configureOptions)
    // {
    //     builder.Services.AddAuthentication(ApiKeyAuthenticationOptions.AuthenticationSchemeName)
    //         .AddScheme<ApiKeyAuthenticationOptions, ApiKeyAuthenticationHandler>(ApiKeyAuthenticationOptions.AuthenticationSchemeName, configureOptions);
    //     builder.Services.AddAuthorization(options =>
    //     {
    //         options.AddPolicy("Admin", policy => policy.RequireRole("admin"));
    //         options.AddPolicy("User", policy => policy.RequireRole("user"));
    //     });
    //     return builder;
    // }
}
