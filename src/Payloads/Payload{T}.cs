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
    public Payload() : this(default, default) { }

    public Payload(T value, string? stringValue = default)
    {
        Value = value;
        StringValue = stringValue;
    }

    [JProp("value")]
    public virtual T? Value { get; set; }

    [JProp("stringValue")]
    public virtual string? StringValue
    {
        get => _stringValue ?? ToString();
        set => _stringValue = value;
    }
    object? IPayload.Value
    {
        get => Value;
        set => Value = value is T t ? t : default;
    }
    private string? _stringValue;

    public override string ToString() => _stringValue ?? Value?.ToString()!;
    // public static Payload<T> Parse(string s, IFormatProvider? provider)
    //     => TryParse(s, provider, out var result) ? result : throw new FormatException($"The string '{s}' is not a valid {nameof(Payload<T>)}");

    // public static bool TryParse([NotNullWhen(true)] string? s, IFormatProvider? provider, [MaybeNullWhen(false)] out Payload<T> result)
    //     => (result = T.TryParse(s, provider, out var value) ? new Payload<T>(value, s) : null) != null;
}
