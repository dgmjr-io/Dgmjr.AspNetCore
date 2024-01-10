/*
 * UnauthorizedProblemDetailsExample.cs
 *
 *   Created: 2022-12-19-05:26:13
 *   Modified: 2022-12-19-05:26:38
 *
 *   Author: David G. Moore, Jr, <david@dgmjr.io>
 *
 *   Copyright © 2022-2023 David G. Moore, Jr,, All Rights Reserved
 *      License: MIT (https://opensource.org/licenses/MIT)
 */

namespace Dgmjr.AspNetCore.Mvc;

using static Microsoft.AspNetCore.Http.StatusCodes;

public readonly record struct UnauthorizedProblemDetails : IProblemDetails
{
    /// <summary>A short, human-readable summary of the problem.</summary>
    /// <example>You're not allowed to fucking do that!</example>
    /// <value>You're not allowed to fucking do that!</value>
    public string Title => "You're not allowed to fucking do that!";

    /// <example><inheritdoc cref="Dgmjr.Http.StatusCode.Unauthorized.Id" path="/value" /></example>
    /// <value><inheritdoc cref="Dgmjr.Http.StatusCode.Unauthorized.Id" path="/value" /></value>
    public int? Status => Status401Unauthorized;

    /// <summary>A human-readable explanation specific to this occurrence of the problem.</summary>
    /// <example>You dumb fuck! You're not allowed to fucking do that!  Stop touching shit you know you're not supposed to fucking touch!</example>
    /// <value>You dumb fuck! You're not allowed to fucking do that!  Stop touching shit you know you're not supposed to fucking touch!</value>
    public string Detail =>
        "You dumb fuck! You're not allowed to fucking do that!  Stop touching shit you know you're not supposed to fucking touch!";

    /// <summary>A URI reference to the problem.</summary>
    /// <example><inheritdoc cref="Dgmjr.Http.StatusCode.Unauthorized.UriString" path="/value" /></example>
    /// <value><inheritdoc cref="Dgmjr.Http.StatusCode.Unauthorized.UriString" path="/value" /></value>
    public string Type => Dgmjr.Http.StatusCode.Unauthorized.UriString;

    /// <summary>A URI reference to the problem.</summary>
    /// <example>/api/endpoint</example>
    /// <value>/api/endpoint</value>
    public string Instance => "/api/endpoint";

    /// <summary>Additional details about the problem.</summary>
    /// <example>{ "traceId", "0HLQ9V1J3Q0:40000001" }</example>
    public IDictionary<string, object?> Extensions =>
        new Dictionary<string, object?> { { "traceId", "0HLQ9V1J3Q0:00000001" } };
}
