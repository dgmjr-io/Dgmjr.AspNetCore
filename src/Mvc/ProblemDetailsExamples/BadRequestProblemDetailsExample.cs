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

public class BadRequestProblemDetails : IProblemDetails
{
    /// <summary>A short, human-readable summary of the problem.</summary>
    /// <example>Bad Request</example>
    public string Title { get; set; } = "Bad Request";

    /// <summary>The HTTP status code of the response (<inheritdoc cref="Status" path="/example"/>).</summary>
    /// <example>400</example>
    public int? Status { get; set; } = Status400BadRequest;

    /// <summary>A human-readable explanation specific to this occurrence of the problem.</summary>
    /// <example>You dumb fuck! You submitted bad data to the server and now it's fucking PISSED and refusing to respond to your request!!!</example>
    public string Detail { get; set; } =
        "You dumb fuck! You submitted bad data to the server and now it's fucking PISSED and refusing to service your request!!!";

    /// <summary>A URI reference to the problem.</summary>
    /// <example>https://httpstatuses.com/400</example>
    public string Type { get; set; } = "https://httpstatuses.com/400";

    /// <summary>A URI reference to the problem.</summary>
    /// <example>/api/endpoint</example>
    public string Instance { get; set; } = "/api/endpoint";

    /// <summary>Additional details about the problem.</summary>
    /// <example>{ "traceId", "0HLQ9V1J3Q0:00000001" }</example>
    public IDictionary<string, object?> Extensions { get; set; } =
        new Dictionary<string, object?> { { "traceId", "0HLQ9V1J3Q0:00000001" } };
}
