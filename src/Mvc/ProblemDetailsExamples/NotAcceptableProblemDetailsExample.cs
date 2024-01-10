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

public readonly record struct NotAcceptableProblemDetails : IProblemDetails
{
    /// <summary>A short, human-readable summary of the problem.</summary>
    /// <example>Not Fucking Acceptable</example>
    /// <value>Not Fucking Acceptable</value>
    public string Title => "Not Fucking Acceptable";

    /// <summary>The HTTP status code of the response (<inheritdoc cref="Status" path="/example"/>).</summary>
    /// <example><inheritdoc cref="Dgmjr.Http.StatusCode.NotAcceptable.Id" path="/value" /></example>
    /// <value><inheritdoc cref="Dgmjr.Http.StatusCode.NotAcceptable.Id" path="/value" /></value>
    public int? Status => Status406NotAcceptable;

    /// <summary>A human-readable explanation specific to this occurrence of the problem.</summary>
    /// <example>You stupid shit!  I can't produce a response in the format you asked for.  Now, go back and read the documentation and come back when you want something that I CAN do for you!</example>
    /// <value>You stupid shit!  I can't produce a response in the format you asked for.  Now, go back and read the documentation and come back when you want something that I CAN do for you!</value>
    public string Detail =>
        "You stupid shit!  I can't produce a response in the format you asked for.  Now, go back and read the documentation and come back when you want something that I CAN do for you!";

    /// <summary>A URI reference to the problem.</summary>
    /// <example><inheritdoc cref="Dgmjr.Http.StatusCode.NotAcceptable.UriString" path="/value" /></example>
    /// <value><inheritdoc cref="Dgmjr.Http.StatusCode.NotAcceptable.UriString" path="/value" /></value>
    public string Type => Dgmjr.Http.StatusCode.NotAcceptable.UriString;

    /// <summary>A URI reference to the problem.</summary>
    /// <example>/api/endpoint</example>
    public string Instance => "/api/endpoint";

    /// <summary>Additional details about the problem.</summary>
    /// <example>{ "traceId", "0HLQ9V1J3Q0:00000001" }</example>
    public IDictionary<string, object?> Extensions =>
        new Dictionary<string, object?> { { "traceId", "0HLQ9V1J3Q0:00000001" } };
}
