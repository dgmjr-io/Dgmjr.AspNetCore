/*
 * DescribeHashidsExtensions.cs
 *
 *   Created: 2022-12-20-05:21:11
 *   Modified: 2022-12-20-05:21:11
 *
 *   Author: David G. Moore, Jr, <david@dgmjr.io>
 *
 *   Copyright © 2022-2023 David G. Moore, Jr,, All Rights Reserved
 *      License: MIT (https://opensource.org/licenses/MIT)
 */


namespace Dgmjr.AspNetCore.Hashids;

using System.Linq;
using global::AspNetCore.Hashids.Mvc;
using global::AspNetCore.Hashids.Options;
using HashidsNet;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

public class HashidsOperationFilter : IOperationFilter
{
    private readonly IHashids _hashids;
    private readonly HashidsOptions _options;

    public HashidsOperationFilter(IHashids hashids, IOptions<HashidsOptions> options)
    {
        _hashids = hashids;
        _options = options.Value;
    }

    public void Apply(OpenApiOperation operation, OperationFilterContext context)
    {
        var hashids = context.ApiDescription.ParameterDescriptions
            .Where(x => x.ModelMetadata.BinderType == typeof(HashidsModelBinder))
            .ToDictionary(d => d.Name, d => d);

        foreach (var parameter in operation.Parameters)
        {
            if (hashids.TryGetValue(parameter.Name, out var apiParameter))
            {
                parameter.Schema.Format = string.Empty;
                parameter.Schema.Type = "string";
                parameter.Schema.Example = new OpenApiString(_hashids.Encode(3));
                parameter.Schema.Pattern = $"[{_options.Alphabet}]{{{_options.MinHashLength}}}";
            }
        }

        foreach (var schema in context.SchemaRepository.Schemas.Values)
        {
            foreach (var property in schema.Properties)
            {
                if (hashids.TryGetValue(property.Key, out var apiParameter))
                {
                    property.Value.Format = string.Empty;
                    property.Value.Type = "string";
                    property.Value.Description = $"Hashid encoded {property.Value.Description}";
                    property.Value.Example = new OpenApiString(_hashids.Encode(100));
                    property.Value.Pattern = $"[{_options.Alphabet}]{{{_options.MinHashLength}}}";
                }
            }
        }
    }
}
