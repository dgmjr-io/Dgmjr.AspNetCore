/*
 * HashidsAttribute.cs
 *
 *   Created: 2022-12-20-05:18:39
 *   Modified: 2022-12-20-05:18:39
 *
 *   Author: David G. Moore, Jr, <david@dgmjr.io>
 *
 *   Copyright © 2022-2023 David G. Moore, Jr,, All Rights Reserved
 *      License: MIT (https://opensource.org/licenses/MIT)
 */

namespace System.Text.Json;

[AttributeUsage(
    AttributeTargets.Property | AttributeTargets.Field,
    AllowMultiple = false,
    Inherited = true
)]
public sealed partial class HashidsAttribute : System.Text.Json.Serialization.JsonConverterAttribute
{
    public HashidsAttribute()
        : base(typeof(global::AspNetCore.Hashids.Json.HashidsJsonConverter)) { }
}
