/*
 * ForbiddenProblemDetailsExample.cs
 *
 *   Created: 2023-01-11-03:05:49
 *   Modified: 2023-01-16-09:33:51
 *
 *   Author: David G. Moore, Jr, <david@dgmjr.io>
 *
 *   Copyright © 2022-2023 David G. Moore, Jr,, All Rights Reserved
 *      License: MIT (https://opensource.org/licenses/MIT)
 */

namespace Dgmjr.AspNetCore.Mvc;

using static Microsoft.AspNetCore.Http.StatusCodes;

public readonly record struct ForbiddenProblemDetails : IProblemDetails
{
    /// <summary>A short, human-readable summary of the problem.</summary>
    /// <example>Das ist verboten!</example>
    public string Title => "You're not allowed to fucking do that!";

    /// <example>403</example>
    public int? Status => Status401Unauthorized;

    /// <summary>A human-readable explanation specific to this occurrence of the problem.</summary>
    /// <example>You dumb fuck! You're not allowed to fucking do that!  Stop touching shit you know you're not supposed to fucking touch!</example>
    public string Detail =>
        "You dumb fuck! You're not allowed to fucking do that!  Stop touching shit you know you're not supposed to fucking touch!";

    /// <summary>A URI reference to the problem.</summary>
    /// <example>https://httpstatuses.com/403</example>
    public string Type => "https://httpstatuses.com/403";

    /// <summary>A URI reference to the problem.</summary>
    /// <example>/api/endpoint</example>
    public string Instance => "/api/endpoint";

    /// <summary>Additional details about the problem.</summary>
    /// <example>{ "traceId", "0HLQ9V1J3Q0:40000003" }</example>
    public IDictionary<string, object?> Extensions =>
        new Dictionary<string, object?> { { "traceId", "0HLQ9V1J3Q0:40000003" } };
}
