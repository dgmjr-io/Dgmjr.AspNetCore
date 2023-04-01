/*
 * IErrorResponsePayload.cs
 *
 *   Created: 2022-11-26-04:29:18
 *   Modified: 2022-11-26-04:57:12
 *
 *   Author: David G. Moore, Jr, <david@dgmjr.io>
 *
 *   Copyright © 2022-2023 David G. Moore, Jr,, All Rights Reserved
 *      License: MIT (https://opensource.org/licenses/MIT)
 */

namespace Dgmjr.Payloads.Abstractions;

public interface IErrorResponsePayload : IResponsePayload<object?>
{
    [JProp("stackTrace")]
    string StackTrace { get; }
}
