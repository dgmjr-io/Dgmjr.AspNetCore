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
using MultipartMediaTypeNames = Dgmjr.Mime.MultipartMediaTypeNames;

namespace Microsoft.Extensions.DependencyInjection;

public static partial class SwaggerExtensions
{
    internal static IHostApplicationBuilder DescribeFileUploads(
        this IHostApplicationBuilder builder
    )
    {
        builder.Services.ConfigureSwaggerGen(
            options => options.OperationFilter<SwaggerFileOperationFilter>()
        );
        return builder;
    }
}
