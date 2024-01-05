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
public class OpenApiSchemaAttribute : Attribute, IOpenApiExtensible
{
    protected virtual OpenApiSchema ToSchema()
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
            Nullable = Nullable,
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

    /// <summary>
    ///     Follow JSON Schema definition. Short text providing information about the data.
    /// </summary>
    public string Title { get; set; }

    /// <summary>
    ///     Follow JSON Schema definition: https://tools.ietf.org/html/draft-fge-json-schema-validation-00
    ///     Value MUST be a string. Multiple types via an array are not supported.
    /// </summary>
    public string Type { get; set; }

    /// <summary>
    ///     Follow JSON Schema definition: https://tools.ietf.org/html/draft-fge-json-schema-validation-00
    ///     While relying on JSON Schema's defined formats, the OAS offers a few additional
    ///     predefined formats.
    /// </summary>
    public string Format { get; set; }

    /// <summary>
    ///     Follow JSON Schema definition: https://tools.ietf.org/html/draft-fge-json-schema-validation-00
    ///     CommonMark syntax MAY be used for rich text representation.
    /// </summary>
    public string Description { get; set; }

    /// <summary>
    ///     Follow JSON Schema definition: https://tools.ietf.org/html/draft-fge-json-schema-validation-00
    /// </summary>
    public decimal? Maximum { get; set; }

    /// <summary>
    ///     Follow JSON Schema definition: https://tools.ietf.org/html/draft-fge-json-schema-validation-00
    /// </summary>
    public bool? ExclusiveMaximum { get; set; }

    /// <summary>
    ///     Follow JSON Schema definition: https://tools.ietf.org/html/draft-fge-json-schema-validation-00
    /// </summary>
    public decimal? Minimum { get; set; }

    /// <summary>
    ///     Follow JSON Schema definition: https://tools.ietf.org/html/draft-fge-json-schema-validation-00
    /// </summary>
    public bool? ExclusiveMinimum { get; set; }

    /// <summary>
    ///     Follow JSON Schema definition: https://tools.ietf.org/html/draft-fge-json-schema-validation-00
    /// </summary>
    public int? MaxLength { get; set; }

    /// <summary>
    ///     Follow JSON Schema definition: https://tools.ietf.org/html/draft-fge-json-schema-validation-00
    /// </summary>
    public int? MinLength { get; set; }

    /// <summary>
    ///     Follow JSON Schema definition: https://tools.ietf.org/html/draft-fge-json-schema-validation-00
    ///     This string SHOULD be a valid regular expression, according to the ECMA 262 regular
    ///     expression dialect
    /// </summary>
    public string Pattern { get; set; }

    /// <summary>
    ///     Follow JSON Schema definition: https://tools.ietf.org/html/draft-fge-json-schema-validation-00
    /// </summary>
    public decimal? MultipleOf { get; set; }

    /// <summary>
    ///     Follow JSON Schema definition: https://tools.ietf.org/html/draft-fge-json-schema-validation-00
    ///     The default value represents what would be assumed by the consumer of the input
    ///     as the value of the schema if one is not provided. Unlike JSON Schema, the value
    ///     MUST conform to the defined type for the Schema Object defined at the same level.
    ///     For example, if type is string, then default can be "foo" but cannot be 1.
    /// </summary>
    public OpenApiAnyType Default { get; set; }

    /// <summary>
    ///     Relevant only for Schema "properties" definitions. Declares the property as "read
    ///     only". This means that it MAY be sent as part of a response but SHOULD NOT be
    ///     sent as part of the request. If the property is marked as readOnly being true
    ///     and is in the required list, the required will take effect on the response only.
    ///     A property MUST NOT be marked as both readOnly and writeOnly being true. Default
    ///     value is false.
    /// </summary>
    public bool ReadOnly { get; set; }

    /// <summary>
    ///     Relevant only for Schema "properties" definitions. Declares the property as "write
    ///     only". Therefore, it MAY be sent as part of a request but SHOULD NOT be sent
    ///     as part of the response. If the property is marked as writeOnly being true and
    ///     is in the required list, the required will take effect on the request only. A
    ///     property MUST NOT be marked as both readOnly and writeOnly being true. Default
    ///     value is false.
    /// </summary>
    public bool WriteOnly { get; set; }

    /// <summary>
    ///     Follow JSON Schema definition: https://tools.ietf.org/html/draft-fge-json-schema-validation-00
    ///     Inline or referenced schema MUST be of a Schema Object and not a standard JSON
    ///     Schema.
    /// </summary>
    public IList<OpenApiSchema> AllOf { get; set; } = new List<OpenApiSchema>();

    /// <summary>
    ///     Follow JSON Schema definition: https://tools.ietf.org/html/draft-fge-json-schema-validation-00
    ///     Inline or referenced schema MUST be of a Schema Object and not a standard JSON
    ///     Schema.
    /// </summary>
    public IList<OpenApiSchema> OneOf { get; set; } = new List<OpenApiSchema>();

