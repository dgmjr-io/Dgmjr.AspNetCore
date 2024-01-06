namespace Microsoft.Extensions.DependencyInjection;

public static partial class SwaggerExtensions
{
    internal static IHostApplicationBuilder DescribeEnumsAsStrings(this IHostApplicationBuilder builder)
    {
        builder.Services.ConfigureSwaggerGen(c => c.SchemaFilter<EnumsAsStringsSchemaFilter>());
        return builder;
    }
}
