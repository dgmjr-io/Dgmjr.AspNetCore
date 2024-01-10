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
    public string Title => "Das ist verboten!";

    /// <example><inheritdoc cref="Dgmjr.Http.StatusCode.Forbidden.Id" path="/value" /></example>
    /// <value><inheritdoc cref="Dgmjr.Http.StatusCode.Forbidden.Id" path="/value" /></value>
    public int? Status => Status403Forbidden;

    /// <summary>A human-readable explanation specific to this occurrence of the problem.</summary>
    /// <example>Du verdammter Scheißer! Du darfst das nicht!</example>
    /// <value>Du verdammter Scheißer! Du darfst das nicht!</value>
    public string Detail => "Du verdammter Scheißer! Du darfst das nicht!";

    /// <summary>A URI reference to the problem.</summary>
    /// <example><inheritdoc cref="Dgmjr.Http.StatusCode.Forbidden.UriString" path="/value" /></example>
    /// <value><inheritdoc cref="Dgmjr.Http.StatusCode.Forbidden.UriString" path="/value" /></value>
    public string Type => Dgmjr.Http.StatusCode.Forbidden.UriString;

    /// <summary>A URI reference to the problem.</summary>
    /// <example>/api/endpoint</example>
    /// <value>/api/endpoint</value>
    public string Instance => "/api/endpoint";

    /// <summary>Additional details about the problem.</summary>
    /// <example>{ "traceId", "0HLQ9V1J3Q0:40000003" }</example>
    public IDictionary<string, object?> Extensions =>
        new Dictionary<string, object?> { { "traceId", "0HLQ9V1J3Q0:40000003" } };
}
