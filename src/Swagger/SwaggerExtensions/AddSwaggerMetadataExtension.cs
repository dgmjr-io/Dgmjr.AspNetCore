/*
 * AddSwaggerGenExtension.cs
 *
 *   Created: 2022-12-05-07:35:08
 *   Modified: 2022-12-05-07:35:08
 *
 *   Author: David G. Moore, Jr, <david@dgmjr.io>
 *
 *   Copyright © 2022-2023 David G. Moore, Jr,, All Rights Reserved
 *      License: MIT (https://opensource.org/licenses/MIT)
 */
#pragma warning disable
namespace Microsoft.Extensions.DependencyInjection;

using System;
using System.Linq;

// using Dgmjr.AspNetCore.Authentication;

using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Microsoft.Extensions.Configuration;

using Swashbuckle.AspNetCore.Filters;
using Swashbuckle.AspNetCore.Swagger;

using static System.String;
using static ThisAssembly.Project;

public static partial class SwaggerExtensions
{
    private static IHostApplicationBuilder AddSwaggerMetadata(
        this IHostApplicationBuilder builder,
        Type tThisAssemblyProject,
        string version = "v1",
        OpenApiInfo? openApiInfo = default
    )
    {
        openApiInfo ??= DefaultOpenApiInfo(tThisAssemblyProject.Assembly);
        openApiInfo.Version ??= version;
        if (!openApiInfo.Version.StartsWith("v"))
            openApiInfo.Version = "v" + openApiInfo.Version;

        builder.Services.ConfigureSwaggerGen(c =>
        {
            c.CustomSchemaIds(type => type.ToString());
            c.SchemaFilter<EnumsAsStringsSchemaFilter>();
            c.DocumentFilter<Dgmjr.AspNetCore.Swagger.PathLowercaseDocumentFilter>();
            c.SwaggerDoc("v1", openApiInfo);
            c.SwaggerDoc(openApiInfo.Version, openApiInfo);
        });

        return builder;
    }

    private static IHostApplicationBuilder AddApiKeyToSwaggerSecurity(
        this IHostApplicationBuilder builder
    )
    {
        builder.Services.ConfigureSwaggerGen(c =>
        {
            // c.OperationFilter<AuthorizationHeaderParameterOperationFilter>();
            c.AddSecurityDefinition(
                "Api-Key",
                new OpenApiSecurityScheme
                {
                    Description = "API Key Authorization", // Description of the API key
                    Name = "Api-Key", //
                    In = ParameterLocation.Header, // Where the API key is located
                    Type = SecuritySchemeType.ApiKey, // Type of the API key
                    Scheme = "Api-Key" //
                }
            );
        });
        return builder;
    }

    private static IHostApplicationBuilder DescribeBasicApiAuthentication(
        this IHostApplicationBuilder builder
    )
    {
        builder.Services.ConfigureSwaggerGen(c =>
        {
            c.AddSecurityDefinition(
                "Basic",
                new OpenApiSecurityScheme
                {
                    Description = "Basic", // Description of the API key
                    Name = "Authorization", //
                    In = ParameterLocation.Header, // Where the API key is located
                    Type = SecuritySchemeType.Http, // Type of the API key
                    Scheme = "Basic" //
                }
            );
            c.AddSecurityRequirement(
                new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Basic"
                            }
                        },
                        new List<string>()
                    },
                }
            );
        });
        return builder;
    }

    private static IHostApplicationBuilder AddSwaggerHeaderOperationFilter(
        this IHostApplicationBuilder builder
    )
    {
        builder.Services.ConfigureSwaggerGen(
            c =>
                c.OperationFilter<AddHeaderOperationFilter>(
                    "Range",
                    "Requested range of values to return",
                    false
                )
        );
        return builder;
    }

    private static IHostApplicationBuilder DescribeDataTypesToSwagger(
        this IHostApplicationBuilder builder
    )
    {
        builder.Services.Describe<uri>();
        builder.Services.Describe<ObjectId>();
        builder.Services.Describe<System.Domain.PhoneNumber>();
        builder.Services.Describe<System.Net.Mail.EmailAddress>();
        builder.Services.DescribeBotApiToken();
        // builder.Services.Describe<Dgmjr.Payloads.Range>();
        return builder;
    }

    private static OpenApiInfo DefaultOpenApiInfo(Assembly thisAssembly)
    {
        var thisAssemblyProject = TThisAssemblyStaticProxy.From(thisAssembly);
        var versionString = thisAssemblyProject.ApiVersion;

        var packageTags = new OpenApiArray();
        packageTags.AddRange(
            thisAssemblyProject.PackageTags?.Split(" ").Select(tag => new OpenApiString(tag))
                ?? Array.Empty<OpenApiString>()
        );

        return new()
        {
            Title = thisAssemblyProject.Title,
            Version = versionString,
            Description = thisAssemblyProject.Description,
            TermsOfService = thisAssemblyProject.TermsOfServiceUrl,
            Extensions =
            {
                ["x-project-url"] = new OpenApiString(thisAssemblyProject.PackageProjectUrl),
                ["x-repository-url"] = new OpenApiString(thisAssemblyProject.RepositoryUrl),
                ["x-package-tags"] = packageTags
            },
            Contact = new()
            {
                Name = thisAssemblyProject.Company,
                Email = thisAssemblyProject.ContactEmail,
                Url = thisAssemblyProject.PackageProjectUrl,
                Extensions =
                {
                    ["x-authors"] = new OpenApiString(thisAssemblyProject.Authors),
                    ["x-owners"] = new OpenApiString(thisAssemblyProject.Owners)
                }
            },
            License = new()
            {
                Name = thisAssemblyProject.LicenseExpression,
                Url = thisAssemblyProject.LicenseUrl
            }
        };
    }
}
