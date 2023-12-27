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

using System.Collections.Generic;
using static Microsoft.AspNetCore.Http.StatusCodes;

public readonly record struct InternalServerErrorProblemDetails : IProblemDetails
{
    /// <summary>The type of error.</summary>
    /// <example>https://httpstatuses.com/500</example>
    public string Type => "https://httpstatuses.com/500";

    /// <summary>A short, human-readable summary of the problem.</summary>
    /// <example>Fucking Server Error</example>
    public string Title => "Fucking Server Error";

    /// <summary>The HTTP status code about the error.</summary>
    /// <example>500</example>
    public int? Status => Status500InternalServerError;

    /// <summary>Details about the problem.</summary>
    /// <example>Now you've REALLY pissed off the fucking server! It's so fucked it can't even provide you with any real details on what the fuckin' problem is!</example>
    public string Detail =>
        "Now you've REALLY pissed off the fucking server! It's so fucked it can't even provide you with any real details on what the fuckin' problem is!";

    /// <summary>A URI reference to the problem.</summary>
    /// <example>/api/endpoint</example>
    public string Instance => "/api/endpoint";

    /// <summary>Additional details about the problem.</summary>
    /// <example>{ "traceId", "0HLQ9V1J3Q0:0000004" }</example>
    public IDictionary<string, object?> Extensions =>
        new Dictionary<string, object?> { { "traceId", "0HLQ9V1J3Q0:00000004" } };
}
