/*
 * PingController.cs
 *
 *   Created: 2022-12-06-10:35:09
 *   Modified: 2022-12-06-10:35:09
 *
 *   Author: David G. Moore, Jr, <david@dgmjr.io>
 *
 *   Copyright © 2022-2023 David G. Moore, Jr,, All Rights Reserved
 *      License: MIT (https://opensource.org/licenses/MIT)
 */

namespace Dgmjr.AspNetCore.Controllers;

using System.Net.Mime.MediaTypes;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;

public static class PingExtensions
{
    /// <symmary>Adds a simple health check to the app</symmary>
    public static WebApplication MapPing(this WebApplication app)
    {
        _ = app.MapGet("/ping", () => "pong")
            .Produces<string>(contentType: TextMediaTypeNames.Plain)
            .AllowAnonymous()
            .WithDisplayName("Ping")
            .WithName("Ping")
            .WithTags("Diagnostics")
            .WithOpenApi(op =>
            {
                op.Responses["200"] = new()
                {
                    Description = "Pong",
                    Content =
                    {
                        [TextMediaTypeNames.Plain] = new()
                        {
                            Schema = new() { Type = "pong", Description = "a simple reply" },
                            Example = new OpenApiString("pong")
                        }
                    }
                };
                return op;
            });

        _ = app.MapHealthChecks(
                "/health-check",
                new()
                {
                    AllowCachingResponses = false,
                    ResponseWriter = async (ctx, rpt) => await ctx.Response.WriteAsJsonAsync(rpt),
                    Predicate = _ => true
                }
            )
            .WithTags("Diagnostics")
            .AllowAnonymous()
            .WithOpenApi(op =>
            {
                op.Responses["200"] = new()
                {
                    Description = "Pong",
                    Content =
                    {
                        [TextMediaTypeNames.Plain] = new()
                        {
                            Schema = new()
                            {
                                Reference = new()
                                {
                                    Type = ReferenceType.Schema,
                                    Id = typeof(HealthReport).Name
                                }
                            }
                        }
                    }
                };
                return op;
            });

        return app;
    }
}
