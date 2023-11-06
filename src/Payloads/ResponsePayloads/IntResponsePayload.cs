//
// IntResponsePayload.cs
//
//   Created: 2022-10-31-08:33:05
//   Modified: 2022-10-31-08:47:14
//
//   Author: David G. Moore, Jr, <david@dgmjr.io>
//
//   Copyright © 2022-2023 David G. Moore, Jr,, All Rights Reserved
//      License: MIT (https://opensource.org/licenses/MIT)
//

namespace Dgmjr.Payloads;

/// <summary>Represents a response payload with an <see langword="int" /> value</summary>
public class IntResponsePayload(int value, string? message = default!) : ResponsePayload<int>(value, message ?? string.Empty)
{
    /// <inheritdoc />
    public override string? StringValue
    {
        get => Value.ToString();
        init => Value = int.Parse(value);
    }
}
