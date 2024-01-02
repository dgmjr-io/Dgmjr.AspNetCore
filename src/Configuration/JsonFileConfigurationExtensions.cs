namespace Microsoft.Extensions.DependencyInjection;

using System.IO;

public static class JsonFileConfigurationExtensions
{
    public static ConfigurationManager AddKeyPerJsonFile(
        this ConfigurationManager config,
        string path,
        bool recursive = true
    ) => config.AddKeyPerJsonFile(new DirectoryInfo(path), recursive);

    public static ConfigurationManager AddKeyPerJsonFile(
        this ConfigurationManager config,
        System.IO.DirectoryInfo directory,
        bool recursive = true
    )
    {
        ForEach(
            directory
                .EnumerateFiles(
                    "*.json",
                    recursive ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly
                )
                .ToArray(),
            jsonFile => {
                try { config = (config.AddJsonStream(jsonFile.MakeKeyPerJsonFileInputStream()) as ConfigurationManager)!; }
                catch(JsonException ex) { throw new JsonParseException(jsonFile, $"Failed to add {jsonFile.FullName} to {nameof(ConfigurationManager)}", ex); }
            }
        );
        return config;
    }

    internal static Stream MakeKeyPerJsonFileInputStream(this FileInfo jsonFile)
    {
        var json = $$$"""
        {
            "{{{Path.GetFileNameWithoutExtension(jsonFile.FullName)}}}":
            {{{File.ReadAllText(jsonFile.FullName)}}}
        }
        """;
        return new MemoryStream(UTF8.GetBytes(json));
    }

    public class JsonParseException : JsonException
    {
        public JsonParseException(FileInfo jsonFile) : base() { }

        public JsonParseException(FileInfo jsonFile, string message) : base(message) { }

        public JsonParseException(FileInfo jsonFile, string message, Exception innerException) : base(message, innerException) { }
    }
}
