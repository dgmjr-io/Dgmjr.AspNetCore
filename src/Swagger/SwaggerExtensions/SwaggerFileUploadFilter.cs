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

using Dgmjr.Mime;
using Dgmjr.AspNetCore.Swagger;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Dgmjr.AspNetCore.Swagger
{
    public class SwaggerFileOperationFilter : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            var fileUploadMime = MultipartMediaTypeNames.FormData;
            if (
                operation.RequestBody == null
                || !operation.RequestBody.Content.Any(
                    x => x.Key.Equals(fileUploadMime, InvariantCultureIgnoreCase)
                )
            )
                return;

            var fileParams = context.MethodInfo
                .GetParameters()
                .Where(p => p.ParameterType == typeof(IFormFile));
            operation.RequestBody.Content[fileUploadMime].Schema.Properties =
                fileParams.ToDictionary(
                    k => k.Name,
                    v => new OpenApiSchema() { Type = "string", Format = "binary" }
                );
        }
    }
}

namespace Microsoft.Extensions.DependencyInjection
{
    public static class SwaggerFileUploadFilterExtension
    {
        public static WebApplicationBuilder DescribeFileUploads(this WebApplicationBuilder builder)
        {
            builder.Services.ConfigureSwaggerGen(
                options => options.OperationFilter<SwaggerFileOperationFilter>()
            );
            return builder;
        }
    }
}
