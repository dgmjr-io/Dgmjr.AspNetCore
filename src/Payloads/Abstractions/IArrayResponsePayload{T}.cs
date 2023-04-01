/*
 * IArrayResponsePayload{T}.cs
 *
 *   Created: 2022-11-26-04:51:36
 *   Modified: 2022-11-26-04:52:00
 *
 *   Author: David G. Moore, Jr, <david@dgmjr.io>
 *
 *   Copyright © 2022-2023 David G. Moore, Jr,, All Rights Reserved
 *      License: MIT (https://opensource.org/licenses/MIT)
 */

namespace Dgmjr.Payloads.Abstractions;

/// <summary>Represents a response payload with an array of values</summary>
/// <remarks>
///   <para>
///    <see cref="IArrayResponsePayload{T}"/> is a <see cref="IResponsePayload{T[]}"/> with an array of values.
///  </para>
///   <para>
///    <see cref="ArrayResponsePayload{T}"/> is a <see cref="ResponsePayload{T[]}"/> with an array of values.
///  </para>
/// </remarks>
/// <example>
/// <code>
/// var payload = new ArrayResponsePayload&lt;int&gt;(new[] { 1,2,3,4,5 });
/// </code>
/// </example>
/// <typeparam name="T">The type of the values in the array</typeparam>
/// <seealso cref="IArrayPayload{T}"/>
/// <seealso cref="IResponsePayload{T[]}"/>
public interface IArrayResponsePayload<T> : IResponsePayload<T[]>, IArrayPayload<T> { }
