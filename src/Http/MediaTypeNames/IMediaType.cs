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

namespace System.Net.Mime.MediaTypes;

using System.Linq;
using System.Runtime.InteropServices;
using Microsoft.AspNetCore.Mvc.Formatters;

[System.Text.Json.Serialization.JsonConverter(typeof(IMediaTypeJsonConverter))]
public interface IMediaType
{
    int Id { get; }
    string Name { get; }
    string Description { get; }
    string DisplayName { get; }
    string ShortName { get; }
    string GroupName { get; }
    int Order { get; }
    string Uri { get; }
    string Prompt { get; }

    /// <summary>
    /// Returns a that represents this instance. The format of the returned string is the same as that used by ToString ().
    /// </summary>
    /// <returns>A that represents this instance and can be parsed by System. String. Format () or null if this instance is null</returns>
    string ToString();
    // string Extension { get; set; }
    // string[] Extensions { get; set; }
}

public static class IMediaTypeExtensions
{
    /// <summary>
    /// Determines whether the media type is a wildcard. This is determined by looking for a'*'character at the name of the media type.
    /// </summary>
    /// <param name="IMediaType"></param>
    /// <returns>true if the media type is a wildcard ; otherwise false. For example if the media type is text / plain ; charset = utf - 8</returns>
    public static bool IsWildcard(this IMediaType @this) =>
        @this.Name.EndsWith("*") || @this.Name.StartsWith("*");

    public static bool PrimaryIsWilcard(this IMediaType @this) => @this.Name.StartsWith("*");

    public static string GetPrimaryType(this IMediaType @this) => @this.Name.Split('/').First();

    public static string GetSecondaryType(this IMediaType @this) => @this.Name.Split('/').Last();

    public static bool SecondaryIsWildcard(this IMediaType @this) =>
        @this.Name.Split('/').Last().Contains("*");

    /// <summary>
    /// Determines whether the media type matches. This method is case sensitive. The name of the media type is compared with the name of the media type to determine whether it matches.
    /// </summary>
    /// <param name="IMediaType"></param>
    /// <param name="other">The other media type to compare. Must not be null</param>
    /// <returns>true if the media types match false if they don't or if there is a mismatch ( such as a duplicate media type</returns>
    public static bool Matches(this IMediaType @this, IMediaType other) =>
        @this.IsWildcard() && other.Name.StartsWith(@this.GetPrimaryType())
        || other.IsWildcard() && @this.Name.StartsWith(other.GetPrimaryType())
        || @this.PrimaryIsWilcard() && @this.GetSecondaryType().EndsWith(other.GetSecondaryType())
        || @other.PrimaryIsWilcard() && @other.GetSecondaryType().EndsWith(@this.GetSecondaryType())
        || @this.PrimaryIsWilcard() && @this.GetSecondaryType().EndsWith(other.GetSecondaryType())
        || @other.SecondaryIsWildcard()
            && @other.GetSecondaryType().EndsWith(@this.GetSecondaryType())
        || @this.SecondaryIsWildcard()
            && @this.GetSecondaryType().EndsWith(other.GetSecondaryType())
        || @this.Name.Equals(other.Name);

    /// <summary>
    /// Determines whether the specified media type matches the specified. This method is equivalent to the method of the same name in C#
    /// </summary>
    /// <param name="IMediaType"></param>
    /// <param name="other">The name of the media type to compare.</param>
    /// <returns>true matches ; otherwise false. This method returns false if is null or does not match the string representation</returns>
    public static bool Matches(this IMediaType @this, string other) =>
        @this.Matches(
            new ExampleMediaType(
                ExampleMediaType.Any.Value,
                (int)ExampleMediaType.Any.Id,
                other,
                other
            )
        );

    public static IMediaType ToMediaType(this string s) => new TempMediaType { Name = s };
}

public class IMediaTypeJsonConverter : JsonConverter<IMediaType>
{
    /// <summary>
    /// Reads the media type from the <paramref name="reader" />. This is used to determine the type of the object being read.
    /// </summary>
    /// <param name="Utf8JsonReader"></param>
    /// <param name="typeToConvert">The type to convert to.</param>z
    /// <param name="options">The used to deserialize the object. This can be</param>
    public override IMediaType Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var mediaType = reader.GetString();
        /// If media type is null throw an exception
        /// If media type is null throw an exception
        if (mediaType is null)
            throw new JsonException("Media type cannot be null");

        return new TempMediaType { Name = mediaType };
    }

    /// <summary>
    /// Writes the value to the <paramref name="writer" />. This is used to serialize the content type and not to write the content itself
    /// </summary>
    /// <param name="writer">The to write the value to.</param>
    /// <param name="value">The that is to be written. This is used to serialize the content type and not to write the content itself.</param>
    /// <param name="options">The used to serialize the value. This is used to serialize the content type</param>
    public override void Write(
        Utf8JsonWriter writer,
        IMediaType value,
        JsonSerializerOptions options
    )
    {
        writer.WriteStringValue(value.ToString());
    }
}

public class TempMediaType : IMediaType
{
    public int Id => 0;
    public string Uri => "urn:example:media-type";
    public string Description => Name;
    public string GroupName => Name;
    public string ShortName => Name;
    public string DisplayName => Name;
    public string Name { get; set; } = default!;
    public int Order => 0;
    public string Prompt => "";
}

public static class MediTypeExtensions
{
    public static bool IsText(this IMediaType mediaType) =>
        mediaType.Matches("text/*")
        || mediaType.Matches("application/*+xml")
        || mediaType.Matches("application/*+json")
        || mediaType.Matches("application/*+xml");
}
