/*
 * EnumsAsStringsSchemaFilter copy.cs
 *
 *   Created: 2023-32-30T21:32:28-04:00
 *   Modified: 2023-32-30T21:32:31-04:00
 *
 *   Author: David G. Moore, Jr. <david@dgmjr.io>
 *
 *   Copyright © 2022 - 2023 David G. Moore, Jr., All Rights Reserved
 *      License: MIT (https://opensource.org/licenses/MIT)
 */

#pragma warning disable
using System.Runtime.Serialization;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Dgmjr.AspNetCore.Swagger;

public class DescribeSchemasViaAttributesFilter : ISchemaFilter
{
    public void Apply(OpenApiSchema model, SchemaFilterContext context)
    {
    }
}
