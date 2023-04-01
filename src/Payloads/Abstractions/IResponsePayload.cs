/*
 * IResponsePayload.cs
 *
 *   Created: 2022-11-26-04:26:06
 *   Modified: 2022-11-26-04:26:06
 *
 *   Author: David G. Moore, Jr, <david@dgmjr.io>
 *
 *   Copyright © 2022-2023 David G. Moore, Jr,, All Rights Reserved
 *      License: MIT (https://opensource.org/licenses/MIT)
 */

using System.Net;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace Dgmjr.Payloads.Abstractions;

/// <summary>Represents a response payload</summary>
/// <remarks>The type of the payload is <see langword="object"/>.</remarks>
public interface IResponsePayload : IPayload, IStatusCodeActionResult
{
    /// <summary>If the request was successful</summary>
    /// <remarks>Defaults to true</remarks>
    /// <example>true</example>
    /// <example>false</example>
    /// <value><see langword="true"/> if the request was successful; otherwise, <see langword="false"/>.</value>
    [JProp("success")]
    bool IsSuccess { get; }

    /// <summary>An optional message with information about the response</summary>
    /// <remarks>Defaults to <see langword="null"/></remarks>
    /// <example>There are five records in the resultset, of which two are returned</example>
    /// <example>There are no records in the resultset</example>
    [JProp("message")]
    string Message { get; }

    [JIgnore]
    ICollection<IOutputFormatter> OutputFormatters { get; }

    [JIgnore]
    MediaTypeCollection ContentTypes { get; }
    void OnFormatting(OutputFormatterWriteContext context);
    new HttpStatusCode? StatusCode { get; }
}
