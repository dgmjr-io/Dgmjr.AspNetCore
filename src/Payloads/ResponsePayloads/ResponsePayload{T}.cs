/*
 * ResponsePayload.cs
 *
 *   Created: 2022-11-20-07:14:18
 *   Modified: 2022-11-29-05:25:05
 *
 *   Author: David G. Moore, Jr, <david@dgmjr.io>
 *
 *   Copyright © 2022-2023 David G. Moore, Jr,, All Rights Reserved
 *      License: MIT (https://opensource.org/licenses/MIT)
 */

namespace Dgmjr.Payloads;

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Net.Mime.MediaTypes;
using System.Threading.Tasks;
using System.Xml.Serialization;

using Dgmjr.Payloads.Abstractions;
using Dgmjr.Payloads.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;

/// <inheritdoc cref="IResponsePayload{T}"/>
[DebuggerDisplay($"{{{nameof(StringValue)}}}")]
// [SwaggerSubType(typeof(ResponsePayload))]
public class ResponsePayload<T> : Payload<T>, IResponsePayload<T>, IPayload
{
    public ResponsePayload()
        : this(default, default) { }

    public ResponsePayload(
        T? value,
        string? stringValue = default,
        string? message = default,
        HttpStatusCode statusCode = HttpStatusCode.OK
    )
        : base(value, stringValue)
    {
        Message = message ?? string.Empty;
        StatusCode = (int)statusCode;
        ContentTypes.Add(new(ApplicationMediaTypeNames.Json));
        ContentTypes.Add(new(ApplicationMediaTypeNames.Xml));
        ContentTypes.Add(new(ApplicationMediaTypeNames.MessagePack));
        ContentTypes.Add(new(ApplicationMediaTypeNames.Bson));
        ContentTypes.Add(new(TextMediaTypeNames.Plain));
    }

    /// <inheritdoc />
    [JProp("isSuccess"), XmlAttribute("isSuccess")]
    public virtual bool IsSuccess => StatusCode!.Value >= 200 && StatusCode!.Value <= 299; //IsBetween(200, 299);

    [XmlAttribute("message"), JProp("message"), JIgnore(Condition = JIgnore.WhenWritingNull)]
    public virtual string Message { get; set; }

    /// <inheritdoc />
    [JIgnore, XmlIgnore]
    public virtual int? StatusCode { get; set; }

    /// <inheritdoc />
    [JIgnore, XmlIgnore]
    T? IPayload<T>.Value { get; set; }

    /// <inheritdoc />
    [JIgnore, XmlIgnore]
    object? IPayload.Value
    {
        get => Value;
        set => Value = value is T t ? t : default;
    }

    [JIgnore, XmlIgnore]
    public ICollection<IOutputFormatter> OutputFormatters { get; } = new List<IOutputFormatter>();

    [JIgnore, XmlIgnore]
    public MediaTypeCollection ContentTypes { get; } = new MediaTypeCollection();

    [JIgnore, XmlIgnore]
    HttpStatusCode? IResponsePayload.StatusCode =>
        StatusCode.HasValue ? (HttpStatusCode)StatusCode.Value : default;

    public static implicit operator ResponsePayload<T>(T value)
    {
        return new ResponsePayload<T>(value);
    }

    public static implicit operator T?(ResponsePayload<T> payload)
    {
        return payload.Value;
    }

    public virtual Task ExecuteResultAsync(ActionContext context)
    {
        var services = context.HttpContext.RequestServices;
        var executor =
            services.GetService<IActionResultExecutor<IResponsePayload<T>>>()
            ?? new ResponsePayloadExecutor<T>(
                services.GetService<OutputFormatterSelector>(),
                services.GetRequiredService<ILogger<ResponsePayloadExecutor<T>>>(),
                services.GetService<IOptions<MvcOptions>>()
            );
        return executor.ExecuteAsync(context, this);
    }

    public void OnFormatting(OutputFormatterWriteContext context)
    {
        if (context.Object is IResponsePayload payload)
        {
            context.HttpContext.Response.StatusCode = Value is null
                ? (int)HttpStatusCode.NoContent
                : (int?)payload.StatusCode ?? (int)HttpStatusCode.OK;
        }
    }

    public static OpenApiSchema GetOpenApiSchema()
    {
        var schema = new OpenApiSchema
        {
            Type = "object",
            Properties =
            {
                [nameof(IResponsePayload.Value).ToLower()] = new OpenApiSchema
                {
                    Reference = new OpenApiReference
                    {
                        Id = typeof(T).Name,
                        Type = ReferenceType.Schema
                    }
                },
                [nameof(IResponsePayload.Message).ToLower()] = new OpenApiSchema
                {
                    Type = "string"
                } /*,
                [nameof(IResponsePayload.StatusCode)] = new OpenApiSchema { Type = "integer", Format = "int32" },*/
            },
            Required = { nameof(IResponsePayload.Value).ToLower() }
        };
        return schema;
    }

    public static ResponsePayload<T> NotFound(string? message = "Not found") =>
        new() { Message = message, StatusCode = (int)HttpStatusCode.NotFound };

    public static ResponsePayload<T> BadRequest(string? message = "Bad request") =>
        new() { Message = message, StatusCode = (int)HttpStatusCode.BadRequest };

    public static ResponsePayload<T> NoContent(string? message = "No content") =>
        new() { Message = message, StatusCode = (int)HttpStatusCode.NoContent };

    public static ResponsePayload<T> Unauthorized(string? message = "Unauthorized") =>
        new() { Message = message, StatusCode = (int)HttpStatusCode.Unauthorized };

    public static ResponsePayload<T> Forbidden(string? message = "Forbidden") =>
        new() { Message = message, StatusCode = (int)HttpStatusCode.Forbidden };

    public static ResponsePayload<T> InternalServerError(
        string? message = "Internal server error"
    ) => Problem(message, HttpStatusCode.InternalServerError);

    public static ResponsePayload<T> Problem(
        string? message = "Problem",
        HttpStatusCode statusCode = HttpStatusCode.InternalServerError
    ) => new() { Message = message, StatusCode = (int)statusCode };

    public static ResponsePayload<T> Created(
        T value,
        string? messaage = "Created at {0}",
        uri? location = default
    ) =>
        new CreatedResponsePayload<T>(value, location)
        {
            Message = Format(messaage ?? string.Empty, location)
        };
}
