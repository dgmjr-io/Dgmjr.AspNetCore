namespace Microsoft.Extensions.DependencyInjection;

using Dgmjr.Configuration.Extensions;

using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Primitives;

using System.Collections;
using System.Collections.Generic;
using System.IO;
using static JsonFileConfigurationExtensions;

public static partial class JsonFileConfigurationExtensions
{
    public const string AppSettings = "all_appsettings";
    public const string AppSettings_Json = "/" + AppSettings + ".json";

    public static IConfigurationManager AddKeyPerJsonFile(
        this IConfigurationManager config,
        string path,
        bool recursive = true,
        bool reloadOnChange = false,
        ILogger? logger = null
    ) => config.AddKeyPerJsonFile(new DirectoryInfo(path), recursive, reloadOnChange, logger);

    public static IConfigurationManager AddKeyPerJsonFile(
        this IConfigurationManager config,
        DirectoryInfo directory,
        bool recursive = true,
        bool reloadOnChange = false,
        ILogger? logger = null
    )
    {
        Console.WriteLine($"Adding JSON config files in {directory.FullName} to configuration");

        var json = directory.MakeAppsettingsJsonFile(recursive);

        Console.WriteLine(
            $"Regenerated {AppSettings_Json} with {json.CountLines()} lines and {json.Length} bytes{env.NewLine}{json}"
        );

        config.AddJsonFile(
            Path.Join(directory.FullName, "../" + AppSettings_Json),
            false,
            reloadOnChange
        );
        if (reloadOnChange)
        {
            ChangeToken.OnChange(
                () =>
                    new PhysicalFileProvider(directory.FullName).Watch(
                        recursive ? "**/*.json" : "./*.json"
                    ),
                () =>
                {
                    Console.WriteLine(
                        $"JSON config files in {directory.FullName} changed; regenerating {AppSettings_Json}..."
                    );
                    var json = directory.MakeAppsettingsJsonFile(recursive);
                    Console.WriteLine(
                        $"Regenerated {AppSettings_Json} with {json.CountLines()} lines and {json.Length} bytes"
                    );
                }
            );
        }

        return config;
    }

    internal static void OnLoadException(FileLoadExceptionContext ctx)
    {
        Console.WriteLine(
            $"Error loading JSON virtual composite config file {AppSettings_Json}: {ctx.Exception.Message}{env.NewLine}{ctx.Exception.InnerException}"
        );
    }

    internal static string ThisEnvironmentName =>
        env.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")
        ?? env.GetEnvironmentVariable("DOTNET_ENVIRONMENT")
        ?? env.GetEnvironmentVariable("ENVIRONMENT")
        ?? Environments.Production;

    internal static readonly string[] EnvironmentNames = Hosting.EnvironmentNames.All;

    internal static readonly string EnvironmentizedRegexString = $@"^(?<Filename>[a-zA-Z0-9:\-]*(?:\.[a-zA-Z0-9:\-])*)(?:\.(?<Environment>{Join("|", EnvironmentNames.Select(env => $"(?:{env})"))}))?\.json$";
    public static Regx EnvironmentizedRegex =>
        new(EnvironmentizedRegexString, Rxo.Compiled | Rxo.IgnoreCase);

    public static Regx ThisEnvironmentRegex =>
        new(
            $@"^(?<Filename>[a-zA-Z0-9:\-]*(?:\.[a-zA-Z0-9:\-])*)(?:\.(?<Environment>{ThisEnvironmentName}))\.json$",
            Rxo.Compiled | Rxo.IgnoreCase
        );

    internal static IEnumerable<FileInfo> GetJsonFiles(
        this DirectoryInfo directory,
        bool recursive
    ) =>
        directory
            .EnumerateFiles(
                "*.json",
                recursive ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly
            )
            // .Where(IsForThisEnvironment)
            .OrderBy(jsonFile => jsonFile.Name);

    internal static string RemoveEnvironmentIfIsForThisEnvironment(this string jsonFileName) =>
        IsForThisEnvironment(new FileInfo(jsonFileName))
            ? ThisEnvironmentRegex.Replace(jsonFileName, "${Filename}")
            : jsonFileName;

#if NET7_0_OR_GREATER
    [GeneratedRegex("\n", Rxo.Compiled)]
    private static partial Regx LineBreakRegex();
#else
    private static readonly Regx _lineBreakRegex = new("\n", Rxo.Compiled);

    private static Regx LineBreakRegex() => _lineBreakRegex;
#endif

    internal static int CountLines(this string s) => LineBreakRegex().Matches(s).Count;

    internal static bool IsForThisEnvironment(this FileInfo jsonFile) =>
        ThisEnvironmentRegex.IsMatch(jsonFile.Name) || !EnvironmentizedRegex.IsMatch(jsonFile.Name);

    public static string MakeAppsettingsJsonFile(this DirectoryInfo directory, bool recursive)
    {
        var appsettingsJsonFileName = Path.Join(directory.FullName, "../" + AppSettings_Json);
        var jsonWriter = new StringBuilder();
        using (var appsettingsJsonFile = File.CreateText(appsettingsJsonFileName))
        using (var jsonStringWriter = new StringWriter(jsonWriter))
        using (var multiWriter = new MultiWriter(appsettingsJsonFile, jsonStringWriter))
        {
            var jsonFiles = directory.GetJsonFiles(recursive);

            appsettingsJsonFile.WriteLine("{");

            foreach (var jsonFile in jsonFiles)
            {
                Console.WriteLine(
                    $"Loading JSON config file {jsonFile.FullName}: {jsonFile.Length} bytes"
                );

                multiWriter.WriteLine(
                    $"\"{Path.GetFileNameWithoutExtension(jsonFile.FullName)}\":"
                );
                multiWriter.WriteLine(File.ReadAllText(jsonFile.FullName));
                multiWriter.WriteLine(",");
            }

            multiWriter.WriteLine("}");
        }
        return jsonWriter.ToString();
    }
}
