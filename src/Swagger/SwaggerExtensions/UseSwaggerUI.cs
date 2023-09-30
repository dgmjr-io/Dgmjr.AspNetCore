/*
 * UseSwaggerUI.cs
 *
 *   Created: 2022-12-14-04:11:17
 *   Modified: 2022-12-14-04:11:17
 *
 *   Author: David G. Moore, Jr, <david@dgmjr.io>
 *
 *   Copyright © 2022-2023 David G. Moore, Jr,, All Rights Reserved
 *      License: MIT (https://opensource.org/licenses/MIT)
 */

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using static Microsoft.AspNetCore.Http.StatusCodes;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;

using TextMediaTypeNames = Dgmjr.Mime.TextMediaTypeNames;
using MultipartMediaTypeNames = Dgmjr.Mime.MultipartMediaTypeNames;

using Swashbuckle.AspNetCore.SwaggerUI;

namespace Microsoft.Extensions.DependencyInjection;

public static partial class UseSwaggerUIExtensions
{
    private static readonly Assembly _assembly = typeof(UseSwaggerUIExtensions).Assembly;

    private static string GetManifestResourceString(string resourceName) =>
        new StreamReader(_assembly.GetManifestResourceStream(resourceName)).ReadToEnd();

    private static string CustomCss(string resourceName) => GetManifestResourceString(resourceName);

    // $$"""
    // /* Begin Swagger UI Base CSS */
    // {{GetManifestResourceString("swagger-ui.css")}}
    // /* End Swagger UI Base CSS */
    // /* Begin Swagger UI Custom CSS */
    // {{GetManifestResourceString(resourceName)}}
    // /* End Swagger UI Custom CSS */
    // """;

    const string ExampleCss = """"
    @charset "UTF-8";
    .swagger-ui html
    {
        box-sizing: border-box
    }

    .swagger-ui*, .swagger-ui :after, .swagger-ui :before {
        box-sizing: inherit
    }

    etc.etc.etc...
    """";

    static readonly OpenApiString _exampleCssOpenApiString = new(ExampleCss);

