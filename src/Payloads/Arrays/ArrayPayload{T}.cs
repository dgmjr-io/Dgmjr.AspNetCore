/*
 * ArrayPayload copy.cs
 *
 *   Created: 2022-11-26-04:42:15
 *   Modified: 2022-11-26-04:42:15
 *
 *   Author: David G. Moore, Jr, <david@dgmjr.io>
 *
 *   Copyright © 2022-2023 David G. Moore, Jr,, All Rights Reserved
 *      License: MIT (https://opensource.org/licenses/MIT)
 */

namespace Dgmjr.Payloads;

[DebuggerDisplay($"{{{nameof(StringValue)}}}")]
public class ArrayPayload<T> : Payload<T[]>, IArrayPayload<T>, IPayload<T[]>
{
    public const string DefaultItemSeparator = ", ";

    public ArrayPayload()
        : this(default, default) { }

    public ArrayPayload(
        IEnumerable<T>? value,
        string? stringValue = default,
        string itemSeparator = DefaultItemSeparator
    )
        : base(value?.ToArray() ?? Empty<T>(), stringValue)
    {
        StringValue = stringValue;
        ItemSeparator = itemSeparator ?? DefaultItemSeparator;
    }

    [JProp("values")]
    public virtual T[]? Values
    {
        get => Value;
        set => Value = value;
    }

    [JIgnore]
    public override T[]? Value
    {
        get => base.Value;
        set => base.Value = value ?? Empty<T>();
    }

    [JIgnore]
    object IPayload.Value
    {
        get => Value;
        set => Value = value is T[] t ? t : default;
    }
    public virtual int Count => Values.Length;

    public override string ToString() => _stringValue ?? Join(ItemSeparator, Values);

    private string? _stringValue;

    [JProp("stringValue")]
    public override string? StringValue
    {
        get => _stringValue ?? ToString();
        set => _stringValue = value;
    }

    [JIgnore]
    public virtual string ItemSeparator { get; set; }
}
