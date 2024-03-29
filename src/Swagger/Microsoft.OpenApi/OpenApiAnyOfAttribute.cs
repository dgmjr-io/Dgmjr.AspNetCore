﻿/*
 * OpenApiEnumAttribute.cs
 *
 *   Created: 2022-12-21-08:46:55
 *   Modified: 2022-12-21-08:46:57
 *
 *   Author: David G. Moore, Jr, <david@dgmjr.io>
 *
 *   Copyright © 2022-2023 David G. Moore, Jr,, All Rights Reserved
 *      License: MIT (https://opensource.org/licenses/MIT)
 */

using System.Linq;

using Microsoft.OpenApi.Any;

namespace Microsoft.OpenApi.Attributes;

public class OpenApiEnumAttribute : OpenApiSchemaAttribute
{
    public OpenApiEnumAttribute(params object[] anyOf)
        : this(anyOf.AsEnumerable()) { }

    public OpenApiEnumAttribute(IEnumerable<object> anyOf)
    {
        Enum = anyOf
            .Select(anyOfItem => new OpenApiString(anyOfItem?.ToString()))
            .OfType<IOpenApiAny>()
            .ToList();
    }
}
