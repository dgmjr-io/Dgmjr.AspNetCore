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

public readonly record struct NotFoundProblemDetails : IProblemDetails
{
    /// <summary>The URI of the problem type.</summary>
    /// <example><inheritdoc cref="Dgmjr.Http.StatusCode.NotFound.UriString" path="/value" /></example>
    /// <value><inheritdoc cref="Dgmjr.Http.StatusCode.NotFound.UriString" path="/value" /></value>
    public string Type => Dgmjr.Http.StatusCode.NotFound.UriString;

    /// <summary>A short, human-readable summary of the problem.</summary>
    /// <example>Doesn't fucking exist!</example>
    /// <value>Doesn't fucking exist!</value>
    public string Title => "Doesn't fucking exist!";

    /// <summary>Doesn't fucking exist!</summary>
    /// <example><inheritdoc cref="Dgmjr.Http.StatusCode.NotFound.Id" path="/value" /></example>
    /// <value><inheritdoc cref="Dgmjr.Http.StatusCode.NotFound.Id" path="/value" /></value>
    public int? Status => Status404NotFound;

    /// <summary>Details about the problem.</summary>
    /// <example>The shit you were looking for ain't here, you dumb fuck!  You should probably go back to the home page and try again!</example>
    /// <value>The shit you were looking for ain't here, you dumb fuck!  You should probably go back to the home page and try again!</value>
    public string Detail =>
        "The shit you were looking for ain't here, you dumb fuck!  You should probably go back to the home page and try again!";

    /// <summary>A URI reference to the problem.</summary>
    /// <example>/api/endpoint</example>
    /// <value>/api/endpoint</value>
    public string Instance => "/api/endpoint";

    /// <summary>Additional details about the problem.</summary>
    /// <example>{ "traceId", "0HLQ9V1J3Q0:0000001" }</example>
    public IDictionary<string, object?> Extensions =>
        new Dictionary<string, object?> { { "traceId", "0HLQ9V1J3Q0:00000004" } };
}
