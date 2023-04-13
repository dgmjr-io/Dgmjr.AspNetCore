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

using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Interfaces;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Microsoft.OpenApi.Attributes;

[AttributeUsage(AttributeTargets.All, AllowMultiple = true)]
public class OpenApiSchemaAttribute : Attribute, IOpenApiElement, IOpenApiExtensible
{
    public OpenApiSchemaAttribute() { }

    public virtual OpenApiSchema ToSchema()
    {
        var schema = new OpenApiSchema
        {
            Default = Default,
            Description = Description,
            Enum = Enum,
            ExclusiveMaximum = ExclusiveMaximum,
            ExclusiveMinimum = ExclusiveMinimum,
            Format = Format,
            Maximum = Maximum,
            MaxLength = MaxLength,
            MaxItems = MaxItems,
            Minimum = Minimum,
            MinLength = MinLength,
            MinItems = MinItems,
            MultipleOf = MultipleOf,
            Nullaable = Nullable,
            Pattern = Pattern,
            ReadOnly = ReadOnly,
            Title = Title,
            Type = Type,
            UniqueItems = UniqueItems,
            WriteOnly = WriteOnly
        };

        if (Extensions != null)
        {
            foreach (var extension in Extensions)
            {
                schema.Extensions.Add(extension.Key, extension.Value);
            }
        }

        return schema;
    }

    //
    // Summary:
    //     Follow JSON Schema definition. Short text providing information about the data.
    public string Title { get; set; }

    //
    // Summary:
    //     Follow JSON Schema definition: https://tools.ietf.org/html/draft-fge-json-schema-validation-00
    //     Value MUST be a string. Multiple types via an array are not supported.
    public string Type { get; set; }

    //
    // Summary:
    //     Follow JSON Schema definition: https://tools.ietf.org/html/draft-fge-json-schema-validation-00
    //     While relying on JSON Schema's defined formats, the OAS offers a few additional
    //     predefined formats.
    public string Format { get; set; }

    //
    // Summary:
    //     Follow JSON Schema definition: https://tools.ietf.org/html/draft-fge-json-schema-validation-00
    //     CommonMark syntax MAY be used for rich text representation.
    public string Description { get; set; }

    //
    // Summary:
    //     Follow JSON Schema definition: https://tools.ietf.org/html/draft-fge-json-schema-validation-00
    public decimal? Maximum { get; set; }

    //
    // Summary:
    //     Follow JSON Schema definition: https://tools.ietf.org/html/draft-fge-json-schema-validation-00
    public bool? ExclusiveMaximum { get; set; }

    //
    // Summary:
    //     Follow JSON Schema definition: https://tools.ietf.org/html/draft-fge-json-schema-validation-00
    public decimal? Minimum { get; set; }

    //
    // Summary:
    //     Follow JSON Schema definition: https://tools.ietf.org/html/draft-fge-json-schema-validation-00
    public bool? ExclusiveMinimum { get; set; }

    //
    // Summary:
    //     Follow JSON Schema definition: https://tools.ietf.org/html/draft-fge-json-schema-validation-00
    public int? MaxLength { get; set; }

    //
    // Summary:
    //     Follow JSON Schema definition: https://tools.ietf.org/html/draft-fge-json-schema-validation-00
    public int? MinLength { get; set; }

    //
    // Summary:
    //     Follow JSON Schema definition: https://tools.ietf.org/html/draft-fge-json-schema-validation-00
    //     This string SHOULD be a valid regular expression, according to the ECMA 262 regular
    //     expression dialect
    public string Pattern { get; set; }

    //
    // Summary:
    //     Follow JSON Schema definition: https://tools.ietf.org/html/draft-fge-json-schema-validation-00
    public decimal? MultipleOf { get; set; }

    //
    // Summary:
    //     Follow JSON Schema definition: https://tools.ietf.org/html/draft-fge-json-schema-validation-00
    //     The default value represents what would be assumed by the consumer of the input
    //     as the value of the schema if one is not provided. Unlike JSON Schema, the value
    //     MUST conform to the defined type for the Schema Object defined at the same level.
    //     For example, if type is string, then default can be "foo" but cannot be 1.
    public IOpenApiAny Default { get; set; }

    //
    // Summary:
    //     Relevant only for Schema "properties" definitions. Declares the property as "read
    //     only". This means that it MAY be sent as part of a response but SHOULD NOT be
    //     sent as part of the request. If the property is marked as readOnly being true
    //     and is in the required list, the required will take effect on the response only.
    //     A property MUST NOT be marked as both readOnly and writeOnly being true. Default
    //     value is false.
    public bool ReadOnly { get; set; }

    //
    // Summary:
    //     Relevant only for Schema "properties" definitions. Declares the property as "write
    //     only". Therefore, it MAY be sent as part of a request but SHOULD NOT be sent
    //     as part of the response. If the property is marked as writeOnly being true and
    //     is in the required list, the required will take effect on the request only. A
    //     property MUST NOT be marked as both readOnly and writeOnly being true. Default
    //     value is false.
    public bool WriteOnly { get; set; }

    //
    // Summary:
    //     Follow JSON Schema definition: https://tools.ietf.org/html/draft-fge-json-schema-validation-00
    //     Inline or referenced schema MUST be of a Schema Object and not a standard JSON
    //     Schema.
    public IList<OpenApiSchema> AllOf { get; set; } = new List<OpenApiSchema>();

