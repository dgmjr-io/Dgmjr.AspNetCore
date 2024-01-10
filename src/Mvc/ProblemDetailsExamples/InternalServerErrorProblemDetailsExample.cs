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
    /// <example><inheritdoc cref="Dgmjr.Http.StatusCode.InternalServerError.UriString" path="/value" /></example>
    /// <value><inheritdoc cref="Dgmjr.Http.StatusCode.InternalServerError.UriString" path="/value" /></value>
    public string Type => Dgmjr.Http.StatusCode.InternalServerError.UriString;

    /// <summary>A short, human-readable summary of the problem.</summary>
    /// <example>Fucking Server Error</example>
    /// <value>Fucking Server Error</value>
    public string Title => "Fucking Server Error";

    /// <summary>The HTTP status code about the error.</summary>
    /// <example><inheritdoc cref="Dgmjr.Http.StatusCode.InternalServerError.Id" path="/value" /></example>
    /// <value><inheritdoc cref="Dgmjr.Http.StatusCode.InternalServerError.Id" path="/value" /></value>
    public int? Status => Status500InternalServerError;

    /// <summary>Details about the problem.</summary>
    /// <example>Now you've REALLY pissed off the fucking server! It's so fucked it can't even provide you with any real details on what the fuckin' problem is!</example>
    /// <value>Now you've REALLY pissed off the fucking server! It's so fucked it can't even provide you with any real details on what the fuckin' problem is!</value>
    public string Detail =>
        "Now you've REALLY pissed off the fucking server! It's so fucked it can't even provide you with any real details on what the fuckin' problem is!";

    /// <summary>A URI reference to the problem.</summary>
    /// <example>/api/endpoint</example>
    /// <value>/api/endpoint</value>
    public string Instance => "/api/endpoint";

    /// <summary>Additional details about the problem.</summary>
    /// <example>{ "traceId", "0HLQ9V1J3Q0:0000004" }</example>
    public IDictionary<string, object?> Extensions =>
        new Dictionary<string, object?> { { "traceId", "0HLQ9V1J3Q0:00000004" } };
}
