/*
 * OpenApiSchemaAttribute.cs
 *
 *   Created: 2022-12-21-07:55:34
 *   Modified: 2022-12-21-07:55:34
 *
 *   Author: David G. Moore, Jr, <david@dgmjr.io>
 *
 *   Copyright © 2022-2023 David G. Moore, Jr,, All Rights Reserved
 *      License: MIT (https://opensource.org/licenses/MIT)
 */

using Microsoft.OpenApi.Attributes;
using Microsoft.OpenApi.Models;

using Swashbuckle.AspNetCore.SwaggerGen;

namespace Dgmjr.AspNetCore.Swagger;

public class DescribeSchemasViaAttributesFilter : ISchemaFilter
{
    public void Apply(OpenApiSchema schema, SchemaFilterContext context)
    {
        var member = context.MemberInfo as ICustomAttributeProvider ?? context.ParameterInfo;
        var openApiSchemaAttribute = member
            ?.GetCustomAttributes(true)
            ?.OfType<OpenApiSchemaAttribute>()
            ?.FirstOrDefault();
        if (openApiSchemaAttribute != null)
        {
            if (openApiSchemaAttribute.Type != null)
            {
                schema.Type = openApiSchemaAttribute.Type;
            }

            if (openApiSchemaAttribute.Format != null)
            {
                schema.Format = openApiSchemaAttribute.Format;
            }

            if (openApiSchemaAttribute.Description != null)
            {
                schema.Description = openApiSchemaAttribute.Description;
            }

            if (openApiSchemaAttribute.Example != null)
            {
                schema.Example = openApiSchemaAttribute.Example;
            }

            if (openApiSchemaAttribute.Default != null)
            {
                schema.Default = openApiSchemaAttribute.Default;
            }

            if (openApiSchemaAttribute.ReadOnly)
            {
                schema.ReadOnly = openApiSchemaAttribute.ReadOnly;
            }

            if (openApiSchemaAttribute.WriteOnly)
            {
                schema.WriteOnly = openApiSchemaAttribute.WriteOnly;
            }

            if (openApiSchemaAttribute.Nullable)
            {
                schema.Nullable = openApiSchemaAttribute.Nullable;
            }

            if (openApiSchemaAttribute.Discriminator != null)
            {
                schema.Discriminator = openApiSchemaAttribute.Discriminator;
            }

            if (openApiSchemaAttribute.ExternalDocs != null)
            {
                schema.ExternalDocs = openApiSchemaAttribute.ExternalDocs;
            }

            if (openApiSchemaAttribute.Xml != null)
            {
                schema.Xml = openApiSchemaAttribute.Xml;
            }

            if (openApiSchemaAttribute.Extensions != null)
            {
                foreach (var extension in openApiSchemaAttribute.Extensions)
                {
                    schema.Extensions.Add(extension.Key, extension.Value);
                }
            }

            if (openApiSchemaAttribute.Enum != null)
            {
                schema.Enum = openApiSchemaAttribute.Enum;
            }

            if (openApiSchemaAttribute.MinLength != null)
            {
                schema.MinLength = openApiSchemaAttribute.MinLength;
            }

            if (openApiSchemaAttribute.MaxLength != null)
            {
                schema.MaxLength = openApiSchemaAttribute.MaxLength;
            }

            if (openApiSchemaAttribute.Pattern != null)
            {
                schema.Pattern = openApiSchemaAttribute.Pattern;
            }

            if (openApiSchemaAttribute.MinItems != null)
            {
                schema.MinItems = openApiSchemaAttribute.MinItems;
            }

            if (openApiSchemaAttribute.MaxItems != null)
            {
                schema.MaxItems = openApiSchemaAttribute.MaxItems;
            }
        }
    }
}
