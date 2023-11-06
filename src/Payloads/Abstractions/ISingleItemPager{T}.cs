/*
 * ISingleItemPager{T}.cs
 *
 *   Created: 2022-11-29-05:22:42
 *   Modified: 2022-11-29-05:23:38
 *
 *   Author: David G. Moore, Jr, <david@dgmjr.io>
 *
 *   Copyright © 2022-2023 David G. Moore, Jr,, All Rights Reserved
 *      License: MIT (https://opensource.org/licenses/MIT)
 */

namespace Dgmjr.Payloads.Abstractions;

/// <summary>Represents a strongly-typed single-item pager (i.e., one item per page) of items of type <typeparamref name="T"/>.</summary>
public interface ISingleItemPager<T> : IResponsePayload<T>
{
    [JProp("item")]
    T? Item { get; init; }

    [JProp("totalRecords")]
    int TotalRecords { get; init; }
    int PageSize { get; init; }
    int Page { get; init; }
    int PageStartIndex { get; }
    int PageEndIndex { get; }
    int TotalPages { get; }
    bool IsLastPage { get; }
    bool HasPreviousPage { get; }
    bool HasNextPage { get; }
}
