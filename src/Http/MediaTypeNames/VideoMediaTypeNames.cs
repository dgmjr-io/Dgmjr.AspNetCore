/*
 * VideoMediaTypeNames.cs
 *
 *   Created: 2022-12-31-01:35:40
 *   Modified: 2022-12-31-01:35:40
 *
 *   Author: David G. Moore, Jr, <david@dgmjr.io>
 *
 *   Copyright © 2022-2023 David G. Moore, Jr,, All Rights Reserved
 *      License: MIT (https://opensource.org/licenses/MIT)
 */

namespace System.Net.Mime.MediaTypes;

using System.Runtime.Serialization;

public static class VideoMediaTypeNames
{
    public const string Base = "video";
    public const string Any = Base + "/" + "*";
    public const string Mpeg = Base + "/" + "mpeg";
    public const string Mpeg4 = Base + "/" + "mp4";
    public const string Mpeg4Generic = Base + "/" + "mp4; codecs=avc1.42E01E, mp4a.40.2";
    public const string Mp4 = Base + "/" + "mp4";
    public const string Ogg = Base + "/" + "ogg";
    public const string QuickTime = Base + "/" + "quicktime";
    public const string WebM = Base + "/" + "webm";
    public const string H264 = Base + "/" + "H264";
    public const string H265 = Base + "/" + "H265";
    public const string Theora = Base + "/" + "Theora";
    public const string Vp8 = Base + "/" + "VP8";
    public const string Vp9 = Base + "/" + "VP9";
    public const string Vorbis = Base + "/" + "Vorbis";
}
