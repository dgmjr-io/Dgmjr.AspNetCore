namespace Dgmjr.Extensions.Configuration;

public static class ConfigurationExtensions
{
    public static string ToJson(this IConfiguration config)
    {
        return JsonSerializer.Serialize(config, new Jso
        {
            WriteIndented = true,
            Converters = { new ConfigurationJsonConverter() }
        });
    }
}
