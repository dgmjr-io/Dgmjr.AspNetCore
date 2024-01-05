/*
 * DescribeTypesForAllOutputFormatters.cs
 *
 *   Created: 2023-01-04-10:24:47
 *   Modified: 2023-01-04-10:24:47
 *
 *   Author: David G. Moore, Jr, <david@dgmjr.io>
 *
 *   Copyright © 2022-2023 David G. Moore, Jr,, All Rights Reserved
 *      License: MIT (https://opensource.org/licenses/MIT)
 */


namespace Dgmjr.AspNetCore.Swagger
{
    using System.Linq;

    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc.Formatters;
    using Microsoft.OpenApi.Any;
    using Microsoft.OpenApi.Models;

    using Swashbuckle.AspNetCore.SwaggerGen;

    public class DescribeTypesForAllOutputFormattersFilter : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            var detailedApiDescription = new DetailedApiDescription(context.ApiDescription);

            var responseTypes = detailedApiDescription.DetailedApiResponseTypes;

            foreach (var responseType in responseTypes)
            {
                var openApiResponse =
                    operation.Responses
                        .FirstOrDefault(x => x.Key == responseType.StatusCode.ToString())
                        .Value ?? new OpenApiResponse();

                foreach (var responseFormat in responseType.DetailedApiResponseFormats)
                {
                    var mediaType = responseFormat.MediaType;
                    var formatter = responseFormat.Formatter;

                    var openApiMediaType =
                        openApiResponse.Content.FirstOrDefault(x => x.Key == mediaType).Value
                        ?? new OpenApiMediaType();
                    var ms = new MemoryStream();
                    var writer = new StreamWriter(ms);
                    var @object = Activator.CreateInstance(responseType.Type);

                    var httpContext = new DefaultHttpContext();
                    httpContext.Response.Body = ms;

                    openApiMediaType.Schema = context.SchemaGenerator.GenerateSchema(
                        responseType.Type,
                        context.SchemaRepository
                    );

                    formatter.WriteAsync(
                        new OutputFormatterWriteContext(
                            httpContext,
                            (stream, encoding) => new StreamWriter(stream, encoding),
                            responseType.Type,
                            @object
                        )
                    );

                    openApiMediaType.Example = new OpenApiString(UTF8.GetString(ms.ToArray()));
                    openApiResponse.Content[mediaType] = openApiMediaType;
                }
            }
        }
    }
}
