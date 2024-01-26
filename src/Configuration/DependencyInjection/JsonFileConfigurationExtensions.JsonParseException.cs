namespace Microsoft.Extensions.DependencyInjection;

using System.IO;

public static partial class JsonFileConfigurationExtensions
{
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
