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
using Swashbuckle.AspNetCore.SwaggerGen;

public static partial class SwaggerExtensions
{
    const string Swagger = nameof(Swagger);

    const string SwaggerUI = nameof(SwaggerUI);

    public static IHostApplicationBuilder AddSwaggerGen(this IHostApplicationBuilder builder, string configurationSectionKey = Swagger, Action<SwaggerGenOptions>? configure = default)
    {
        builder.Services.AddEndpointsApiExplorer();

        builder.Services.AddSwaggerGen(c =>
        {
            builder.Configuration.Bind(configurationSectionKey, c);
            c.CustomSchemaIds(type => $"{type.Namespace}.{type.GetDisplayName()}");
            c.AddAuthorizeSummary();
            c.DocumentFilter<PathLowercaseDocumentFilter>();
        });
        builder.AddSwaggerExamples();
        builder.AddXmlCommentsToSwagger();
        builder.AddSwaggerHeaderOperationFilter();
        builder.DescribeSchemasViaAttributes();
        builder.DescribeTypesForAllOutputFormatters();
        builder.AddSwaggerConflictingActionsResolver();
        builder.DescribeFileUploads();
        builder.DescribeEnumsAsStrings();

        builder.Services.ConfigureSwaggerGen(c => configure?.Invoke(c));

        return builder;
    }

    public static IApplicationBuilder UseCustomSwaggerUI(this IApplicationBuilder app, string configurationSectionKey = SwaggerUI)
    {
        app.InjectUICustomizations();
        app.UseSwagger();
        app.UseSwaggerUI(c =>
        {
            var config = app.ApplicationServices
                .CreateScope()
                .ServiceProvider.GetRequiredService<IConfiguration>();
            config.Bind(configurationSectionKey, c);
        });
        return app;
    }
}
