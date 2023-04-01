/*
 * IArrayResponsePayload{T} copy.cs
 *
 *   Created: 2022-11-28-09:35:32
 *   Modified: 2022-11-28-09:35:32
 *
 *   Author: David G. Moore, Jr, <david@dgmjr.io>
 *
 *   Copyright © 2022-2023 David G. Moore, Jr,, All Rights Reserved
 *      License: MIT (https://opensource.org/licenses/MIT)
 */

namespace Dgmjr.Payloads.Abstractions;

/// <summary>Represents a response payload with an array of values</summary>
/// <remarks>
///  <para>
///  <see cref="IArrayResponsePayload"/> is a <see cref="IArrayResponsePayload{Object}"/> with an array of <see langword="object" />s.
/// </para>
///  <para>
///  <see cref="ArrayResponsePayload"/> is a <see cref="ArrayResponsePayload{Object}"/> with an array of <see langword="object" />s.
/// </para>
/// </remarks>
public interface IArrayResponsePayload : IArrayResponsePayload<object> { }
