namespace Microsoft.Extensions.DependencyInjection;

using Microsoft.AspNetCore.Builder;

internal static partial class InternalSwaggerExtensions
{
    public static WebApplicationBuilder DescribeEnumsAsStrings(this WebApplicationBuilder builder)
    {
        builder.Services.ConfigureSwaggerGen(c => c.SchemaFilter<EnumsAsStringsSchemaFilter>());
        return builder;
    }
}
