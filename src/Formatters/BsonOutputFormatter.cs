namespace Dgmjr.AspNetCore.Formatters;

using System.Collections.Generic;
using System.Net.Mime.MediaTypes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Formatters;
using Newtonsoft.Json;
using Newtonsoft.Json.Bson;

public class BsonOutputFormatter : OutputFormatter
{
    public BsonOutputFormatter() => SupportedMediaTypes.Add(ApplicationMediaTypeNames.Bson);

    private JsonSerializerSettings _jsonSerializerSettings = CreateDefaultSerializerSettings();

    public static JsonSerializerSettings CreateDefaultSerializerSettings()
    {
        return new JsonSerializerSettings()
        {
            MissingMemberHandling = MissingMemberHandling.Ignore,
            TypeNameHandling = TypeNameHandling.None
        };
    }

    public override IReadOnlyList<string> GetSupportedContentTypes(
        string contentType,
        Type objectType
    ) => new[] { ApplicationMediaTypeNames.Bson };

    public JsonSerializerSettings SerializerSettings =>
        _jsonSerializerSettings ??= CreateDefaultSerializerSettings();

    public bool CanRead(InputFormatterContext context) =>
        context.HttpContext.Request
            .GetTypedHeaders()
            .ContentType.MediaType.ToString()
            .Contains(ApplicationMediaTypeNames.Bson);

    public override bool CanWriteResult(OutputFormatterCanWriteContext context) => //context.Object is string &&
        context.HttpContext.Request
            .GetTypedHeaders()
            .Accept.Any(a => a.MediaType.Value.ToLower().StartsWith("application/bson"));

    protected override bool CanWriteType(Type type) => true;

    public override async Task WriteResponseBodyAsync(OutputFormatterWriteContext context)
    {
        if (context.ObjectType == null)
            throw new ArgumentNullException("type is null");
        if (context.WriterFactory == null)
            throw new ArgumentNullException("Write stream is null");

        using var ms = new MemoryStream();
        using var bsonWriter = new BsonDataWriter(ms) { CloseOutput = false };
        var jsonSerializer = JsonSerializer.Create(SerializerSettings);
        jsonSerializer.Serialize(bsonWriter, context.Object);
        bsonWriter.Flush();
        context.HttpContext.Response.ContentType = ApplicationMediaTypeNames.Bson;
        await context.HttpContext.Response.Body.WriteAsync(
            ms.ToArray().AsMemory(0, (int)ms.Length)
        );
    }
}
