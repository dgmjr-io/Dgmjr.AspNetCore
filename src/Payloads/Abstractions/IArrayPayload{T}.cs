/*
 * IArrayPayload copy.cs
 *
 *   Created: 2022-11-26-04:40:58
 *   Modified: 2022-11-26-04:40:58
 *
 *   Author: David G. Moore, Jr, <david@dgmjr.io>
 *
 *   Copyright © 2022-2023 David G. Moore, Jr,, All Rights Reserved
 *      License: MIT (https://opensource.org/licenses/MIT)
 */

namespace Dgmjr.Payloads.Abstractions;

/// <summary>Represents a payload with an array of values</summary>
/// <typeparam name="T">The type of the values in the array</typeparam>
/// <remarks>
///  <see cref="IArrayPayload{T}"/> is a <see cref="IPayload{Array{T}}"/> with an array of values.
/// </remarks>
/// <example>
///  <code>
///  var payload = new ArrayPayload&lt;int&gt;();
///  payload.Values = new int[] { 1, 2, 3 };
///  payload.Count = 3;
/// </code>
/// </example>
public interface IArrayPayload<T> : IPayload<T[]>
{
    /// <summary>The array of values</summary>
    /// <remarks>Defaults to <see langword="null"/></remarks>
    /// <default>null</default>
    /// <example>[1, 2, 3]</example>
    T[]? Values { get; init; }

    /// <summary>The number of values in the array</summary>
    /// <example>3</example>
    /// <default>0</default>
    int Count { get; }
}
