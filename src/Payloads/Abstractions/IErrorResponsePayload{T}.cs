/*
 * IErrorResponsePayload{T}.cs
 *
 *   Created: 2022-11-26-04:29:47
 *   Modified: 2022-11-26-04:57:03
 *
 *   Author: David G. Moore, Jr, <david@dgmjr.io>
 *
 *   Copyright © 2022-2023 David G. Moore, Jr,, All Rights Reserved
 *      License: MIT (https://opensource.org/licenses/MIT)
 */

namespace Dgmjr.Payloads.Abstractions;

public interface IErrorResponsePayload<T> : IResponsePayload<T>
{
    [JProp("stackTrace")]
    string StackTrace { get; init; }
}