    public static WebApplication UseCustomizedSwaggerUI<TAssemblyResource>(
        this WebApplication app,
        type tThisAssemblyProject,
        string? indexDocumentAssemblyResourceName = "swaggerui.index.html",
        string? swaggerTheme = null
    )
    {
        var thisAssemblyProject = new TThisAssemblyStaticProxy(tThisAssemblyProject);
        var logger = app.Logger;
        var swaggerPath = $"/swagger/{thisAssemblyProject.ApiVersion}/swagger.json";
        _ = app.UseSwagger(options =>
        {
            options.RouteTemplate = swaggerPath;
        });
        _ = app.UseSwaggerUI(options =>
        {
            options.RoutePrefix = string.Empty;
            options.DefaultModelExpandDepth(0);
            options.DefaultModelRendering(ModelRendering.Model);
            options.DocExpansion(DocExpansion.List);
            options.DisplayOperationId();
            options.DisplayRequestDuration();
            options.EnableDeepLinking();
            options.EnableFilter();
            options.EnableTryItOutByDefault();
            options.EnablePersistAuthorization();
            options.ShowExtensions();
            options.ShowCommonExtensions();
            options.EnableValidator();
            options.SupportedSubmitMethods(
                SubmitMethod.Get,
                SubmitMethod.Post,
                SubmitMethod.Put,
                SubmitMethod.Delete,
                SubmitMethod.Patch,
                SubmitMethod.Head,
                SubmitMethod.Options,
                SubmitMethod.Trace
            );
            // options.Inje0ctStylesheet("/swagger-ui/SwaggerUI.custom.css");
            // try
            // {
            //     options.IndexStream = () =>
            //         typeof(TAssemblyResource).Assembly.GetManifestResourceStream(
            //             indexDocumentAssemblyResourceName
            //         );
            // }
            // catch
            // {
            //     app.Logger.CannotLoadIndexDocument(indexDocumentAssemblyResourceName);
            // }

            options.SwaggerEndpoint(
                swaggerPath,
                $"{thisAssemblyProject.Title} {thisAssemblyProject.ApiVersion}"
            );
        });

        _ = app.MapGet(
                "swagger-ui/SwaggerUI.custom.css",
                () => new CssResult(CustomCss(swaggerTheme + ".css"))
            )
            .WithOpenApi(op =>
            {
                op.Responses["200"] = new OpenApiResponse
                {
                    Description = "Swagger UI CSS",
                    Content =
                    {
                        [TextMediaTypeNames.Css] = new OpenApiMediaType
                        {
                            Schema = new OpenApiSchema
                            {
                                Type = TextMediaTypeNames.Css,
                                Description = "swagger ui css"
                            },
                            Example = _exampleCssOpenApiString
                        }
                    }
                };
                return op;
            })
            .WithName("SwaggerUI.custom.css")
            .WithGroupName("Style")
            .WithSummary("Custom CSS for Swagger UI")
            .WithTags(new[] { "Style" })
            .Produces<string>(Status200OK, TextMediaTypeNames.Css);

        // _ = app.MapGet(
        //         "/swagger-ui/SwaggerUI.custom.css",
        //         () =>
        //             CustomCss(
        //                 swaggerTheme ?? new ThisAssemblyProject(tThisAssemblyProject).SwaggerTheme
        //             )
        //     )
        //     .WithOpenApi(op =>
        //     {
        //         op.Responses["200"] = new OpenApiResponse
        //         {
        //             Description = "Custom CSS",
        //             Content =
        //             {
        //                 [TextMediaTypeNames.Css] = new OpenApiMediaType
        //                 {
        //                     Schema = new OpenApiSchema
        //                     {
        //                         Type = TextMediaTypeNames.Css,
        //                         Description = "custom css"
        //                     },
        //                     Example = _exampleCssOpenApiString
        //                 }
        //             }
        //         };
        //         return op;
        //     })
        //     .Produces<string>(Status200OK, TextMediaTypeNames.Css);

        foreach (var cssFile in _assembly.GetManifestResourceNames().Where(x => x.EndsWith(".css")))
        {
            _ = app.MapGet($"/swagger-ui/{cssFile}", () => new CssResult(CustomCss(cssFile)))
                .WithOpenApi(op =>
                {
                    op.Responses["200"] = new OpenApiResponse
                    {
                        Description = "Custom CSS - " + cssFile,
                        Content =
                        {
                            [TextMediaTypeNames.Css] = new OpenApiMediaType
                            {
                                Schema = new OpenApiSchema
                                {
                                    Format = TextMediaTypeNames.Css,
                                    Type = TextMediaTypeNames.Css,
                                    Description = "custom css"
                                },
                                Example = _exampleCssOpenApiString
                            }
                        }
                    };
                    return op;
                })
                .WithTags("style", "ui")
                .Produces<string>(Status200OK, TextMediaTypeNames.Css);
        }

        Console.WriteLine($"thisAssemblyProject.Version: {thisAssemblyProject.ApiVersion}");

        _ = app.MapGet(
            $"/swagger/{thisAssemblyProject.ApiVersion}/swagger.json",
            ctx =>
            {
                ctx.Response.Redirect($"/swagger/v1/swagger.json");
                return Task.CompletedTask;
            }
        );

        _ = app.UseRewriter(
                new RewriteOptions().AddRedirect("^$", "swagger-ui/SwaggerUI.custom.css")
            )
            .UseRewriter(new RewriteOptions().AddRedirect("swagger-ui.css", "swagger-ui"));

        _ = app.UseReDoc(opts =>
        {
            opts.DocumentTitle = thisAssemblyProject.Title;
            opts.SpecUrl = $"/swagger/{thisAssemblyProject.ApiVersion}/swagger.json";
            opts.OnlyRequiredInSamples();
            opts.HeadContent += $$$""""
            <script type="application/javascript" src="https://cdn.jsdelivr.net/npm/redoc-try-it-out/dist/try-it-out.min.js"></script>
            {{{opts.HeadContent}}}
            <script>
                var redoc_container = document.createElement("div");
                document.body.appendChild(redoc_container);
                RedocTryItOut.init(
                        "{{{opts.SpecUrl}}}",
                        { title: ""{{{thisAssemblyProject.Title}}}"" },
                        redoc_container
            </script>
            """";
        });

        return app;
    }

    [LoggerMessage(
        EventId = 0,
        Level = LogLevel.Warning,
        Message = "Cannot load index document from assembly resource '{indexDocumentAssemblyResourceName}'."
    )]
    internal static partial void CannotLoadIndexDocument(
        this ILogger logger,
        string indexDocumentAssemblyResourceName
    );

    public static WebApplication UseCustomizedSwaggerUI(
        this WebApplication app,
        type tThisAssemblyProject,
        string indexDocumentAssemblyResourceName = "SwaggerUI.index.html",
        string? swaggerTheme = null
    ) =>
        app.UseCustomizedSwaggerUI<Foo>(
            tThisAssemblyProject,
            indexDocumentAssemblyResourceName,
            swaggerTheme
        );

    internal sealed class Foo { }

    internal sealed class CssResult : IResult
    {
        private readonly string _css;

        public CssResult(string css) => _css = css;

        public Task ExecuteAsync(HttpContext httpContext)
        {
            httpContext.Response.ContentType = TextMediaTypeNames.Css;
            return httpContext.Response.WriteAsync(_css);
        }
    }
}
