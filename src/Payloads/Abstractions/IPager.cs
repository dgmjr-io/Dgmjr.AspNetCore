/*
 * IPager.cs
 *
 *   Created: 2022-11-26-05:15:42
 *   Modified: 2022-11-26-05:15:42
 *
 *   Author: David G. Moore, Jr, <david@dgmjr.io>
 *
 *   Copyright © 2022-2023 David G. Moore, Jr,, All Rights Reserved
 *      License: MIT (https://opensource.org/licenses/MIT)
 */

namespace Dgmjr.Payloads.Abstractions;

/// <summary>Represents a response payload that supports paging</summary>
public interface IPager : IResponsePayload
{
    /// <summary>The array of items in the current page</summary>
    /// <remarks>Defaults to <see langword="null"/></remarks>
    /// <example>[1, 2, 3]</example>
    /// <default>null</default>
    [JProp("items")]
    object[]? Items { get; init; }

    /// <summary>The total number of records in the entire resultset</summary>
    int TotalRecords { get; init; }

    /// <summary>The size of the page, i.e., the maximum number of records in the page</summary>
    int PageSize { get; init; }

    /// <summary>The 1-based index of the current page</summary>
    int Page { get; init; }

    /// <summary>The 0-based index of the first record in the current page</summary>
    int PageStartIndex { get; }

    /// <summary>The 0-based index of the last record in the current page</summary>
    int PageEndIndex { get; }

    /// <summary>The total number of pages in the resultset</summary>
    int TotalPages { get; }

    /// <summary>Whether the current page is the first page in the resultset</summary>
    /// <value><see langword="true"/> if the current page is the first page in the resultset; otherwise, <see langword="false"/></value>
    bool IsLastPage { get; }

    /// <summary>Whether the current page is the last page in the resultset</summary>
    /// <value><see langword="true"/> if the current page is the last page in the resultset; otherwise, <see langword="false"/></value>
    bool HasPreviousPage { get; }

    /// <summary>Whether the current page has a previous page</summary>
    /// <value><see langword="true"/> if the current page has a next page; otherwise, <see langword="false"/></value>
    bool HasNextPage { get; }
}
