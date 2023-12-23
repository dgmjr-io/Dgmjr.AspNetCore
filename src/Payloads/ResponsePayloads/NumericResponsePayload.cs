//
// NumericResponsePayload.cs
//
//   Created: 2022-10-31-08:33:05
//   Modified: 2022-10-31-08:48:08
//
//   Author: David G. Moore, Jr, <david@dgmjr.io>
//
//   Copyright © 2022-2023 David G. Moore, Jr,, All Rights Reserved
//      License: MIT (https://opensource.org/licenses/MIT)
//

namespace Dgmjr.Payloads;

/// <summary>Represents a response payload with a <see langword="decimal" /> value</summary>
[DebuggerDisplay($"{{{nameof(StringValue)}}}")]
public class NumericResponsePayload(
    decimal value,
    string? message = default!,
    string stringValue = default!
) : ResponsePayload<decimal>(value, message)
{
    /// <inheritdoc />
    public override string? StringValue
{
    get => Value.ToString();
    set => base.StringValue = stringValue ?? value;
}
}
