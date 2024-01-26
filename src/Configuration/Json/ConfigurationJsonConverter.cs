namespace Dgmjr.Configuration.Extensions;

public class ConfigurationJsonConverter : JsonConverter<IConfiguration>
{
    public override IConfiguration? Read(ref Utf8JsonReader reader, type typeToConvert, Jso options)
    {
        using var jsonStream = new MemoryStream(reader.ValueSpan.ToArray());
        return new ConfigurationBuilder().AddJsonStream(jsonStream).Build();
    }

    public override void Write(Utf8JsonWriter writer, IConfiguration value, Jso options)
    {
        writer.WriteStartObject();
        foreach (var section in value.GetChildren())
        {
            writer.WritePropertyName(section.Key);
            if (section.GetChildren().Any())
            {
                Write(writer, section, options);
            }
            else
            {
                writer.WriteStringValue(section.Value);
            }
        }
        writer.WriteEndObject();
    }
}
