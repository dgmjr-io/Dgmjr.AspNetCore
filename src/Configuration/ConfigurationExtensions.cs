namespace Dgmjr.Extensions.Configuration;

public static class ConfigurationExtensions
{
    public static string ToJson(this IConfiguration config) =>
        JsonSerializer.Serialize(config.AsEnumerable(), new Jso
        {
            WriteIndented = true,
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            DictionaryKeyPolicy = JsonNamingPolicy.CamelCase,
        });
}
