/*
 * BsonInputFormatter.cs
 *
 *   Created: 2023-01-02-09:57:42
 *   Modified: 2023-01-02-09:57:42
 *
 *   Author: David G. Moore, Jr, <david@dgmjr.io>
 *
 *   Copyright © 2022-2023 David G. Moore, Jr,, All Rights Reserved
 *      License: MIT (https://opensource.org/licenses/MIT)
 */

namespace Dgmjr.AspNetCore.Formatters;

using System.Collections;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Bson;

public class BsonInputFormatter : InputFormatter
{
    private JsonSerializerSettings __jsonSerializerSettings = CreateDefaultSerializerSettings();

    public static JsonSerializerSettings CreateDefaultSerializerSettings()
    {
        return new JsonSerializerSettings()
        {
            MissingMemberHandling = MissingMemberHandling.Ignore,
            TypeNameHandling = TypeNameHandling.None
        };
    }

    public JsonSerializerSettings SerializerSettings =>
        __jsonSerializerSettings ??= CreateDefaultSerializerSettings();

    public override Task<InputFormatterResult> ReadRequestBodyAsync(InputFormatterContext context)
    {
        var request = context.HttpContext.Request;
        var contentHeaders = request.GetTypedHeaders().ContentType;
        var contentLength = request.GetTypedHeaders().ContentLength;
        var stream = request.Body;
        var type = context.ModelType;
        var formatterLogger = context.HttpContext.RequestServices.GetService<
            ILogger<BsonInputFormatter>
        >();
        var tcs = new TaskCompletionSource<InputFormatterResult>();
        if (contentHeaders != null && contentLength == 0)
            return Task.FromResult(InputFormatterResult.NoValue());

        try
        {
            var reader = new BsonDataReader(stream);
            if (typeof(IEnumerable).IsAssignableFrom(type))
                reader.ReadRootValueAsArray = true;

            using (reader)
            {
                var jsonSerializer = JsonSerializer.Create(SerializerSettings);
                var output = jsonSerializer.Deserialize(reader, type);
                if (formatterLogger != null)
                {
                    jsonSerializer.Error += (sender, e) =>
                    {
                        var exception = e.ErrorContext.Error;
                        formatterLogger.LogError(e.ErrorContext.Path, exception.Message);
                        e.ErrorContext.Handled = true;
                    };
                }
                tcs.SetResult(InputFormatterResult.Success(output));
            }
        }
        catch (Exception e)
        {
            tcs.SetException(e);
        }

        return tcs.Task;
    }
}
