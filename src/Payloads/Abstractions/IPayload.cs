/*
 * IPayload.cs
 *
 *   Created: 2022-11-26-04:22:22
 *   Modified: 2022-11-26-04:22:23
 *
 *   Author: David G. Moore, Jr, <david@dgmjr.io>
 *
 *   Copyright © 2022-2023 David G. Moore, Jr,, All Rights Reserved
 *      License: MIT (https://opensource.org/licenses/MIT)
 */
namespace Dgmjr.Payloads.Abstractions;

/// <summary>Represents an object or scalar valued payload</summary>
public interface IPayload
{
    /// <summary>The value of the payload</summary>
    /// <remarks>Defaults to <see langword="null"/></remarks>
    /// <default>null</default>
    /// <example>5</example>
    /// <example>0</example>
    /// <example>Hello, world!</example>
    object? Value { get; init; }

    /// <summary>The value of the payload as a string</summary>
    /// <remarks>Defaults to <see langword="null"/></remarks>
    /// <default>null</default>
    /// <example>"5"</example>
    /// <example>"0"</example>
    /// <example>"Hello, world!"</example>
    string? StringValue { get; init; }
}
