/*
 * IPayload{T}.cs
 *
 *   Created: 2022-11-26-04:22:55
 *   Modified: 2022-11-26-04:22:56
 *
 *   Author: David G. Moore, Jr, <david@dgmjr.io>
 *
 *   Copyright © 2022-2023 David G. Moore, Jr,, All Rights Reserved
 *      License: MIT (https://opensource.org/licenses/MIT)
 */
namespace Dgmjr.Payloads.Abstractions;

/// <summary>Represents <inheritdoc cref="IPayload{T}" path="/value" />.</summary>
/// <value>a strongly-typed payload of type <typeparamref name="T" /></value>
public interface IPayload<T> : IPayload
{
    /// <summary>The strongly-typed value of the payload</summary>
    /// <remarks>Defaults to <see langword="null"/></remarks>
    /// <example>5</example>
    /// <example>0</example>
    /// <example>Hello, world!</example>
    new T? Value { get; set; }
}
