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

using Dgmjr.Mime;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;

public static class PingExtensions
{
    /// <summary>Adds a simple health check to the app</summary>
    public static WebApplication MapPing(this WebApplication app)
    {
        _ = app.MapGet("/ping", () => "pong")
            .Produces<string>(contentType: Text.Plain.DisplayName)
            .AllowAnonymous()
            .WithDisplayName("Ping")
            .WithName("Ping")
            .WithTags(["Diagnostics"])
#if NET8_0_OR_GREATER
            .WithOpenApi(op =>
            {
                op.Responses["200"] = new()
                {
                    Description = "Pong",
                    Content =
                    {
                        [Text.Plain.DisplayName] = new()
                        {
                            Schema = new() { Type = "pong", Description = "a simple reply" },
                            Example = new OpenApiString("pong")
                        }
                    }
                };
                return op;
            })
#endif
        ;

        _ = app.MapHealthChecks(
                "/health-check",
                new()
                {
                    AllowCachingResponses = false,
                    ResponseWriter = async (ctx, rpt) => await ctx.Response.WriteAsJsonAsync(rpt),
                    Predicate = _ => true
                }
            )
            .WithDisplayName("Health Check").WithName("Health Check").AllowAnonymous()//.Produces<HealthReport>(200, contentType: Dgmjr.Mime.Application.Json.DisplayName)
#if NET8_0_OR_GREATER
            .WithOpenApi(op =>
            {
                op.Responses["200"] = new()
                {
                    Description = "Health Check Response",
                    Content =
                    {
                        [Dgmjr.Mime.Application.Json.DisplayName] = new()
                        {
                            Schema = new()
                            {
                                Reference = new()
                                {
                                    Type = ReferenceType.Schema,
                                    Id = typeof(HealthReport).FullName
                                }
                            }
                        }
                    }
                };
                return op;
            })
#endif
            ;

        return app;
    }
}
