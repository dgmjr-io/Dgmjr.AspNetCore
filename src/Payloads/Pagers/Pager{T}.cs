/*
 * Pager{T}.cs
 *
 *   Created: 2022-11-29-08:42:16
 *   Modified: 2022-11-29-08:42:28
 *
 *   Author: David G. Moore, Jr, <david@dgmjr.io>
 *
 *   Copyright © 2022-2023 David G. Moore, Jr,, All Rights Reserved
 *      License: MIT (https://opensource.org/licenses/MIT)
 */

using System.Collections;
using System.Net;
using Microsoft.OpenApi.Models;
using static System.Net.HttpStatusCode;

namespace Dgmjr.Payloads;

/// <inheritdoc cref="Dgmjr.Payloads.Abstractions.IPager{T}"/>
[DebuggerDisplay(
    $"{{{nameof(StringValue)}}}, {nameof(Page)}: {{{nameof(Page)}}} of {{{nameof(TotalRecords)}}}"
)]
public class Pager<T> : ArrayResponsePayload<T>, IPager<T>
{
    public Pager()
        : this(default, 0, 0, 0) { }

    public Pager(
        T[]? items,
        int page,
        int pageSize,
        int totalRecords,
        string? message = default,
        string itemSeparator = ArrayPayload<T>.DefaultItemSeparator
    )
        : base(items, message: message, itemSeparator: itemSeparator)
    {
        Page = page;
        PageSize = pageSize;
        TotalRecords = totalRecords;
        Message = message ?? string.Empty;
    }

    public Pager(
        IQueryable<T>? items,
        Range ramge,
        string? message = default,
        string itemSeparator = ArrayPayload<T>.DefaultItemSeparator,
        int? statusCode = default
    )
        : base()
    {
        TotalRecords = items.Count();
        Page = ramge.PageNumber;
        PageSize = ramge.PageSize;
        Message = message ?? string.Empty;
        StatusCode = statusCode;
        Items = items.Skip(ramge.Start).Take(ramge.PageSize).ToArray();
    }

    [JProp("items")]
    public virtual T[]? Items
    {
        get => Values;
        set => Value = value;
    }

    [JIgnore]
    public override T[]? Values
    {
        get => base.Values;
        set => base.Values = value;
    }

    [JProp("totalRecords")]
    public virtual int TotalRecords { get; set; }

    [JProp("pageSize")]
    public virtual int PageSize { get; set; }

    [JProp("page")]
    public virtual int Page { get; set; }

    [JProp("startIndex")]
    public virtual int PageStartIndex => (Page - 1) * PageSize;

    [JProp("endIndex")]
    public virtual int PageEndIndex => Min(Page * PageSize, TotalRecords - 1);

    [JProp("totalPages")]
    public virtual int TotalPages => (int)Ceiling((double)TotalRecords / PageSize);

    [JProp("isLastPage")]
    public virtual bool IsLastPage => Page >= TotalPages;

    [JProp("hasPrevious")]
    public virtual bool HasPreviousPage => Page > 1;

    [JProp("hasNext")]
    public virtual bool HasNextPage => Page < TotalPages;

    HttpStatusCode? IResponsePayload.StatusCode => (HttpStatusCode?)StatusCode;

    private int? _statusCode;
    public override int? StatusCode
    {
        get =>
            _statusCode.HasValue && !(_statusCode.Value >= 200 && _statusCode.Value <= 299)
                ? _statusCode.Value
                : HasNextPage || Page > 1
                    ? (int)PartialContent
                    : (int)OK;
        set => _statusCode = value;
    }

    object? IPayload.Value
    {
        get => Value;
        set => Items = (value as IEnumerable ?? Empty<object>())?.OfType<T>().ToArray();
    }
    object[]? IPager.Items
    {
        get => Items.OfType<object>().ToArray();
        set => Items = value.OfType<T>().ToArray();
    }

    public static implicit operator Pager<T>(T[]? items) =>
        new(items, 1, items.Length, items.Length);

    public static implicit operator T[]?(Pager<T> pager) => pager.Items;

    public static new OpenApiSchema GetOpenApiSchema()
    {
        var schema = ArrayResponsePayload<T>.GetOpenApiSchema();
        schema.Properties.Add("page", new OpenApiSchema { Type = "integer", Format = "int32" });
        schema.Properties.Add("pageSize", new OpenApiSchema { Type = "integer", Format = "int32" });
        schema.Properties.Add(
            "totalRecords",
            new OpenApiSchema { Type = "integer", Format = "int32" }
        );
        schema.Properties.Add(
            "items",
            new OpenApiSchema
            {
                Type = "array",
                Items = new OpenApiSchema
                {
                    Reference = new OpenApiReference
                    {
                        Id = typeof(T).Name,
                        Type = ReferenceType.Schema
                    }
                }
            }
        );
        return schema;
    }

    public static Pager<T> NotFound() => new() { StatusCode = (int)HttpStatusCode.NotFound };

    public static Pager<T> BadRequest() => new() { StatusCode = (int)HttpStatusCode.BadRequest };

    public static Pager<T> NoContent() => new() { StatusCode = (int)HttpStatusCode.NoContent };
}
