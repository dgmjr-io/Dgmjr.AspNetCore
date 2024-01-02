/*
 * ArrayResponsePayload.cs
 *
 *   Created: 2022-11-28-09:44:00
 *   Modified: 2022-11-28-09:44:15
 *
 *   Author: David G. Moore, Jr, <david@dgmjr.io>
 *
 *   Copyright © 2022-2023 David G. Moore, Jr,, All Rights Reserved
 *      License: MIT (https://opensource.org/licenses/MIT)
 */

using System.Collections;

namespace Dgmjr.Payloads;

using System.Diagnostics;
using Dgmjr.Payloads.Abstractions;

/// <inheritdoc cref="IArrayResponsePayload"/>
[DebuggerDisplay($"{{{nameof(StringValue)}}}; Count = {{{nameof(Count)}}}")]
public class ArrayResponsePayload(
    IEnumerable value,
    string? message = default,
    string? stringValue = default,
    string itemSeparator = ArrayPayload<object>.DefaultItemSeparator
)
    : ArrayResponsePayload<object>(value.OfType<object>().ToArray(), message, stringValue),
        IArrayResponsePayload
{
    public ArrayResponsePayload()
        : this(Empty<object>()) { }
}
