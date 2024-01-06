/*
 * ExamplesFilter.cs
 *
 *   Created: 2023-01-03-02:31:51
 *   Modified: 2023-01-03-02:31:52
 *
 *   Author: David G. Moore, Jr, <david@dgmjr.io>
 *
 *   Copyright © 2022-2023 David G. Moore, Jr,, All Rights Reserved
 *      License: MIT (https://opensource.org/licenses/MIT)
 */

namespace Dgmjr.AspNetCore.Swagger;

using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

public class ExamplesSchemaFilter : ISchemaFilter
{
    public void Apply(OpenApiSchema schema, SchemaFilterContext context)
    {
        if (schema.Properties == null)
        {
            return;
        }

        foreach (var property in schema.Properties)
        {
            if (property.Value.Example == null)
            {
                property.Value.Example = new OpenApiString($"Example of {property.Key}");
            }
        }
    }
}
