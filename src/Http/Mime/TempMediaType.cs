/*
 * MimeMediaType.cs
 *
 *   Created: 2023-01-06-06:35:11
 *   Modified: 2023-01-06-06:35:11
 *
 *   Author: David G. Moore, Jr, <david@dgmjr.io>
 *
 *   Copyright © 2022-2023 David G. Moore, Jr,, All Rights Reserved
 *      License: MIT (https://opensource.org/licenses/MIT)
 */

namespace Dgmjr.Mime;

using System;

using Abstractions;

using Dgmjr.Mime.Enums;

public readonly record struct TempMediaType(string Name)
    : IMediaType
{
    public string DisplayName { get; } = Name;
    private static readonly MD5 MD5 = MD5.Create();
    public string[] Synonyms { get; init; } = Empty<string>();
    Uri IHaveAUri.Uri => new(UriString);
    object IIdentifiable.Id => Id;
    public int Id => 0;
    public int Value => Id;
    public string UriString => "urn:publicid:temp:media-type:" + DisplayName.ToKebabCase();
    public string GuidString => MD5.ComputeHash(UriString.ToUTF8Bytes()).ToHexString();
    public guid Guid => new(GuidString);
    public string Description => Name;
    public string GroupName => Name;
    public string ShortName => Name;
    public string Name => DisplayName;
    public int Order => 0;
    public string Prompt => "";

    uri IMediaType.Uri => UriString;
    uri IHaveAuri.Uri => UriString;

    object IHaveAValue.Value => Value;

    int IHaveAValue<int>.Value => Id;

    MediaTypes IHaveAValue<MediaTypes>.Value => MediaTypes.Any;

    TypeCode IConvertible.GetTypeCode() => TypeCode.Object;

    bool IConvertible.ToBoolean(IFormatProvider? provider) => true;

    byte IConvertible.ToByte(IFormatProvider? provider) => Convert.ToByte(Value);

    char IConvertible.ToChar(IFormatProvider? provider) => Convert.ToChar(Value);

    datetime IConvertible.ToDateTime(IFormatProvider? provider) => Convert.ToDateTime(Value);

    decimal IConvertible.ToDecimal(IFormatProvider? provider) => Convert.ToDecimal(Value);

    double IConvertible.ToDouble(IFormatProvider? provider) => Convert.ToDouble(Value);

    short IConvertible.ToInt16(IFormatProvider? provider) => Convert.ToInt16(Value);

    int IConvertible.ToInt32(IFormatProvider? provider) => Convert.ToInt32(Value);

    long IConvertible.ToInt64(IFormatProvider? provider) => Convert.ToInt64(Value);

    sbyte IConvertible.ToSByte(IFormatProvider? provider) => Convert.ToSByte(Value);

    float IConvertible.ToSingle(IFormatProvider? provider) => Convert.ToSingle(Value);

    string IConvertible.ToString(IFormatProvider? provider) => Convert.ToString(Value);

    object IConvertible.ToType(type conversionType, IFormatProvider? provider) =>
        Convert.ChangeType(Value, conversionType);

    ushort IConvertible.ToUInt16(IFormatProvider? provider) => Convert.ToUInt16(Value);

    uint IConvertible.ToUInt32(IFormatProvider? provider) => Convert.ToUInt32(Value);

    ulong IConvertible.ToUInt64(IFormatProvider? provider) => Convert.ToUInt64(Value);

    bool IEquatable<int>.Equals(int other) => Id == other;

    bool IEquatable<IMediaType>.Equals(IMediaType other) => this.Matches(other);
}
