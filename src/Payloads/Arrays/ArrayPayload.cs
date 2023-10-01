/*
 * ArrayPayload.cs
 *
 *   Created: 2022-11-20-07:14:18
 *   Modified: 2022-11-26-04:44:57
 *
 *   Author: David G. Moore, Jr, <david@dgmjr.io>
 *
 *   Copyright © 2022-2023 David G. Moore, Jr,, All Rights Reserved
 *      License: MIT (https://opensource.org/licenses/MIT)
 */

using System.Collections;

namespace Dgmjr.Payloads;

[DebuggerDisplay($"{{{nameof(StringValue)}}}")]
public class ArrayPayload : ArrayPayload<object>
{
    public ArrayPayload()
        : this(Empty<object>()) { }

    public ArrayPayload(
        IEnumerable values,
        string? stringValue = default,
        string itemSeparator = DefaultItemSeparator
    )
        : base(values.OfType<object>().ToArray(), stringValue, itemSeparator) { }
}
