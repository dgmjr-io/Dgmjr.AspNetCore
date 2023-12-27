// /*
//  * UseSwaggerUI.cs
//  *
//  *   Created: 2022-12-14-04:11:17
//  *   Modified: 2022-12-14-04:11:17
//  *
//  *   Author: David G. Moore, Jr, <david@dgmjr.io>
//  *
//  *   Copyright © 2022-2023 David G. Moore, Jr,, All Rights Reserved
//  *      License: MIT (https://opensource.org/licenses/MIT)
//  */

// using Microsoft.AspNetCore.Builder;
// using Microsoft.AspNetCore.Http;
// using static Microsoft.AspNetCore.Http.StatusCodes;
// using Microsoft.AspNetCore.Rewrite;
// using Microsoft.Extensions.Logging;
// using Microsoft.OpenApi.Any;
// using Microsoft.OpenApi.Models;

// using TextMediaTypeNames = Dgmjr.Mime.TextMediaTypeNames;
// using MultipartMediaTypeNames = Dgmjr.Mime.MultipartMediaTypeNames;
// using Dgmjr.Mime;

// using Swashbuckle.AspNetCore.SwaggerUI;

// namespace Microsoft.Extensions.DependencyInjection;

// internal static partial class UseSwaggerUIExtensions2
// {
//     private static readonly Assembly Assembly = typeof(UseSwaggerUIExtensions).Assembly;

//     private static string CustomCss(string resourceName) =>
//         Assembly.ReadAssemblyResourceAllText(resourceName);

//     // $$"""
//     // /* Begin Swagger UI Base CSS */
//     // {{GetManifestResourceString("swagger-ui.css")}}
//     // /* End Swagger UI Base CSS */
//     // /* Begin Swagger UI Custom CSS */
//     // {{GetManifestResourceString(resourceName)}}
//     // /* End Swagger UI Custom CSS */
//     // """;

// #if NET8_0_OR_GREATER
//     const string ExampleCss = """"
//     @charset "UTF-8";
//     .swagger-ui html
//     {
//         box-sizing: border-box
//     }

//     .swagger-ui*, .swagger-ui :after, .swagger-ui :before {
//         box-sizing: inherit
//     }

//     etc.etc.etc...
//     """";

//     static readonly OpenApiString _exampleCssOpenApiString = new(ExampleCss);
// #endif

//     public static WebApplication UseCustomizedSwaggerUI<TAssemblyResource>(
//         this WebApplication app,
//         string? indexDocumentAssemblyResourceName = "index.html",
//         string? swaggerTheme = "swagger-ui"
//     ) =>
//         app.UseCustomizedSwaggerUI(
//             typeof(TAssemblyResource),
//             indexDocumentAssemblyResourceName,
//             swaggerTheme
//         );

//     public static WebApplication UseCustomizedSwaggerUI(
//         this WebApplication app,
//         type tThisAssemblyResource,
//         string? indexDocumentAssemblyResourceName = "index.html",
//         string? swaggerTheme = "swagger-ui"
//     )
//     {
//         var thisAssemblyProject = new TThisAssemblyStaticProxy(tThisAssemblyResource);
//         var logger = app.Logger;
//         var swaggerPath = $"/swagger/{thisAssemblyProject.ApiVersion}/swagger.json";
//         app.UseSwagger(options => options.RouteTemplate = swaggerPath);
//         app.UseSwaggerUI(options =>
//         {
//             options.RoutePrefix = string.Empty;
//             options.DefaultModelExpandDepth(0);
//             options.DefaultModelRendering(ModelRendering.Model);
//             options.DocExpansion(DocExpansion.List);
//             options.DisplayOperationId();
//             options.DisplayRequestDuration();
//             options.EnableDeepLinking();
//             options.EnableFilter();
//             options.EnableTryItOutByDefault();
//             options.EnablePersistAuthorization();
//             options.ShowExtensions();
//             options.ShowCommonExtensions();
//             options.EnableValidator();
//             options.SupportedSubmitMethods(
//                 SubmitMethod.Get,
//                 SubmitMethod.Post,
//                 SubmitMethod.Put,
//                 SubmitMethod.Delete,
//                 SubmitMethod.Patch,
//                 SubmitMethod.Head,
//                 SubmitMethod.Options,
//                 SubmitMethod.Trace
//             );
//             options.InjectStylesheet("/swagger-ui/SwaggerUI.custom.css");
//             try
//             {
//                 var indexHtmlText = Assembly.ReadAssemblyResourceAllText(
//                     indexDocumentAssemblyResourceName
//                 );
//                 options.IndexStream = () => new MemoryStream(indexHtmlText.ToUTF8Bytes());
//             }
//             catch
//             {
//                 app.Logger.CannotLoadIndexDocument(indexDocumentAssemblyResourceName);
//             }

//             options.SwaggerEndpoint(
//                 swaggerPath,
//                 $"{thisAssemblyProject.Title} {thisAssemblyProject.ApiVersion}"
//             );
//         });

