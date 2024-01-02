/*
 * ResponsePayloadOutputFormatterSelector.cs
 *
 *   Created: 2022-12-19-02:31:16
 *   Modified: 2022-12-19-02:31:19
 *
 *   Author: David G. Moore, Jr, <david@dgmjr.io>
 *
 *   Copyright © 2022-2023 David G. Moore, Jr,, All Rights Reserved
 *      License: MIT (https://opensource.org/licenses/MIT)
 */
namespace Dgmjr.Payloads.Infrastructure;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using MvcJsonOptions = Microsoft.AspNetCore.Mvc.JsonOptions;

public class ResponsePayloadOutputFormatterSelector : OutputFormatterSelector
{
    /// <inheritdoc />
    ///// <include
    public override IOutputFormatter SelectFormatter(
        OutputFormatterCanWriteContext context,
        IList<IOutputFormatter> formatters,
        MediaTypeCollection mediaTypes
    )
    {
        var payload = context.Object as IResponsePayload;
        var acceptHeader = context.HttpContext.Request
            .GetTypedHeaders()
            .Accept.Select(a => a.MediaType.Value.ToLower());
        if (payload is not null)
        {
            var contentType = context.ContentType.ToString();
            var formatter = formatters.FirstOrDefault(f =>
            {
                var @of = f as OutputFormatter;
                var mediaTypesIntersection = @of?.SupportedMediaTypes?.Intersect(acceptHeader);
                contentType = mediaTypesIntersection?.FirstOrDefault() ?? contentType;
                return mediaTypesIntersection?.Any() ?? false;
            });
            if (formatter is not null)
            {
                context.HttpContext.Response.ContentType = contentType;
                return formatter;
            }
        }
#if NET5_0_OR_GREATER
        return new Microsoft.AspNetCore.Mvc.Formatters.SystemTextJsonOutputFormatter(
            context.HttpContext.RequestServices
                .GetRequiredService<IOptions<MvcJsonOptions>>()
                .Value.JsonSerializerOptions
        );
#else
        return default;
#endif
    }
}
