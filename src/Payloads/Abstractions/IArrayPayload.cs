/*
 * IPayload copy.cs
 *
 *   Created: 2022-11-26-04:39:55
 *   Modified: 2022-11-26-04:39:55
 *
 *   Author: David G. Moore, Jr, <david@dgmjr.io>
 *
 *   Copyright © 2022-2023 David G. Moore, Jr,, All Rights Reserved
 *      License: MIT (https://opensource.org/licenses/MIT)
 */

namespace Dgmjr.Payloads.Abstractions;

/// <inheritdoc cref="IArrayPayload{Object}"/>
public interface IArrayPayload : IArrayPayload<object>, IPayload<object[]> { }
