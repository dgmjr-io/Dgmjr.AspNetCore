/*
 * ResponsePayload{T}.cs
 *
 *   Created: 2022-11-29-05:25:22
 *   Modified: 2022-11-29-05:25:35
 *
 *   Author: David G. Moore, Jr, <david@dgmjr.io>
 *
 *   Copyright © 2022-2023 David G. Moore, Jr,, All Rights Reserved
 *      License: MIT (https://opensource.org/licenses/MIT)
 */

namespace Dgmjr.Payloads;

using System.Net;
using Dgmjr.Payloads.Abstractions;

/// <inheritdoc cref="IResponsePayload"/>
public class ResponsePayload : ResponsePayload<object>
{
    public ResponsePayload()
        : this(default, true, default) { }

    public ResponsePayload(object? value, bool isSuccess = true, string? message = default)
    {
        Value = value;
        Message = message ?? string.Empty;
        StringValue = value.ToString();
    }

    public static ResponsePayload NotFound() => new() { StatusCode = (int)HttpStatusCode.NotFound };

    public static ResponsePayload BadRequest() =>
        new() { StatusCode = (int)HttpStatusCode.BadRequest };

    public static ResponsePayload NoContent() =>
        new() { StatusCode = (int)HttpStatusCode.NoContent };
}
