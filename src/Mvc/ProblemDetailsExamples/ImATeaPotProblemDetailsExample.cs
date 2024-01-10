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

public readonly record struct ImATeapotProblemDetailsExample : IProblemDetails
{
    /// <summary>A short, human-readable summary of the problem.</summary>
    /// <example>Bad Request</example>
    public string Title => "I'm a fucking teapot, you dumb fuck!";

    /// <summary>The HTTP status code of the response (<inheritdoc cref="Status" path="/example"/>).</summary>
    /// <example><inheritdoc cref="Dgmjr.Http.StatusCode.ImATeapot.Id" path="/value" /></example>
    /// <value><inheritdoc cref="Dgmjr.Http.StatusCode.ImATeapot.Id" path="/value" /></value>
    public int? Status => Status418ImATeapot;

    /// <summary>A human-readable explanation specific to this occurrence of the problem.</summary>
    /// <example>I'm a fucking teapot, short and stout.  Here's my handle; here's my spout.  If you've reached this error code, you must shout, "I'm a fuckin' idiot so kick me out!"</example>
    /// <value>I'm a fucking teapot, short and stout.  Here's my handle; here's my spout.  If you've reached this error code, you must shout, "I'm a fuckin' idiot so kick me out!"</value>
    public string Detail =>
        "I'm a fucking teapot, short and stout.  Here's my handle; here's my spout.  If you've reached this error code, you must shout, \"I'm a fuckin' idiot so kick me out!\"";

    /// <summary>A URI reference to the problem.</summary>
    /// <example><inheritdoc cref="Dgmjr.Http.StatusCode.ImATeapot.UriString" path="/value" /></example>
    /// <value><inheritdoc cref="Dgmjr.Http.StatusCode.ImATeapot.UriString" path="/value" /></value>
    public string Type => Dgmjr.Http.StatusCode.ImATeapot.UriString;

    /// <summary>A URI reference to the problem.</summary>
    /// <example>/api/endpoint</example>
    public string Instance => "/api/endpoint";

    /// <summary>Additional details about the problem.</summary>
    /// <example>{ "traceId", "0HLQ9V1J3Q0:IMATEAPOT" }</example>
    public IDictionary<string, object?> Extensions =>
        new Dictionary<string, object?> { { "traceId", "0HLQ9V1J3Q0:IMATEAPOT" } };
}
