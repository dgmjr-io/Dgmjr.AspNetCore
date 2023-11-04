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
using System.Globalization;

using PhoneNumbers;

[DebuggerDisplay($"{{{nameof(StringValue)}}}")]
public class NumericPayload(decimal value, string? stringValue = default)
    : Payload<decimal>(value, stringValue ?? value.ToString(CultureInfo.CurrentCulture))
{
    public NumericPayload()
        : this(default) { }

    [JProp("stringValue")]
    public override string? StringValue
    {
        get => Value.ToString(CultureInfo.CurrentCulture);
        set => Value = decimal.Parse(value, CultureInfo.CurrentCulture);
    }
}
