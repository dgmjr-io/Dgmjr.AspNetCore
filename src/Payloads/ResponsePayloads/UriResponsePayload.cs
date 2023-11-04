//
// UriResponsePayload.cs
//
//   Created: 2022-10-31-08:33:05
//   Modified: 2022-10-31-08:47:44
//
//   Author: David G. Moore, Jr, <david@dgmjr.io>
//
//   Copyright © 2022-2023 David G. Moore, Jr,, All Rights Reserved
//      License: MIT (https://opensource.org/licenses/MIT)
//

namespace Dgmjr.Payloads;

using System;
using System.Xml.Serialization;

/// <summary>Represents a response payload with a <see langword="uri" /> value</summary>.
public class UriResponsePayload(uri value, string? message = default!)
    : ResponsePayload<uri?>(value, message)
{
    /// <inheritdoc />
    [JProp("stringValue")]
    [JIgnore(Condition = JIgnore.WhenWritingNull)]
    [XAttribute("stringValue")]
    public override string? StringValue
    {
        get => base.StringValue ?? Value.ToString();
        set
        {
            if (uri.TryParse(value, out var u))
            {
                base.StringValue = u.ToString();
                Value = u;
            }
            else
            {
                throw new InvalidCastException(
                    $"Cannot cast {value} to {nameof(UriResponsePayload)}"
                );
            }
        }
    }
}
