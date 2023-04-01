/*
 * ISingleItemPager.cs
 *
 *   Created: 2022-11-26-05:18:42
 *   Modified: 2022-11-26-05:18:43
 *
 *   Author: David G. Moore, Jr, <david@dgmjr.io>
 *
 *   Copyright © 2022-2023 David G. Moore, Jr,, All Rights Reserved
 *      License: MIT (https://opensource.org/licenses/MIT)
 */


namespace Dgmjr.Payloads.Abstractions;

/// <summary>Represents a single-item pager (i.e., one item per page).</summary>
public interface ISingleItemPager : ISingleItemPager<object>, IPayload<object> { }
