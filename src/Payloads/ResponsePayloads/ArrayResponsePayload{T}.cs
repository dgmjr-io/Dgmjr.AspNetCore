/*
 * ArrayResponsePayload{T}.cs
 *
 *   Created: 2022-11-20-07:14:18
 *   Modified: 2022-11-28-09:44:22
 *
 *   Author: David G. Moore, Jr, <david@dgmjr.io>
 *
 *   Copyright © 2022-2023 David G. Moore, Jr,, All Rights Reserved
 *      License: MIT (https://opensource.org/licenses/MIT)
 */

namespace Dgmjr.Payloads;

using System.Xml.Serialization;
using Dgmjr.Payloads.Abstractions;

/// <inheritdoc cref="IArrayResponsePayload{T}"/>
public class ArrayResponsePayload<T> : ResponsePayload<T[]>, IArrayResponsePayload<T>
{
    public ArrayResponsePayload()
        : this(Empty<T>()) { }

    public ArrayResponsePayload(
        T[] values,
        string? stringValue = default,
        string? message = default,
        string itemSeparator = ArrayPayload<T>.DefaultItemSeparator
    )
        : base(values, stringValue, message)
    {
        ItemSeparator = itemSeparator;
        Message = message ?? string.Empty;
    }

    /// <summary>The arrray of values</summary>
    [JProp("values"), XAttribute("values"), JIgnore(Condition = JIgnore.WhenWritingNull)]
    public virtual T[]? Values
    {
        get => Value;
        set => Value = value;
    }

    [JIgnore, XIgnore]
    public override T[]? Value
    {
        get => base.Value;
        set => base.Value = value ?? Empty<T>();
    }

    /// <summary>The number of items in the array</summary>
    [JProp("count"), XAttribute("count")]
    public virtual int Count => Values.Length;

    public override string ToString() => _stringValue ?? Join(ItemSeparator, Values);

    private string? _stringValue;

    /// <summary>The string representation of the array, which defaults to the string values of each of the elements separared by the <see cref="ItemSeparator" /></summary>
    /// <example>Foo, Bar, Baz</example>
    [
        JProp("stringValue"),
        XmlAttribute("stringValue"),
        JIgnore(Condition = JIgnore.WhenWritingNull)
    ]
    public override string? StringValue
    {
        get => _stringValue ?? ToString();
        set => _stringValue = value;
    }

    [JIgnore, XIgnore]
    public virtual string ItemSeparator { get; set; }
}
