/*
 * AuthorizationHeaderParameterOperationFilter.cs
 *
 *   Created: 2022-12-10-07:05:54
 *   Modified: 2022-12-10-07:05:55
 *
 *   Author: David G. Moore, Jr, <david@dgmjr.io>
 *
 *   Copyright © 2022-2023 David G. Moore, Jr,, All Rights Reserved
 *      License: MIT (https://opensource.org/licenses/MIT)
 */

namespace Dgmjr.AspNetCore.Authentication;

using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

public class AuthorizationHeaderParameterOperationFilter : IOperationFilter
{
    public void Apply(OpenApiOperation operation, OperationFilterContext context)
    {
        var filterPipeline = context.ApiDescription.ActionDescriptor.FilterDescriptors;
        var isAuthorized = filterPipeline
            .Select(filterInfo => filterInfo.Filter)
            .Any(filter => filter is AuthorizeFilter);
        var allowAnonymous = filterPipeline
            .Select(filterInfo => filterInfo.Filter)
            .Any(filter => filter is IAllowAnonymousFilter);

        if (isAuthorized && !allowAnonymous)
        {
            if (operation.Parameters == null)
                operation.Parameters = new List<OpenApiParameter>();

            operation.Parameters.Add(
                new OpenApiParameter
                {
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Description = "access token",
                    Required = true,
                    Schema = new() { Type = "string", Default = new OpenApiString("Bearer ") }
                }
            );
        }
    }
}
