/*
 * ErrorResponsePayload.cs
 *
 *   Created: 2022-11-26-04:57:24
 *   Modified: 2022-11-26-04:57:24
 *
 *   Author: David G. Moore, Jr, <david@dgmjr.io>
 *
 *   Copyright © 2022-2023 David G. Moore, Jr,, All Rights Reserved
 *      License: MIT (https://opensource.org/licenses/MIT)
 */

namespace Dgmjr.Payloads;

// public class ErrorResponsePayload : ProblemDetails, IErrorResponsePayload
// {
//     public const string DefaultMessage = "An error has occurred.";

//     public ErrorResponsePayload(Exception? ex = default)
//         : this(ex.Message, ex)
//     { }

//     public ErrorResponsePayload()
//         : this(DefaultMessage)
//     {     }

//     public ErrorResponsePayload(string? message = DefaultMessage)
//         : this(message, default)
//     {     }

//     public ErrorResponsePayload(string? message = DefaultMessage, Exception? inner = default)
//         : this(message, inner, InternalServerError)
//     {     }

//     public ErrorResponsePayload(string? message = DefaultMessage, Exception? inner = default, HttpStatusCode statusCode = InternalServerError)
//         : base(message, inner)
//     {
//         StatusCode = (int)statusCode;
//         StringValue = message;
//     }
//     public virtual bool IsSuccess { get => false; set { } }
//     public virtual string? StringValue { get; set; }
//     public virtual int? StatusCode { get; set; }
//     public virtual object? Value { get; set; }

//     public ICollection<IOutputFormatter> OutputFormatters { get; } = new List<IOutputFormatter>();

//     public MediaTypeCollection ContentTypes { get; } = new MediaTypeCollection();

//     HttpStatusCode? IResponsePayload.StatusCode => StatusCode.HasValue ? (HttpStatusCode)StatusCode.Value : default;

//     public virtual Task ExecuteResultAsync(ActionContext context)
//     {
//         var result = new ObjectResult(this)
//         {
//             DeclaredType = typeof(ErrorResponsePayload)
//         };

//         var executor = context.HttpContext.RequestServices.GetRequiredService<IActionResultExecutor<ObjectResult>>();
//         return executor.ExecuteAsync(context, result);
//     }

//     public void OnFormatting(OutputFormatterWriteContext context)
//     {
//         context.HttpContext.Response.StatusCode = StatusCode ?? (int)InternalServerError;
//     }
// }
