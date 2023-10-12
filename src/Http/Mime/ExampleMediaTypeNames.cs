/*
 * ExampleMediaTypeNames.cs
 *
 *   Created: 2023-01-06-07:26:23
 *   Modified: 2023-01-06-07:26:24
 *
 *   Author: David G. Moore, Jr, <david@dgmjr.io>
 *
 *   Copyright © 2022-2023 David G. Moore, Jr,, All Rights Reserved
 *      License: MIT (https://opensource.org/licenses/MIT)
 */

namespace Dgmjr.Mime;

using System.Runtime.Serialization;

public static class ExampleMediaTypeNames
{
    /// <summary>The base name for all example media types.</summary>
    /// <remarks>See <see href="https://www.iana.org/assignments/media-types/media-types.xhtml#example">IANA Media Types</see> for more information.</remarks>
    /// <value>example</value>
    public const string Base = "example";

    /// <summary>Media type for any example.</summary>
    /// <value><inheritdoc cref="Base" />/*</value>
    public const string Any = Base + "/*";

    /// <summary>Example media type.</summary>
    /// <value><inheritdoc cref="Base" />/example</value>
    /// <seealso cref="Dgmjr.Mime.Enums.ExampleMediaType"/>
    /// <seealso cref="Dgmjr.Mime.Enums.ExampleMediaType.Example"/>
    public const string Example = Base + "/" + "example";
}
