/*
 * DI.NET6_0_OR_GREATER.cs
 *
 *   Created: 2023-10-10-04:07:31
 *   Modified: 2023-10-10-04:07:31
 *
 *   Author: David G. Moore, Jr. <david@dgmjr.io>
 *
 *   Copyright © 2022 - 2023 David G. Moore, Jr., All Rights Reserved
 *      License: MIT (https://opensource.org/licenses/MIT)
 */
#if NET6_0_OR_GREATER
namespace Microsoft.Extensions.DependencyInjection;

using Dgmjr.Payloads.Infrastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;

public static partial class RegisterPayloadFormattersExtensions
{
    public static WebApplicationBuilder AddPayloadServices(this WebApplicationBuilder builder)
    {
        return builder.AddPayloadFormatters().DescribeRangeRequest();
    }

    public static WebApplicationBuilder AddPayloadFormatters(this WebApplicationBuilder builder)
    {
        builder.Services.AddPayloadFormatters();
        return builder;
    }

    public static WebApplicationBuilder DescribeRangeRequest(this WebApplicationBuilder builder)
    {
        builder.Services.ConfigureSwaggerGen(c =>
        {
            c.MapType<Dgmjr.Payloads.Range>(
                () =>
                    new OpenApiSchema
                    {
                        Type = "string",
                        Pattern = Dgmjr.Payloads.Range.RegexString,
                        Format = nameof(Dgmjr.Payloads.Range),
                        Description =
                            "Indicates the part of a resultset that the server should return.  It's a zero-based index from the start to the end if the desired resultset.  The format is \"items {start}-{end}\".  If the end is omitted, the server will return all items from the start to the end of the resultset.  If the start is omitted, the server will return all items from the beginning to the end of the resultset.  If both are omitted, the server will return all items in the resultset.  The server will return a 416 (Range Not Satisfiable) if the requested range is not satisfiable.",
                        Example = new OpenApiString("items 0-20"),
                        Default = new OpenApiString($"items 0-{int.MaxValue}")
                    }
            );
        });
        return builder;
    }
}
#endif
