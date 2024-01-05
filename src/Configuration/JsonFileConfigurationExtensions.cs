namespace Microsoft.Extensions.DependencyInjection;

using Dgmjr.Application.Configuration;

using Microsoft.Extensions.Logging;
using System.IO;

public static partial class JsonFileConfigurationExtensions
{
    public static ConfigurationManager AddKeyPerJsonFile(
        this ConfigurationManager config,
        string path,
        bool recursive = true,
        ILogger? logger = null
    ) => config.AddKeyPerJsonFile(new DirectoryInfo(path), recursive, logger);

    public static ConfigurationManager AddKeyPerJsonFile(
        this ConfigurationManager config,
        DirectoryInfo directory,
        bool recursive = true,
        ILogger? logger = null
    )
    {
        var files =
            directory
                .EnumerateFiles(
                    "*.json",
                    recursive ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly
                )
                .Where(IsForThisEnvironment)
                .ToArray();

        Console.WriteLine($"Found {files.Length} JSON files in {directory.FullName} for environment {env.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")}");

        ForEach(files,
            jsonFile =>
            {
                try
                {
                    config = (
                        config.AddJsonStream(jsonFile.MakeKeyPerJsonFileInputStream())
                        as ConfigurationManager
                    )!;
                }
                catch (JsonException ex)
                {
                    throw new JsonParseException(
                        jsonFile,
                        $"Failed to add {jsonFile.FullName} to {nameof(ConfigurationManager)}",
                        ex
                    );
                }
            }
        );
        return config;
    }

    internal static Regx ThisEnvironmentRegex =>
        new(
            $@"^(?<Filename>[a-zA-Z0-9:\-\.]*?)(?:$|(?:\.{env.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")}\.json$))",
            Rxo.Compiled | Rxo.IgnoreCase
        );

#if NET7_0_OR_GREATER
    [GeneratedRegex("\n", Rxo.Compiled)]
    private static partial Regx LineBreakRegex();
#else
    private static readonly Regx _lineBreakRegex = new Regex("\n", Rxo.Compiled);
    private static Regx LineBreakRegex() => _lineBreakRegex;
#endif

    internal static int CountLines(this string s) => LineBreakRegex().Matches(s).Count;

    internal static bool IsForThisEnvironment(this FileInfo jsonFile) =>
        ThisEnvironmentRegex.IsMatch(jsonFile.Name);

    internal static Stream MakeKeyPerJsonFileInputStream(this FileInfo jsonFile, ILogger? logger = null)
    {
        var json = File.ReadAllText(jsonFile.FullName);

        Console.WriteLine($"Loaded JSON config file {jsonFile.FullName}: {json.CountLines()} lines");

        json = $$$"""
        {
            "{{{Path.GetFileNameWithoutExtension(jsonFile.FullName)}}}":
            {{{json}}}
        }
        """;
        return new MemoryStream(json.ToUTF8Bytes());
    }

    public class JsonParseException : JsonException
    {
        public FileInfo JsonFile { get; }

        public JsonParseException(FileInfo jsonFile)
            : this(jsonFile, $"Parse exception with JSON file: {jsonFile.FullName}")
        {
            JsonFile = jsonFile;
        }

        public JsonParseException(FileInfo jsonFile, string message)
            : base(message)
        {
            JsonFile = jsonFile;
        }

        public JsonParseException(FileInfo jsonFile, string message, Exception innerException)
            : base(message, innerException)
        {
            JsonFile = jsonFile;
        }
    }
}
