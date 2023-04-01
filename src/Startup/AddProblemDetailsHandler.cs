// /*
//  * AddProblemDetailsHandler.cs
//  *
//  *   Created: 2022-12-11-04:13:06
//  *   Modified: 2022-12-11-04:13:06
//  *
//  *   Author: David G. Moore, Jr, <david@dgmjr.io>
//  *
//  *   Copyright © 2022-2023 David G. Moore, Jr,, All Rights Reserved
//  *      License: MIT (https://opensource.org/licenses/MIT)
//  */

// using System.Diagnostics;
// using Microsoft.AspNetCore.Builder;
// using Microsoft.AspNetCore.Diagnostics;
// using Microsoft.AspNetCore.Http;
// using Microsoft.Extensions.Logging;

// namespace Microsoft.Extensions.DependencyInjection;

// public static class ProblemDetailsHandler
// {
//     public static WebApplicationBuilder AddProblemDetailsHandler(this WebApplicationBuilder builder)
//     {
//         builder.Services.AddProblemDetails(problemDetails => problemDetails.CustomizeProblemDetails = (context) =>
//         {
//             var exception = context.HttpContext.Features.Get<IExceptionHandlerFeature>()?.Error;
//             context.ProblemDetails.Instance = context.HttpContext.Request.Path;
//             context.ProblemDetails.Title = "An error occurred while processing your request.";
//             context.ProblemDetails.Status = context.HttpContext.Response.StatusCode;
//             context.ProblemDetails.Detail = context.HttpContext.Features.Get<IExceptionHandlerFeature>()?.Error.Message;
//             context.ProblemDetails.Type = $"https://developer.mozilla.org/en-US/docs/Web/HTTP/Status/{context.ProblemDetails.Status}";
//             context.ProblemDetails.Extensions["traceId"] = context.HttpContext.TraceIdentifier;
//             context.ProblemDetails.Extensions["exception"] = new ExceptionDetails(exception);
//             context.HttpContext.RequestServices.GetService<ILogger<ProblemDetailsContext>>().LogError("{problemDetails}", context.ProblemDetails.Detail);
//             context.HttpContext.RequestServices.GetService<ILogger<ProblemDetailsContext>>().LogInformation("typeof(ProblemDetails): {typeofProblemDetails}", context.ProblemDetails.GetType());
//         });
//         return builder;
//     }
// }

// public struct ExceptionDetails
// {
//     public ExceptionDetails(Exception exception) => this.Exception = exception?.Demystify();

//     private Exception? Exception { get; init; }

//     public string? Message => Exception?.Message;
//     public string[]? StackTrace => Exception?.StackTrace?.Split(Environment.NewLine) ?? Array.Empty<string>();
//     public uri? HelpLink => Exception?.HelpLink?.ToUri();
//     public string? Source => Exception?.Source;
//     public ExceptionDetails? InnerException => Exception?.InnerException is not null ? new ExceptionDetails(Exception.InnerException) : null;
// }
