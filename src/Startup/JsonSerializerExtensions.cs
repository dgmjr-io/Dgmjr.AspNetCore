/*
 * AddJsonSerializer.cs
 *
 *   Created: 2022-12-17-01:35:35
 *   Modified: 2022-12-17-01:35:35
 *
 *   Author: David G. Moore, Jr, <david@dgmjr.io>
 *
 *   Copyright © 2022-2023 David G. Moore, Jr,, All Rights Reserved
 *      License: MIT (https://opensource.org/licenses/MIT)
 */

namespace Microsoft.Extensions.DependencyInjection;

using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection.Extensions;

internal static class JsonSerializerExtensions
{
    public static WebApplicationBuilder AddJsonSerializer(this WebApplicationBuilder builder)
    {
        _ = builder.Services
            .AddControllers()
            .AddJsonOptions(x =>
            {
                x.AllowInputFormatterExceptionMessages = true;
                x.JsonSerializerOptions.AllowTrailingCommas = true;
                x.JsonSerializerOptions.DefaultIgnoreCondition = JIgnore.WhenWritingNull;
                x.JsonSerializerOptions.DictionaryKeyPolicy = JsonNamingPolicy.CamelCase;
                x.JsonSerializerOptions.IgnoreReadOnlyFields = false;
                x.JsonSerializerOptions.IgnoreReadOnlyProperties = false;
                x.JsonSerializerOptions.IncludeFields = true;
                x.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
                x.JsonSerializerOptions.NumberHandling =
                    JNumberHandling.AllowReadingFromString
                    | JNumberHandling.AllowNamedFloatingPointLiterals;
                x.JsonSerializerOptions.ReadCommentHandling = JCommentHandling.Skip;
                x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
                x.JsonSerializerOptions.UnknownTypeHandling = JsonUnknownTypeHandling.JsonElement;
                x.JsonSerializerOptions.WriteIndented = true;
                x.JsonSerializerOptions.Converters.Add(new JStringEnumConverter());
            });
        builder.Services.AddSingleton(y =>
        {
            var jso = new Jso(JsonSerializerDefaults.Web)
            {
                AllowTrailingCommas = true,
                DefaultIgnoreCondition = JIgnore.WhenWritingNull,
                DictionaryKeyPolicy = JsonNamingPolicy.CamelCase,
                IgnoreReadOnlyFields = false,
                IgnoreReadOnlyProperties = false,
                IncludeFields = true,
                PropertyNameCaseInsensitive = true,
                NumberHandling =
                    JNumberHandling.AllowReadingFromString
                    | JNumberHandling.AllowNamedFloatingPointLiterals,
                ReadCommentHandling = JCommentHandling.Allow,
                ReferenceHandler = ReferenceHandler.IgnoreCycles,
                UnknownTypeHandling = JsonUnknownTypeHandling.JsonElement,
                WriteIndented = true
            };
            jso.Converters.Add(new JStringEnumConverter());
            y.GetServices<JConverter>()
                .Select(converter =>
                {
                    jso.Converters.Add((converter));
                    return true;
                });
            return jso;
        });
        return builder;
    }

    public static WebApplicationBuilder AddJsonConverter<TConverter, TImplementation>(
        this WebApplicationBuilder builder
    )
        where TConverter : JConverter
        where TImplementation : TConverter
    {
        builder.Services.TryAddEnumerable(
            new ServiceDescriptor(typeof(TConverter), typeof(TImplementation))
        );
        return builder;
    }

    public static WebApplicationBuilder AddJsonConverter<TConverter, TImplementation>(
        this WebApplicationBuilder builder,
        TImplementation implementation
    )
        where TConverter : JConverter
        where TImplementation : TConverter
    {
        builder.Services.TryAddEnumerable(
            new ServiceDescriptor(typeof(TConverter), implementation)
        );
        return builder;
    }

    public static WebApplicationBuilder AddJsonConverter<TConverter, TImplementation>(
        this WebApplicationBuilder builder,
        Func<IServiceProvider, TImplementation> factory
    )
        where TConverter : JConverter
        where TImplementation : TConverter
    {
        builder.Services.TryAddEnumerable(new ServiceDescriptor(typeof(TConverter), factory));
        return builder;
    }
}
