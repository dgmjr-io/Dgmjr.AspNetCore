/*
 * AddSwaggerSchemasViaAttribute.cs
 *
 *   Created: 2022-12-21-08:01:55
 *   Modified: 2022-12-21-08:01:55
 *
 *   Author: David G. Moore, Jr, <david@dgmjr.io>
 *
 *   Copyright © 2022-2023 David G. Moore, Jr,, All Rights Reserved
 *      License: MIT (https://opensource.org/licenses/MIT)
 */

using Microsoft.AspNetCore.Builder;

namespace Microsoft.Extensions.DependencyInjection;

public static class AddSwaggerSchemasViaAttributeExtension
{
    public static WebApplicationBuilder DescribeSchemasViaAttributes(
        this WebApplicationBuilder builder
    )
    {
        builder.Services.DescribeSchemasViaAttributes();
        return builder;
    }

    public static IServiceCollection DescribeSchemasViaAttributes(this IServiceCollection services)
    {
        services.AddSwaggerGen(
            c => c.SchemaFilter<Dgmjr.AspNetCore.Swagger.DescribeSchemasViaAttributesFilter>()
        );
        return services;
    }
}