    //
    // Summary:
    //     Follow JSON Schema definition: https://tools.ietf.org/html/draft-fge-json-schema-validation-00
    //     Inline or referenced schema MUST be of a Schema Object and not a standard JSON
    //     Schema.
    public IList<OpenApiSchema> OneOf { get; set; } = new List<OpenApiSchema>();

    //
    // Summary:
    //     Follow JSON Schema definition: https://tools.ietf.org/html/draft-fge-json-schema-validation-00
    //     Inline or referenced schema MUST be of a Schema Object and not a standard JSON
    //     Schema.
    public IList<OpenApiSchema> AnyOf { get; set; } = new List<OpenApiSchema>();

    //
    // Summary:
    //     Follow JSON Schema definition: https://tools.ietf.org/html/draft-fge-json-schema-validation-00
    //     Inline or referenced schema MUST be of a Schema Object and not a standard JSON
    //     Schema.
    public OpenApiSchema Not { get; set; }

    //
    // Summary:
    //     Follow JSON Schema definition: https://tools.ietf.org/html/draft-fge-json-schema-validation-00
    public ISet<string> Required { get; set; } = new HashSet<string>();

    //
    // Summary:
    //     Follow JSON Schema definition: https://tools.ietf.org/html/draft-fge-json-schema-validation-00
    //     Value MUST be an object and not an array. Inline or referenced schema MUST be
    //     of a Schema Object and not a standard JSON Schema. items MUST be present if the
    //     type is array.
    public OpenApiSchema Items { get; set; }

    //
    // Summary:
    //     Follow JSON Schema definition: https://tools.ietf.org/html/draft-fge-json-schema-validation-00
    public int? MaxItems { get; set; }

    //
    // Summary:
    //     Follow JSON Schema definition: https://tools.ietf.org/html/draft-fge-json-schema-validation-00
    public int? MinItems { get; set; }

    //
    // Summary:
    //     Follow JSON Schema definition: https://tools.ietf.org/html/draft-fge-json-schema-validation-00
    public bool? UniqueItems { get; set; }

    //
    // Summary:
    //     Follow JSON Schema definition: https://tools.ietf.org/html/draft-fge-json-schema-validation-00
    //     Property definitions MUST be a Schema Object and not a standard JSON Schema (inline
    //     or referenced).
    public IDictionary<string, OpenApiSchema> Properties { get; set; } =
        new Dictionary<string, OpenApiSchema>();

    //
    // Summary:
    //     Follow JSON Schema definition: https://tools.ietf.org/html/draft-fge-json-schema-validation-00
    public int? MaxProperties { get; set; }

    //
    // Summary:
    //     Follow JSON Schema definition: https://tools.ietf.org/html/draft-fge-json-schema-validation-00
    public int? MinProperties { get; set; }

    //
    // Summary:
    //     Indicates if the schema can contain properties other than those defined by the
    //     properties map.
    public bool AdditionalPropertiesAllowed { get; set; } = true;

    //
    // Summary:
    //     Follow JSON Schema definition: https://tools.ietf.org/html/draft-fge-json-schema-validation-00
    //     Value can be boolean or object. Inline or referenced schema MUST be of a Schema
    //     Object and not a standard JSON Schema.
    public OpenApiSchema AdditionalProperties { get; set; }

    //
    // Summary:
    //     Adds support for polymorphism. The discriminator is an object name that is used
    //     to differentiate between other schemas which may satisfy the payload description.
    public OpenApiDiscriminator Discriminator { get; set; }

    //
    // Summary:
    //     A free-form property to include an example of an instance for this schema. To
    //     represent examples that cannot be naturally represented in JSON or YAML, a string
    //     value can be used to contain the example with escaping where necessary.
    public IOpenApiAny Example { get; set; }

    //
    // Summary:
    //     Follow JSON Schema definition: https://tools.ietf.org/html/draft-fge-json-schema-validation-00
    public IList<IOpenApiAny> Enum { get; set; } = new List<IOpenApiAny>();

    //
    // Summary:
    //     Allows sending a null value for the defined schema. Default value is false.
    public bool Nullable { get; set; }

    //
    // Summary:
    //     Additional external documentation for this schema.
    public OpenApiExternalDocs ExternalDocs { get; set; }

    //
    // Summary:
    //     This MAY be used only on properties schemas. It has no effect on root schemas.
    //     Adds additional metadata to describe the XML representation of this property.
    public OpenApiXml Xml { get; set; }

    //
    // Summary:
    //     This object MAY be extended with Specification Extensions.
    public IDictionary<string, IOpenApiExtension> Extensions { get; set; } =
        new Dictionary<string, IOpenApiExtension>();

    //
    // Summary:
    //     Indicates object is a placeholder reference to an actual object and does not
    //     contain valid data.
    public bool UnresolvedReference { get; set; }

    //
    // Summary:
    //     Reference object.
    public OpenApiReference Reference { get; set; }
}

public class DescribeSchemasViaAttributesFilter : ISchemaFilter
{
    public void Apply(OpenApiSchema schema, SchemaFilterContext context)
    {
        var member = context.MemberInfo as ICustomAttributeProvider ?? context.ParameterInfo;
        var openApiSchemaAttribute = member
            .GetCustomAttributes(true)
            .OfType<OpenApiSchemaAttribute>()
            .FirstOrDefault();
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
