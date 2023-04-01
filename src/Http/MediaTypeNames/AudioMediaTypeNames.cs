/*
 * AudioMediaTypeNames.cs
 *
 *   Created: 2022-12-31-01:11:28
 *   Modified: 2022-12-31-01:11:28
 *
 *   Author: David G. Moore, Jr, <david@dgmjr.io>
 *
 *   Copyright © 2022-2023 David G. Moore, Jr,, All Rights Reserved
 *      License: MIT (https://opensource.org/licenses/MIT)
 */

namespace System.Net.Mime.MediaTypes;

using System.Runtime.Serialization;

public static class AudioMediaTypeNames
{
    public const string Base = "audio/";
    public const string Any = Base + "*";
    public const string Vorbis = Base + "vorbis";
    public const string Ogg = Base + "ogg";
    public const string Mp3 = Base + "mpeg";
    public const string Mp4 = Base + "mp4";
    public const string Mpeg = Base + "mpeg";
    public const string Mpeg4 = Base + "mpeg4";
    public const string Mpeg4Generic = Base + "mpeg4-generic";
}
