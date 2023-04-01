//
// StringResponsePayload.cs
//
//   Created: 2022-10-31-08:33:05
//   Modified: 2022-10-31-08:46:26
//
//   Author: David G. Moore, Jr, <david@dgmjr.io>
//
//   Copyright © 2022-2023 David G. Moore, Jr,, All Rights Reserved
//      License: MIT (https://opensource.org/licenses/MIT)
//

namespace Dgmjr.Payloads;

/// <summary>Represents a response payload with a <see langword="string" /> value</summary>
public class StringResponsePayload : ResponsePayload<string>
{
    public StringResponsePayload(
        string value,
        string? message = default!,
        string stringValue = default!
    ) : base(value, message, stringValue) { }
}
