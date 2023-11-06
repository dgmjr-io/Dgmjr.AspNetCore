using System.Xml.Linq;

//
// Payload.cs
//
//   Created: 2022-10-31-08:33:05
//   Modified: 2022-10-31-08:35:51
//
//   Author: David G. Moore, Jr, <david@dgmjr.io>
//
//   Copyright © 2022-2023 David G. Moore, Jr,, All Rights Reserved
//      License: MIT (https://opensource.org/licenses/MIT)
//

namespace Dgmjr.Payloads;

using System.Diagnostics;
using Dgmjr.Payloads.Abstractions;

[DebuggerDisplay($"{{{nameof(StringValue)}}}")]
public class Payload<T> : IPayload<T> //, IParsable<Payload<T>>
{
    public Payload()
        : this(default, default) { }

    public Payload(T value, string? stringValue = default)
    {
        Value = value;
        StringValue = stringValue;
    }

    /// <summary>
    /// The strongly-typed value.
    /// </summary>
    [JProp("value"), XAttribute("value")]
    public virtual T? Value { get; init; }

    /// <summary>
    /// The string representation of the value.
    /// </summary>
    [JProp("stringValue"), XAttribute("stringValue")]
    public virtual string? StringValue
    {
        get => _stringValue ?? ToString();
        init => _stringValue = value;
    }
    object? IPayload.Value
    {
        get => Value;
        init => Value = value is T t ? t : default;
    }
    protected string? _stringValue;

    public override string ToString() => _stringValue ?? Value?.ToString()!;
}
