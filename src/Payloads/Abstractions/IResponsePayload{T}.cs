/*
 * IResponsePayload copy.cs
 *
 *   Created: 2022-11-26-04:29:28
 *   Modified: 2022-11-26-04:29:28
 *
 *   Author: David G. Moore, Jr, <david@dgmjr.io>
 *
 *   Copyright © 2022-2023 David G. Moore, Jr,, All Rights Reserved
 *      License: MIT (https://opensource.org/licenses/MIT)
 */

namespace Dgmjr.Payloads.Abstractions;

using System.Net;

/// <summary>Represents a strongly-typed response payload of type <typeparamref name="T" />.</summary>
public interface IResponsePayload<T> : IPayload<T>, IResponsePayload
{
    public static virtual IResponsePayload<T> NotFound() =>
        new ResponsePayload<T> { StatusCode = (int)HttpStatusCode.NotFound };
    public static virtual IResponsePayload<T> BadRequest() =>
        new ResponsePayload<T> { StatusCode = (int)HttpStatusCode.BadRequest };
    public static virtual IResponsePayload<T> NoContent() =>
        new ResponsePayload<T> { StatusCode = (int)HttpStatusCode.NoContent };
}
