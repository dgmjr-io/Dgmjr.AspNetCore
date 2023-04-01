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

namespace Microsoft.Extensions.DependencyInjection
{
    using Dgmjr.AspNetCore.Swagger;
    using Microsoft.AspNetCore.Builder;

    public static class DescribeTypesForAllOutputFormattersExtension
    {
        public static IServiceCollection AddDescribeTypesForAllOutputFormatters(
            this IServiceCollection services
        )
        {
            services.ConfigureSwaggerGen(
                opts => opts.OperationFilter<DescribeTypesForAllOutputFormattersFilter>()
            );
            return services;
        }

        public static WebApplicationBuilder AddDescribeTypesForAllOutputFormatters(
            this WebApplicationBuilder builder
        )
        {
            builder.Services.ConfigureSwaggerGen(
                opts => opts.OperationFilter<DescribeTypesForAllOutputFormattersFilter>()
            );
            return builder;
        }
    }
}

namespace Dgmjr.AspNetCore.Swagger
{
    using System.Linq;
    using System.Text;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc.ApiExplorer;
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

                    openApiMediaType.Example = new OpenApiString(System.Text.Encoding.UTF8.GetString(ms.ToArray()));
                    openApiResponse.Content[mediaType] = openApiMediaType;
                }
            }
        }

        // public static class ApiDescriptionExtensions
        // {
        //     public static IEnumerable<DetailedApiResponseFormat> ApiResponseFormats(this ApiResponseType responseType)
        //     {
        //         var formatterContext = new OutputFormatterWriteContext(
        //             new DefaultHttpContext(),
        //             (stream, encoding) => new StreamWriter(stream, encoding),
        //             responseType.Type,
        //             responseType.Object
        //         );

        //         var formatters = new List<OutputFormatter>();
        //         formatters.Add(new JsonOutputFormatter());
        //         formatters.Add(new XmlDataContractSerializerOutputFormatter());
        //         formatters.Add(new XmlSerializerOutputFormatter());

        //         foreach (var formatter in formatters)
        //         {
        //             if (!formatter.CanWriteResult(formatterContext))
        //                 continue;

        //             var mediaType = formatter.GetSupportedContentTypes(
        //                 formatterContext.ContentType,
        //                 formatterContext.ObjectType
        //             ).FirstOrDefault();

        //             if (mediaType == null)
        //                 continue;

        //             yield return new ApiResponseFormat
        //             {
        //                 MediaType = mediaType,
        //                 Formatter = formatter
        //             };
        //         }
        //     }
        // }
    }

    public class DetailedApiDescription : ApiDescription
    {
        public DetailedApiDescription(ApiDescription description)
        {
            ActionDescriptor = description.ActionDescriptor;
            HttpMethod = description.HttpMethod;
            RelativePath = description.RelativePath;
            GroupName = description.GroupName;
            description.SupportedRequestFormats.Select(format =>
            {
                SupportedRequestFormats.Add(format);
                return format;
            });
            description.SupportedResponseTypes.Select(responseType =>
            {
                SupportedResponseTypes.Add(responseType);
                return responseType;
            });
        }

        public virtual IEnumerable<DetailedApiResponseType> DetailedApiResponseTypes =>
            SupportedResponseTypes.Select(
                responseType => new DetailedApiResponseType(responseType)
            );
    }

    public class DetailedApiResponseType : ApiResponseType
    {
        public DetailedApiResponseType(ApiResponseType responseType)
        {
            Type = responseType.Type;
            StatusCode = responseType.StatusCode;
            ModelMetadata = responseType.ModelMetadata;
            IsDefaultResponse = responseType.IsDefaultResponse;
            responseType.ApiResponseFormats.Select(format =>
            {
                ApiResponseFormats.Add(format);
                return format;
            });
        }

        public virtual IEnumerable<DetailedApiResponseFormat> DetailedApiResponseFormats =>
            ApiResponseFormats.Select(format => new DetailedApiResponseFormat(format));
    }

    public class DetailedApiResponseFormat : ApiResponseFormat
    {
        public DetailedApiResponseFormat(ApiResponseFormat format)
        {
            MediaType = format.MediaType;
            Formatter = format.Formatter;
        }
    }
}
