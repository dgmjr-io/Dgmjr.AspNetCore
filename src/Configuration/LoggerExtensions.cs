using Microsoft.Extensions.Logging;

namespace Dgmjr.Configuration.Extensions;

public static partial class LoggerExtensions
{
    [LoggerMessage(1, LogLevel.Trace, "Found {Files} JSON files in {Directory} for environment {env}", EventName = "FilesFound")]
    public static partial void LogFilesFound(this ILogger logger, int files, string directory, string env);

    [LoggerMessage(2, LogLevel.Trace, "File {Filename}: {Lines} lines", EventName = "JSONConfigFileRead")]
    public static partial void LogJsonConfigFileRead(this ILogger logger, string filename, int lines);
}
