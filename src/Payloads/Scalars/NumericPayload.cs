//
// NumericPayload.cs
//
//   Created: 2022-10-31-08:33:05
//   Modified: 2022-10-31-08:42:45
//
//   Author: David G. Moore, Jr, <david@dgmjr.io>
//
//   Copyright © 2022-2023 David G. Moore, Jr,, All Rights Reserved
//      License: MIT (https://opensource.org/licenses/MIT)
//

namespace Dgmjr.Payloads;

using System.Diagnostics;

[DebuggerDisplay($"{{{nameof(StringValue)}}}")]
public class NumericPayload : Payload<decimal>
{
    public NumericPayload()
        : this(default) { }

    public NumericPayload(decimal value, string? stringValue = default)
        : base(value, stringValue) { }

    [JProp("stringValue")]
    public override string? StringValue
    {
        get => Value.ToString();
        set => Value = decimal.Parse(value);
    }
}
