﻿/*
 * PlainTextInputFormatter.cs
 *
 *   Created: 2022-12-30-11:38:40
 *   Modified: 2022-12-30-11:38:41
 *
 *   Author: David G. Moore, Jr, <david@dgmjr.io>
 *
 *   Copyright © 2022-2023 David G. Moore, Jr,, All Rights Reserved
 *      License: MIT (https://opensource.org/licenses/MIT)
 */

namespace Dgmjr.AspNetCore.Formatters;

using System.Collections.Generic;
using System.Net.Mime.MediaTypes;
using Microsoft.AspNetCore.Mvc.Formatters;

public class PlainTextInputFormatter : InputFormatter
{
    private const string ContentType = TextMediaTypeNames.Any;

    public PlainTextInputFormatter()
    {
        SupportedMediaTypes.Add(TextMediaTypeNames.Plain);
        SupportedMediaTypes.Add(TextMediaTypeNames.Css);
        SupportedMediaTypes.Add(TextMediaTypeNames.Csv);
        SupportedMediaTypes.Add(TextMediaTypeNames.Any);
    }

    /// <inheritdoc />
    public override async Task<InputFormatterResult> ReadRequestBodyAsync(
        InputFormatterContext context
    )
    {
        var request = context.HttpContext.Request;
        using (var reader = new StreamReader(request.Body))
        {
            var content = await reader.ReadToEndAsync();
            return await InputFormatterResult.SuccessAsync(
                Convert.ChangeType(content, context.ModelType)
            );
        }
    }

    /// <inheritdoc />
    public override IReadOnlyList<string> GetSupportedContentTypes(
        string contentType,
        Type objectType
    ) => new[] { ContentType };

    public override bool CanRead(InputFormatterContext context)
    {
        return (context.ModelType.IsPrimitive || context.ModelType == typeof(string)) //& || context.ModelType.GetInterfaces().Any(i => i.IsGenericType && i.GetGenericTypeDefinition == typeof(IPayload<>) && i.GetGenericArguments()[0].IsPrimitive)
            && context.HttpContext.Request.ContentType.Contains(
                ContentType,
                StringComparison.OrdinalIgnoreCase
            );
    }
}
