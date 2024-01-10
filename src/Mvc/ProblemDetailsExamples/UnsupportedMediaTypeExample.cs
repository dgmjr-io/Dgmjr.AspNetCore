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

public readonly record struct UnsupportedMediaTypeProblemDetails : IProblemDetails
{
    /// <summary>A short, human-readable summary of the problem.</summary>
    /// <example>I don't fucking understand what the fuck you said!</example>
    /// <value>I don't fucking understand what the fuck you said!</value>
    public string Title => "I don't fucking understand what the fuck you said!";

    /// <example><inheritdoc cref="Dgmjr.Http.StatusCode.UnsupportedMediaType.Id" path="/value" /></example>
    /// <value><inheritdoc cref="Dgmjr.Http.StatusCode.UnsupportedMediaType.Id" path="/value" /></value>
    public int? Status => Status401Unauthorized;

    /// <summary>A human-readable explanation specific to this occurrence of the problem.</summary>
    /// <example>Biiiiiiitcchhh, come on! Speak COMPUTER to me! Whatever the fuck it was you just said, I didn't fucking understand it!</example>
    /// <value>Biiiiiiitcchhh, come on! Speak COMPUTER to me! Whatever the fuck it was you just said, I didn't fucking understand it!</value>
    public string Detail =>
        "Biiiiiiitcchhh, come on! Speak COMPUTER to me! Whatever the fuck it was you just said, I didn't fucking understand it!";

    /// <summary>A URI reference to the problem.</summary>
    /// <example><inheritdoc cref="Dgmjr.Http.StatusCode.UnsupportedMediaType.UriString" path="/value" /></example>
    /// <value><inheritdoc cref="Dgmjr.Http.StatusCode.UnsupportedMediaType.UriString" path="/value" /></value>
    public string Type => Dgmjr.Http.StatusCode.UnsupportedMediaType.UriString;

    /// <summary>A URI reference to the problem.</summary>
    /// <example>/api/endpoint</example>
    /// <value>/api/endpoint</value>
    public string Instance => "/api/endpoint";

    /// <summary>Additional details about the problem.</summary>
    /// <example>{ "traceId", "0HLQ9V1J3Q0:40000001" }</example>
    public IDictionary<string, object?> Extensions =>
        new Dictionary<string, object?> { { "traceId", "0HLQ9V1J3Q0:00000001" } };
}
