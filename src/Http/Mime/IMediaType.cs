/*
 * MimeMediaType.cs
 *
 *   Created: 2023-01-06-06:35:11
 *   Modified: 2023-01-06-06:35:11
 *
 *   Author: David G. Moore, Jr, <david@dgmjr.io>
 *
 *   Copyright © 2022-2023 David G. Moore, Jr,, All Rights Reserved
 *      License: MIT (https://opensource.org/licenses/MIT)
 */

namespace Dgmjr.Mime.Abstractions;

using System.Linq;
using System.Runtime.InteropServices;

using Microsoft.AspNetCore.Mvc.Formatters;

[System.Text.Json.Serialization.JsonConverter(typeof(IMediaTypeJsonConverter))]
public interface IMediaType
    : IHaveAName,
        IHaveADescription,
        IHaveAUri,
        IHaveAUriString,
        IHaveSynonyms,
        IHaveAShortName,
        IHaveAGuid,
        IHaveAGuidString,
        IHaveADisplayName,
        IIdentifiable,
        IIdentifiable<int>
{
    /// <summary>
    /// Returns a that represents this instance. The format of the returned string is the same as that used by ToString ().
    /// </summary>
    /// <returns>A that represents this instance and can be parsed by System. String. Format () or null if this instance is null</returns>
    string ToString();
}

public static class MediTypeExtensions { }
