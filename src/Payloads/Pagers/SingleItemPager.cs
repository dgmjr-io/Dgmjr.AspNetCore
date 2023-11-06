/*
 * SingleItemPager.cs
 *
 *   Created: 2022-11-20-07:14:18
 *   Modified: 2022-12-18-11:43:06
 *
 *   Author: David G. Moore, Jr, <david@dgmjr.io>
 *
 *   Copyright © 2022-2023 David G. Moore, Jr,, All Rights Reserved
 *      License: MIT (https://opensource.org/licenses/MIT)
 */

namespace Dgmjr.Payloads;

using System.Diagnostics;
using System.Net;

/// <summary><inheritdoc cref="ISingleItemPager"/> </summary>
/// <remarks>Items are of type <see langword="object" />.</remarks>
[DebuggerDisplay(
    $"{{{nameof(StringValue)}}}, {nameof(Page)}: {{{nameof(Page)}}} of {{{nameof(TotalRecords)}}}"
)]
public class SingleItemPager(object? value, int pageNumber, int totalRecords)
    : SingleItemPager<object>(value, pageNumber, totalRecords)
{
    public SingleItemPager()
        : this(default, 0, 0) { }

public static new SingleItemPager NotFound() =>
    new() { StatusCode = (int)HttpStatusCode.NotFound };

public static new SingleItemPager BadRequest() =>
    new() { StatusCode = (int)HttpStatusCode.BadRequest };

public static new SingleItemPager NoContent() =>
    new() { StatusCode = (int)HttpStatusCode.NoContent };
}
