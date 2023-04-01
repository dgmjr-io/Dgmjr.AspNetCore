/*
 * PathLowercaseDocumentFilter.cs
 *
 *   Created: 2022-12-14-05:03:06
 *   Modified: 2022-12-14-05:03:07
 *
 *   Author: David G. Moore, Jr, <david@dgmjr.io>
 *
 *   Copyright © 2022-2023 David G. Moore, Jr,, All Rights Reserved
 *      License: MIT (https://opensource.org/licenses/MIT)
 */
#pragma warning disable
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Dgmjr.AspNetCore.Swagger;

public class PathLowercaseDocumentFilter : IDocumentFilter
{
    public void Apply(OpenApiDocument swaggerDoc, DocumentFilterContext context)
    {
        var dictionaryPath = swaggerDoc.Paths.ToDictionary(x => ToLowercase(x.Key), x => x.Value);
        var newPaths = new OpenApiPaths();
        foreach (var path in dictionaryPath)
        {
            newPaths.Add(path.Key, path.Value);
        }
        swaggerDoc.Paths = newPaths;
    }

    private static string ToLowercase(string key)
    {
        var parts = key.Split('/')
            .Select(part => part.Contains("}") ? part : part.ToLowerInvariant());
        return string.Join('/', parts);
    }
}
