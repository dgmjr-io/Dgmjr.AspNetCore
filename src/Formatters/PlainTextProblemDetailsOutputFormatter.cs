/*
 * PlainTextProblemDetailsOutputFormatter.cs
 *
 *   Created: 2022-12-13-04:05:17
 *   Modified: 2022-12-13-04:05:18
 *
 *   Author: David G. Moore, Jr, <david@dgmjr.io>
 *
 *   Copyright © 2022-2023 David G. Moore, Jr,, All Rights Reserved
 *      License: MIT (https://opensource.org/licenses/MIT)
 */

namespace Dgmjr.AspNetCore.Formatters;

using Dgmjr.Mime;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using static Dgmjr.Http.Headers.HttpResponseHeaderNames;

public class PlainTextProblemDetailsOutputFormatter : OutputFormatter
{
    public PlainTextProblemDetailsOutputFormatter() =>
        SupportedMediaTypes.Add(TextMediaTypeNames.Plain);

    public override bool CanWriteResult(OutputFormatterCanWriteContext context) =>
        context?.Object is ProblemDetails;

    public override async Task WriteResponseBodyAsync(OutputFormatterWriteContext context)
    {
        var response = context?.HttpContext.Response;
        response.ContentType = TextMediaTypeNames.PlainWithProblem;
        var problemDetails = (ProblemDetails)context.Object!;
        response.StatusCode = problemDetails.Status ?? StatusCodes.Status500InternalServerError;
        response.Headers.Add(XFailed.DisplayName, problemDetails.Title ?? "Unknown Error");
        response.Headers.Add(XProblemDetail.DisplayName, problemDetails.Detail ?? "Unknown Error");
        response.Headers.Add(
            XProblemInstance.DisplayName,
            problemDetails.Instance ?? "Unknown Error"
        );
        response.Headers.Add(XProblemType.DisplayName, problemDetails.Type ?? "Unknown Error");
        await response.WriteAsync(problemDetails.Detail);
    }
}
