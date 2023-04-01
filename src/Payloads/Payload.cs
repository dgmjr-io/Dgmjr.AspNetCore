/*
 * Payload.cs
 *
 *   Created: 2022-11-29-05:12:56
 *   Modified: 2022-11-29-05:13:18
 *
 *   Author: David G. Moore, Jr, <david@dgmjr.io>
 *
 *   Copyright © 2022-2023 David G. Moore, Jr,, All Rights Reserved
 *      License: MIT (https://opensource.org/licenses/MIT)
 */

namespace Dgmjr.Payloads;

using System.Diagnostics;
using Dgmjr.Payloads.Abstractions;

[DebuggerDisplay($"{{{nameof(StringValue)}}}")]
public class Payload : Payload<object>, IPayload, IPayload<object>
{
    public Payload() : this(default, default) { }

    public Payload(object? value, string? stringValue = default) : base(value, stringValue)
    {
        Value = value;
        StringValue = stringValue ?? value?.ToString();
    }
}
