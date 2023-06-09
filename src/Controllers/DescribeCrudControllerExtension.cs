﻿/*
* DescribeCrudControllerExtension.cs
*
*   Created: 2022-12-17-03:32:11
*   Modified: 2022-12-17-03:32:11
*
*   Author: David G. Moore, Jr, <david@dgmjr.io>
*
*   Copyright © 2022-2023 David G. Moore, Jr,, All Rights Reserved
*      License: MIT (https://opensource.org/licenses/MIT)
*/

namespace Microsoft.Extensions.DependencyInjection;

using System.Net.Mime.MediaTypes;
using Dgmjr.AspNetCore.Controllers;
using Dgmjr.Payloads;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using static Microsoft.AspNetCore.Http.StatusCodes;

public static class DescribeCrudControllerExtension
{
    public static WebApplicationBuilder DescribeCrudController(this WebApplicationBuilder builder)
    {
        builder.Services.ConfigureSwaggerGen(
            options => options.OperationFilter<CrudControllerOperationFilter>()
        );
        return builder;
    }
}

public class CrudControllerOperationFilter : IOperationFilter
{
    public void Apply(OpenApiOperation operation, OperationFilterContext context)
    {
        var crudControllerType = context.MethodInfo.DeclaringType;
        if (IsCrudController(crudControllerType))
        {
            var crudControllerModelType = GetCrudControllerModelType(crudControllerType);
            var crudControllerIdType = GetCrudControllerIdType(crudControllerType);
            var pagerType = typeof(Pager<>).MakeGenericType(crudControllerModelType);
            var singleItemPagerType = typeof(SingleItemPager<>).MakeGenericType(
                crudControllerModelType
            );
            var pagerPatchType = typeof(Pager<>).MakeGenericType(
                typeof(JsonPatchDocument<>).MakeGenericType(crudControllerModelType)
            );
            var pagerOpenApiSchema =
                pagerType.GetMethod("GetOpenApiSchema")?.Invoke(null, null) as OpenApiSchema;
            var singleItemPagerOpenApiSchema =
                pagerType.GetMethod("GetOpenApiSchema")?.Invoke(null, null) as OpenApiSchema;
            // operation.Responses.Add("200", new OpenApiResponse { Description = "Success", Content = { { ApplicationMediaTypeNames.Json, new OpenApiMediaType { Schema = new OpenApiSchema { Type = "object" } } } } });
            // operation.Responses.Add("400", new OpenApiResponse { Description = "Bad Request", Content = { { ApplicationMediaTypeNames.Json, new OpenApiMediaType { Schema = new OpenApiSchema { Type = "object" } } } } });
            operation.Responses.Add(
                Status401Unauthorized.ToString(),
                new OpenApiResponse { Description = "Unauthorized" }
            );
            operation.Responses.Add(
                Status404NotFound.ToString(),
                new OpenApiResponse { Description = "Not Found" }
            );

            switch (context.MethodInfo.Name)
            {
                case Post:
                    operation.RequestBody = new OpenApiRequestBody
                    {
                        Content =
                        {
                            [ApplicationMediaTypeNames.Json] = new OpenApiMediaType
                            {
                                Schema = new OpenApiSchema
                                {
                                    Reference = new OpenApiReference
                                    {
                                        Id = crudControllerModelType.Name,
                                        Type = ReferenceType.Schema
                                    }
                                }
                            },
                            [ApplicationMediaTypeNames.Xml] = new OpenApiMediaType
                            {
                                Schema = new OpenApiSchema
                                {
                                    Reference = new OpenApiReference
                                    {
                                        Id = crudControllerModelType.Name,
                                        Type = ReferenceType.Schema
                                    }
                                }
                            },
                            [TextMediaTypeNames.Plain] = new OpenApiMediaType
                            {
                                Schema = new OpenApiSchema { Type = "string" }
                            }
                        }
                    };
                    break;
                case Put:
                    operation.RequestBody = new OpenApiRequestBody
                    {
                        Content =
                        {
                            [ApplicationMediaTypeNames.Json] = new OpenApiMediaType
                            {
                                Schema = new OpenApiSchema
                                {
                                    Reference = new OpenApiReference
                                    {
                                        Id = crudControllerModelType.Name,
                                        Type = ReferenceType.Schema
                                    }
                                }
                            },
                            [ApplicationMediaTypeNames.Xml] = new OpenApiMediaType
                            {
                                Schema = new OpenApiSchema
                                {
                                    Reference = new OpenApiReference
                                    {
                                        Id = crudControllerModelType.Name,
                                        Type = ReferenceType.Schema
                                    }
                                }
                            },
                            [TextMediaTypeNames.Plain] = new OpenApiMediaType
                            {
                                Schema = new OpenApiSchema { Type = "string" }
                            }
                        }
                    };
                    break;
                case Delete:
                    operation.RequestBody = null;
                    break;
                case Patch:
                    operation.RequestBody = new OpenApiRequestBody
                    {
                        Content =
                        {
                            [ApplicationMediaTypeNames.Json] = new OpenApiMediaType
                            {
                                Schema = new OpenApiSchema
                                {
                                    Reference = new OpenApiReference
                                    {
                                        Id = typeof(JsonPatchDocument).Name,
                                        Type = ReferenceType.Schema
                                    }
                                }
                            },
                            [ApplicationMediaTypeNames.Xml] = new OpenApiMediaType
                            {
                                Schema = new OpenApiSchema
                                {
                                    Reference = new OpenApiReference
                                    {
                                        Id = typeof(JsonPatchDocument).Name,
                                        Type = ReferenceType.Schema
                                    }
                                }
                            },
                            [TextMediaTypeNames.Plain] = new OpenApiMediaType
                            {
                                Schema = new OpenApiSchema { Type = "string" }
                            }
                        }
                    };
                    break;
                case Get:
                    operation.RequestBody = null;
                    operation.Responses.Add(
                        Status200OK.ToString(),
                        new OpenApiResponse
                        {
                            Description = "Success",
                            Content =
                            {
                                [ApplicationMediaTypeNames.Json] = new OpenApiMediaType
                                {
                                    Schema = new OpenApiSchema
                                    {
                                        Reference = new OpenApiReference
                                        {
                                            Id = crudControllerModelType.Name,
                                            Type = ReferenceType.Schema
                                        }
                                    }
                                },
                                [ApplicationMediaTypeNames.Xml] = new OpenApiMediaType
                                {
                                    Schema = new OpenApiSchema
                                    {
                                        Reference = new OpenApiReference
                                        {
                                            Id = crudControllerModelType.Name,
                                            Type = ReferenceType.Schema
                                        }
                                    }
                                },
                                [TextMediaTypeNames.Plain] = new OpenApiMediaType
                                {
                                    Schema = new OpenApiSchema { Type = "string" }
                                }
                            }
                        }
                    );
                    break;
                case Get + "All":
                    operation.RequestBody = null;
                    operation.Responses.Add(
                        Status200OK.ToString(),
                        new OpenApiResponse
                        {
                            Description = "Success",
                            Content =
                            {
                                [ApplicationMediaTypeNames.Json] = new OpenApiMediaType
                                {
                                    Schema = new OpenApiSchema
                                    {
                                        AnyOf = { pagerOpenApiSchema, singleItemPagerOpenApiSchema }
                                    }
                                },
                                [ApplicationMediaTypeNames.Xml] = new OpenApiMediaType
                                {
                                    Schema = new OpenApiSchema
                                    {
                                        AnyOf = { pagerOpenApiSchema, singleItemPagerOpenApiSchema }
                                    }
                                },
                                [TextMediaTypeNames.Plain] = new OpenApiMediaType
                                {
                                    Schema = new OpenApiSchema { Type = "string" }
                                }
                            }
                        }
                    );
                    operation.Responses.Add(
                        Status200OK.ToString(),
                        new OpenApiResponse
                        {
                            Description = "Success",
                            Content =
                            {
                                [ApplicationMediaTypeNames.Json] = new OpenApiMediaType
                                {
                                    Schema = new OpenApiSchema
                                    {
                                        AnyOf = { pagerOpenApiSchema, singleItemPagerOpenApiSchema }
                                    }
                                },
                                [ApplicationMediaTypeNames.Xml] = new OpenApiMediaType
                                {
                                    Schema = new OpenApiSchema
                                    {
                                        AnyOf = { pagerOpenApiSchema, singleItemPagerOpenApiSchema }
                                    }
                                },
                                [TextMediaTypeNames.Plain] = new OpenApiMediaType
                                {
                                    Schema = new OpenApiSchema { Type = "string" }
                                }
                            }
                        }
                    );
                    break;
            }
        }
    }

    private static type? GetCrudControllerModelType(type type)
    {
        return (
            type.IsConstructedGenericType
            && type.GetGenericTypeDefinition().Equals(typeof(CrudController<,,,,,>))
        )
            ? type.GetGenericArguments()[0]
            : type.BaseType != typeof(object)
                ? GetCrudControllerModelType(type.BaseType)
                : null;
    }

    private static type? GetCrudControllerIdType(type type)
    {
        return (
            type.IsConstructedGenericType
            && type.GetGenericTypeDefinition().Equals(typeof(CrudController<,,,,,>))
        )
            ? type.GetGenericArguments()[3]
            : type.BaseType != typeof(object)
                ? GetCrudControllerModelType(type.BaseType)
                : null;
    }

    private static bool IsCrudController(type type)
    {
        return (
                (
                    type.IsConstructedGenericType
                    && type.GetGenericTypeDefinition().Equals(typeof(CrudController<,,,,,>))
                )
                || type.BaseType != typeof(object)
            ) && IsCrudController(type.BaseType);
    }
}
