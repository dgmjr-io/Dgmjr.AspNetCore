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

using Abstractions;

/// <summary>Converts an <see cref="IMediaType" /> to and from JSON</summary>
public class MediaTypeJsonConverter : JsonConverter<IMediaType>
{
    /// <summary>
    /// Reads the media type from the <paramref name="reader" />. This is used to determine the type of the object being read.
    /// </summary>
    /// <param name="reader">The reader</param>
    /// <param name="typeToConvert">The type to convert to.</param>z
    /// <param name="options">The used to deserialize the object. This can be</param>
    public override IMediaType Read(ref Utf8JsonReader reader, type typeToConvert, Jso options)
    {
        var mediaType = reader.GetString() ?? throw new JsonException("Media type cannot be null");
        return new TempMediaType(mediaType);
    }

    /// <summary>
    /// Writes the value to the <paramref name="writer" />. This is used to serialize the content type and not to write the content itself
    /// </summary>
    /// <param name="writer">The to write the value to.</param>
    /// <param name="value">The that is to be written. This is used to serialize the content type and not to write the content itself.</param>
    /// <param name="options">The used to serialize the value. This is used to serialize the content type</param>
    public override void Write(Utf8JsonWriter writer, IMediaType value, Jso options)
    {
        writer.WriteStringValue(value.ToString());
    }
}
