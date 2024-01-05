namespace Microsoft.Extensions.DependencyInjection;

using System;
using System.Linq;
using static System.String;

using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;

using Swashbuckle.AspNetCore.Filters;
using Swashbuckle.AspNetCore.Swagger;

using static ThisAssembly.Project;
using Dgmjr.AspNetCore.Swagger;

public static partial class SwaggerExtensions
{
    const string Swagger = nameof(Swagger);

    public static IHostApplicationBuilder AddSwaggerGen(this IHostApplicationBuilder builder)
    {
        builder.Services.AddEndpointsApiExplorer();
        var options = builder.Configuration
            .GetRequiredSection(nameof(OpenApiInfo))
            .Get<OpenApiInfo>()!;
        builder.Services.AddSwaggerGen(c =>
        {
            builder.Configuration.GetSection(Swagger).Bind(c);
            c.CustomSchemaIds(type => $"{type.Namespace}.{type.GetDisplayName()}");
            c.AddAuthorizeSummary();
            c.DocumentFilter<PathLowercaseDocumentFilter>();
        });
        builder.AddSwaggerExamples();
        builder.AddXmlCommentsToSwagger();
        builder.AddSwaggerHeaderOperationFilter();
        builder.DescribeSchemasViaAttributes();
        builder.DescribeTypesForAllOutputFormatters();
        return builder;
    }
}
