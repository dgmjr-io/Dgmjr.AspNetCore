namespace Microsoft.Extensions.DependencyInjection;

internal static partial class InternalSwaggerExtensions
{
    public static IHostApplicationBuilder DescribeEnumsAsStrings(this IHostApplicationBuilder builder)
    {
        builder.Services.ConfigureSwaggerGen(c => c.SchemaFilter<EnumsAsStringsSchemaFilter>());
        return builder;
    }
}