    /// <summary>
    ///     Follow JSON Schema definition: https://tools.ietf.org/html/draft-fge-json-schema-validation-00
    ///     Inline or referenced schema MUST be of a Schema Object and not a standard JSON
    ///     Schema.
    /// </summary>
    public IList<OpenApiSchema> AnyOf { get; set; } = new List<OpenApiSchema>();

    /// <summary>
    ///     Follow JSON Schema definition: https://tools.ietf.org/html/draft-fge-json-schema-validation-00
    ///     Inline or referenced schema MUST be of a Schema Object and not a standard JSON
    ///     Schema.
    /// </summary>
    public OpenApiSchema Not { get; set; }

    /// <summary>
    ///     Follow JSON Schema definition: https://tools.ietf.org/html/draft-fge-json-schema-validation-00
    /// </summary>
    public ISet<string> Required { get; set; } = new HashSet<string>();

    /// <summary>
    ///     Follow JSON Schema definition: https://tools.ietf.org/html/draft-fge-json-schema-validation-00
    ///     Value MUST be an object and not an array. Inline or referenced schema MUST be
    ///     of a Schema Object and not a standard JSON Schema. items MUST be present if the
    ///     type is array.
    /// </summary>
    public OpenApiSchema Items { get; set; }

    /// <summary>
    ///     Follow JSON Schema definition: https://tools.ietf.org/html/draft-fge-json-schema-validation-00
    /// </summary>
    public int? MaxItems { get; set; }

    /// <summary>
    ///     Follow JSON Schema definition: https://tools.ietf.org/html/draft-fge-json-schema-validation-00
    /// </summary>
    public int? MinItems { get; set; }

    /// <summary>
    ///     Follow JSON Schema definition: https://tools.ietf.org/html/draft-fge-json-schema-validation-00
    /// </summary>
    public bool? UniqueItems { get; set; }

    /// <summary>
    ///     Follow JSON Schema definition: https://tools.ietf.org/html/draft-fge-json-schema-validation-00
    ///     Property definitions MUST be a Schema Object and not a standard JSON Schema (inline
    ///     or referenced).
    /// </summary>
    public IDictionary<string, OpenApiSchema> Properties { get; set; } =
        new Dictionary<string, OpenApiSchema>();

    /// <summary>
    ///     Follow JSON Schema definition: https://tools.ietf.org/html/draft-fge-json-schema-validation-00
    /// </summary>
    public int? MaxProperties { get; set; }

    /// <summary>
    ///     Follow JSON Schema definition: https://tools.ietf.org/html/draft-fge-json-schema-validation-00
    /// </summary>
    public int? MinProperties { get; set; }

    /// <summary>
    ///     Indicates if the schema can contain properties other than those defined by the
    ///     properties map.
    /// </summary>
    public bool AdditionalPropertiesAllowed { get; set; } = true;

    /// <summary>
    ///     Follow JSON Schema definition: https://tools.ietf.org/html/draft-fge-json-schema-validation-00
    ///     Value can be boolean or object. Inline or referenced schema MUST be of a Schema
    ///     Object and not a standard JSON Schema.
    /// </summary>
    public OpenApiSchema AdditionalProperties { get; set; }

    /// <summary>
    ///     Adds support for polymorphism. The discriminator is an object name that is used
    ///     to differentiate between other schemas which may satisfy the payload description.
    /// </summary>
    public OpenApiDiscriminator Discriminator { get; set; }

    /// <summary>
    ///     A free-form property to include an example of an instance for this schema. To
    ///     represent examples that cannot be naturally represented in JSON or YAML, a string
    ///     value can be used to contain the example with escaping where necessary.
    /// </summary>
    public OpenApiAnyType Example { get; set; }

    /// <summary>
    ///     Follow JSON Schema definition: https://tools.ietf.org/html/draft-fge-json-schema-validation-00
    /// </summary>
    public IList<IOpenApiAny> Enum { get; set; } = new List<IOpenApiAny>();

    /// <summary>
    ///     Allows sending a null value for the defined schema. Default value is false.
    /// </summary>
    public bool Nullable { get; set; }

    /// <summary>
    ///     Additional external documentation for this schema.
    /// </summary>
    public OpenApiExternalDocs ExternalDocs { get; set; }

    /// <summary>
    ///     This MAY be used only on properties schemas. It has no effect on root schemas.
    ///     Adds additional metadata to describe the XML representation of this property.
    /// </summary>
    public OpenApiXml Xml { get; set; }

    /// <summary>
    ///     This object MAY be extended with Specification Extensions.
    /// </summary>
    public IDictionary<string, IOpenApiExtension> Extensions { get; set; } =
        new Dictionary<string, IOpenApiExtension>();

    /// <summary>
    ///     Indicates object is a placeholder reference to an actual object and does not
    ///     contain valid data.
    /// </summary>
    public bool UnresolvedReference { get; set; }

    /// <summary>
    ///     Reference object.
    /// </summary>
    public OpenApiReference Reference { get; set; }
}
