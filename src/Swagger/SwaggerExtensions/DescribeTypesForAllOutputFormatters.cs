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

    internal static partial class InternalSwaggerExtensions
    {
        public static IServiceCollection DescribeTypesForAllOutputFormatters(
            this IServiceCollection services
        )
        {
            services.ConfigureSwaggerGen(
                opts => opts.OperationFilter<DescribeTypesForAllOutputFormattersFilter>()
            );
            return services;
        }

        public static WebApplicationBuilder DescribeTypesForAllOutputFormatters(
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

    public class DetailedApiDescription : ApiDescription
    {
        public DetailedApiDescription(ApiDescription description)
        {
            ActionDescriptor = description.ActionDescriptor;
            HttpMethod = description.HttpMethod;
            RelativePath = description.RelativePath;
            GroupName = description.GroupName;
#pragma warning disable S2201, CA1806
            description.SupportedRequestFormats.Select(format =>
            {
                SupportedRequestFormats.Add(format);
                return format;
            });
            description.SupportedResponseTypes.Select(responseType =>
#pragma warning restore S2201, CA1806
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
#pragma warning disable S2201, CA1806
            responseType.ApiResponseFormats.Select(format =>
#pragma warning restore S2201, CA1806
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
