/*
 * SwaggerFileUploadFilter.cs
 *
 *   Created: 2022-12-31-01:09:15
 *   Modified: 2022-12-31-01:09:15
 *
 *   Author: David G. Moore, Jr, <david@dgmjr.io>
 *
 *   Copyright © 2022-2023 David G. Moore, Jr,, All Rights Reserved
 *      License: MIT (https://opensource.org/licenses/MIT)
 */
namespace Dgmjr.AspNetCore.Swagger;

using Dgmjr.Mime;
using Dgmjr.AspNetCore.Swagger;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using MultipartMediaTypeNames = Dgmjr.Mime.MultipartMediaTypeNames;

public class SwaggerFileOperationFilter : IOperationFilter
{
    const string FileUploadMimeType = MultipartMediaTypeNames.FormData;

    public void Apply(OpenApiOperation operation, OperationFilterContext context)
    {
        if (
            operation.RequestBody?.Content.Any(
                x => x.Key.Equals(FileUploadMimeType, InvariantCultureIgnoreCase)
            ) != true
        )
        {
            return;
        }

        var fileParams = context.MethodInfo
            .GetParameters()
            .Where(p => typeof(IFormFile).IsAssignableFrom(p.ParameterType));
        operation.RequestBody.Content[FileUploadMimeType].Schema.Properties =
            fileParams.ToDictionary(
                k => k.Name ?? "file",
                _ => new OpenApiSchema() { Type = "string", Format = "binary" }
            );
    }
}
