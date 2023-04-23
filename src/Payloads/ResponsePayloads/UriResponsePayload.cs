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
public class UriResponsePayload : ResponsePayload<uri?>
{
    public UriResponsePayload(uri value, string? message = default!) : base(value, message) { }

    /// <inheritdoc />
    [
        JProp("stringValue"),
        JIgnore(Condition = JIgnoreCond.WhenWritingNull),
        XmlAttribute("stringValue")
    ]
    public override string? StringValue
    {
        get => _stringValue ?? Value.ToString();
        set
        {
            if (uri.TryParse(value, out var u))
            {
                _stringValue = u.ToString();
                Value = u;
            }
            else
            {
                throw new InvalidCastException($"Cannot cast {value} to {nameof(UriResponsePayload)}");
            }
        }
    }
}
