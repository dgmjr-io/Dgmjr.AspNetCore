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

public readonly record struct BadRequestProblemDetails : IProblemDetails
{
    /// <summary>A short, human-readable summary of the problem.</summary>
    /// <example>Bad Request</example>
    /// <value>Bad Request</value>
    public string Title => "You dumb fuck";

    /// <summary>The HTTP status code of the response (<inheritdoc cref="Status" path="/example"/>).</summary>
    /// <example><inheritdoc cref="Dgmjr.Http.StatusCode.BadRequest.Id" path="/value" /></example>
    /// <value><inheritdoc cref="Dgmjr.Http.StatusCode.BadRequest.Id" path="/value" /></value>
    public int? Status => Status400BadRequest;

    /// <summary>A human-readable explanation specific to this occurrence of the problem.</summary>
    /// <example>You dumb fuck! You submitted bad data to the server and now it's fucking PISSED and refusing to respond to your request!!!</example>
    /// <value>You dumb fuck! You submitted bad data to the server and now it's fucking PISSED and refusing to respond to your request!!!</value>
    public string Detail =>
        "You dumb fuck! You submitted bad data to the server and now it's fucking PISSED and refusing to service your request!!!";

    /// <summary>A URI reference to the problem.</summary>
    /// <example><inheritdoc cref="Dgmjr.Http.StatusCode.BadRequest.UriString" path="/value" /></example>
    /// <value><inheritdoc cref="Dgmjr.Http.StatusCode.BadRequest.UriString" path="/value" /></value>
    public string Type => Dgmjr.Http.StatusCode.BadRequest.UriString;

    /// <summary>A URI reference to the problem.</summary>
    /// <example>/api/endpoint</example>
    /// <value>/api/endpoint</value>
    public string Instance => "/api/endpoint";

    /// <summary>Additional details about the problem.</summary>
    /// <example>{ "traceId", "0HLQ9V1J3Q0:00000001" }</example>
    public IDictionary<string, object?> Extensions =>
        new Dictionary<string, object?> { { "traceId", "0HLQ9V1J3Q0:00000001" } };
}
