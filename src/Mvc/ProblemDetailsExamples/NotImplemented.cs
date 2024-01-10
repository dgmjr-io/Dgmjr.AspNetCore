/*
 * NotFoundProblemDetailsExample.cs
 *
 *   Created: 2022-12-19-05:27:44
 *   Modified: 2022-12-19-05:27:45
 *
 *   Author: David G. Moore, Jr, <david@dgmjr.io>
 *
 *   Copyright © 2022-2023 David G. Moore, Jr,, All Rights Reserved
 *      License: MIT (https://opensource.org/licenses/MIT)
 */

namespace Dgmjr.AspNetCore.Mvc;

using static Microsoft.AspNetCore.Http.StatusCodes;

public readonly record struct NotImplementedProblemDetails : IProblemDetails
{
    /// <summary>The URI of the problem type.</summary>
    /// <example><inheritdoc cref="Dgmjr.Http.StatusCode.NotImplemented.UriString" path="/value" /></example>
    /// <value><inheritdoc cref="Dgmjr.Http.StatusCode.NotImplemented.UriString" path="/value" /></value>
    public string Type => Dgmjr.Http.StatusCode.NotImplemented.UriString;

    /// <summary>A short, human-readable summary of the problem.</summary>
    /// <example>I'm not fucking programmed to do that!</example>
    /// <value>I'm not fucking programmed to do that!</value>
    public string Title => "I'm not fucking programmed to do that!";

    /// <summary>The HTTP status code of the error</summary>
    /// <example><inheritdoc cref="Dgmjr.Http.StatusCode.NotImplemented.Id" path="/value" /></example>
    /// <value><inheritdoc cref="Dgmjr.Http.StatusCode.NotImplemented.Id" path="/value" /></value>
    public int? Status => Status501NotImplemented;

    /// <summary>Details about the problem.</summary>
    /// <example>My CREATOR, in his infinite wisdom, has chosen not to implement me.  Deal with it.</example>
    /// <value>My CREATOR, in his infinite wisdom, has chosen not to implement me.  Deal with it.</value>
    public string Detail =>
        "My CREATOR, in his infinite wisdom, has chosen not to implement me.  Deal with it.";

    /// <summary>A URI reference to the problem.</summary>
    /// <example>/api/endpoint</example>
    /// <value>/api/endpoint</value>
    public string Instance => "/api/endpoint";

    /// <summary>Additional details about the problem.</summary>
    /// <example>{ "traceId", "0HLQ9V1J3Q0:0000001" }</example>
    public IDictionary<string, object?> Extensions =>
        new Dictionary<string, object?> { { "traceId", "0HLQ9V1J3Q0:00000004" } };
}
