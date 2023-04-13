/*
 * OpenApiAnyOfAttribute.cs
 *
 *   Created: 2022-12-21-08:46:55
 *   Modified: 2022-12-21-08:46:57
 *
 *   Author: David G. Moore, Jr, <david@dgmjr.io>
 *
 *   Copyright © 2022-2023 David G. Moore, Jr,, All Rights Reserved
 *      License: MIT (https://opensource.org/licenses/MIT)
 */

using Microsoft.OpenApi.Any;

namespace Microsoft.OpenApi.Attributes;

public class OpenApiAnyOfAttribute : OpenApiSchemaAttribute
{
    public OpenApiAnyOfAttribute(params object[] anyOf) : this(anyOf as IEnumerable<object>) { }

    public OpenApiAnyOfAttribute(IEnumerable<object> anyOf)
    {
        Enum = anyOf
            .Select(anyOfItem => new OpenApiString(anyOfItem?.ToString()))
            .OfType<IOpenApiAny>()
            .ToList();
    }
}
