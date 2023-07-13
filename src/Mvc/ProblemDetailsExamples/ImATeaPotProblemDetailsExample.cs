/*
 * BadRequestProblemDetailsExample.cs
 *
 *   Created: 2022-12-19-05:26:17
 *   Modified: 2022-12-19-05:26:19
 *
 *   Author: David G. Moore, Jr, <david@dgmjr.io>
 *
 *   Copyright © 2022-2023 David G. Moore, Jr,, All Rights Reserved
 *      License: MIT (https://opensource.org/licenses/MIT)
 */

namespace Dgmjr.AspNetCore.Mvc;

using System.Collections.Generic;
using static Microsoft.AspNetCore.Http.StatusCodes;

public class ImATeapotProblemDetailsExample : IProblemDetails
{
    /// <summary>A short, human-readable summary of the problem.</summary>
    /// <example>Bad Request</example>
    public string Title { get; set; } = "I'm a teapot";

    /// <summary>The HTTP status code of the response (<inheritdoc cref="Status" path="/example"/>).</summary>
    /// <example>418</example>
    public int? Status { get; set; } = Status400BadRequest;

    /// <summary>A human-readable explanation specific to this occurrence of the problem.</summary>
    /// <example>I'm a fucking teapot, short and stout.  Here's my handle; here's my spout.  If you've reached this error code, you must shout, "I'm a fuckin' idiot so kick me out!"</example>
    public string Detail { get; set; } =
        "I'm a fucking teapot, short and stout.  Here's my handle; here's my spout.  If you've reached this error code, you must shout, \"I'm a fuckin' idiot so kick me out!\"";

    /// <summary>A URI reference to the problem.</summary>
    /// <example>https://httpstatuses.com/418</example>
    public string Type { get; set; } = "https://httpstatuses.com/418";

    /// <summary>A URI reference to the problem.</summary>
    /// <example>/api/endpoint</example>
    public string Instance { get; set; } = "/api/endpoint";

    /// <summary>Additional details about the problem.</summary>
    /// <example>{ "traceId", "0HLQ9V1J3Q0:IMATEAPOT" }</example>
    public IDictionary<string, object?> Extensions { get; set; } =
        new Dictionary<string, object?> { { "traceId", "0HLQ9V1J3Q0:IMATEAPOT" } };
}