//         app.MapGet(
//                 "swagger-ui/SwaggerUI.custom.css",
//                 () => new CssResult(CustomCss(swaggerTheme + ".css"))
//             )
// #if NET8_0_OR_GREATER
//             .WithOpenApi(op =>
//             {
//                 op.Responses["200"] = new OpenApiResponse
//                 {
//                     Description = "Swagger UI CSS",
//                     Content =
//                     {
//                         [Text.Css.DisplayName] = new OpenApiMediaType
//                         {
//                             Schema = new OpenApiSchema
//                             {
//                                 Type = Text.Css.DisplayName,
//                                 Description = "swagger ui css"
//                             },
//                             Example = _exampleCssOpenApiString
//                         }
//                     }
//                 };
//                 return op;
//             })
// #endif
//             .WithName("SwaggerUI.custom.css")
//             .WithGroupName("Style")
// #if NET8_0_OR_GREATER
//             .WithSummary("Custom CSS for Swagger UI")
// #endif
//             .WithTags("Style", "UI")
//             .Produces<string>(Status200OK, Text.Css.DisplayName);

//         foreach (var cssFile in Assembly.GetManifestResourceNames().Where(x => x.EndsWith(".css")))
//         {
//             app.MapGet($"/swagger-ui/{cssFile}", () => new CssResult(CustomCss(cssFile)))
// #if NET8_0_OR_GREATER
//                 .WithOpenApi(op =>
//                 {
//                     op.Responses["200"] = new OpenApiResponse
//                     {
//                         Description = "Custom CSS - " + cssFile,
//                         Content =
//                         {
//                             [Text.Css.DisplayName] = new OpenApiMediaType
//                             {
//                                 Schema = new OpenApiSchema
//                                 {
//                                     Format = Text.Css.DisplayName,
//                                     Type = Text.Css.DisplayName,
//                                     Description = "custom css"
//                                 },
//                                 Example = _exampleCssOpenApiString
//                             }
//                         }
//                     };
//                     return op;
//                 })
// #endif
//                 .WithTags("style", "ui")
//                 .Produces<string>(Status200OK, Text.Css.DisplayName);
//         }

//         logger.LogThisAssemblyProjectVersion(thisAssemblyProject.ApiVersion);

//         app.MapGet(swaggerPath, async ctx => ctx.Response.Redirect("/swagger/v1/swagger.json"));

//         app.MapGet(
//             $"/redoc/{thisAssemblyProject.ApiVersion}/redoc.json",
//             async ctx => ctx.Response.Redirect(swaggerPath)
//         );

//         app.UseRewriter(new RewriteOptions().AddRedirect("^$", "swagger-ui/SwaggerUI.custom.css"))
//             .UseRewriter(new RewriteOptions().AddRedirect("swagger-ui.css", "swagger-ui"));

//         app.UseReDoc(opts =>
//         {
//             opts.RoutePrefix = "api-docs";
//             opts.DocumentTitle = thisAssemblyProject.Title;
//             opts.SpecUrl = $"/swagger/{thisAssemblyProject.ApiVersion}/swagger.json";
//             opts.OnlyRequiredInSamples();
//             opts.HeadContent += $$$""""
//             <script type="application/javascript" src="https://cdn.jsdelivr.net/npm/redoc-try-it-out/dist/try-it-out.min.js"></script>
//             {{{opts.HeadContent}}}
//             <script>
//                 var redoc_container = document.createElement("div");
//                 document.body.appendChild(redoc_container);
//                 RedocTryItOut.init(
//                         "{{{opts.SpecUrl}}}",
//                         { title: ""{{{thisAssemblyProject.Title}}}"" },
//                         redoc_container
//             </script>
//             """";
//         });

//         return app;
//     }

//     [LoggerMessage(
//         EventId = 0,
//         Level = LogLevel.Warning,
//         Message = "Cannot load index document from assembly resource '{indexDocumentAssemblyResourceName}'."
//     )]
//     internal static partial void CannotLoadIndexDocument(
//         this ILogger logger,
//         string indexDocumentAssemblyResourceName
//     );

//     [LoggerMessage(
//         EventId = 0,
//         Level = LogLevel.Information,
//         Message = "thisAssemblyProject.ApiVersion '{thisAssemblyProjectVersion}'."
//     )]
//     internal static partial void LogThisAssemblyProjectVersion(
//         this ILogger logger,
//         string thisAssemblyProjectVersion
//     );

//     internal sealed class Foo { }

//     internal readonly struct CssResult : IResult
//     {
//         private readonly string _css;

//         public CssResult(string css) => _css = css;

//         public Task ExecuteAsync(HttpContext httpContext)
//         {
//             httpContext.Response.ContentType = Text.Css.DisplayName;
//             return httpContext.Response.WriteAsync(_css);
//         }
//     }
// }
