//
// BooleanResponsePayload.cs
//
//   Created: 2022-10-31-08:33:05
//   Modified: 2022-10-31-08:33:50
//
//   Author: David G. Moore, Jr, <david@dgmjr.io>
//
//   Copyright © 2022-2023 David G. Moore, Jr,, All Rights Reserved
//      License: MIT (https://opensource.org/licenses/MIT)
//


namespace Dgmjr.Payloads;

using System.Xml.Serialization;

/// <summary>Represents a response payload with a <see langword="bool" /> value</summary>
public class BooleanResponsePayload : ResponsePayload<bool>
{
    public BooleanResponsePayload(bool value, string? message = default!)
        : base(value, message) { }

    /// <inheritdoc />
    [
        JProp("stringValue"),
        JIgnore(Condition = JIgnoreCond.WhenWritingNull),
        XmlAttribute("stringValue")
    ]
    public override string? StringValue
    {
        get => Value.ToString();
        set => Value = bool.Parse(value);
    }
}
