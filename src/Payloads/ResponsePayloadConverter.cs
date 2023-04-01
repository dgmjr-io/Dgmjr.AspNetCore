/*
 * ResponsePayloadConverter.cs
 *
 *   Created: 2022-12-09-11:43:14
 *   Modified: 2022-12-09-11:43:14
 *
 *   Author: David G. Moore, Jr, <david@dgmjr.io>
 *
 *   Copyright © 2022-2023 David G. Moore, Jr,, All Rights Reserved
 *      License: MIT (https://opensource.org/licenses/MIT)
 */

namespace Dgmjr.Payloads;

public class ResponsePayloadConverter<T> : JsonConverter<ResponsePayload<T>>
{
    public override ResponsePayload<T> Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        throw new NotImplementedException();
    }

    public override void Write(
        Utf8JsonWriter writer,
        ResponsePayload<T> value,
        JsonSerializerOptions options
    )
    {
        writer.WriteStartObject();
        writer.WriteBoolean("isSuccess", value.IsSuccess);
        writer.WriteString("message", value.Message);
        writer.WriteString("stringValue", value.StringValue);
        writer.WritePropertyName("value");
        Serialize(writer, value.Value, options);
        writer.WriteEndObject();
    }
}
