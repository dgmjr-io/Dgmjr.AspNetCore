/*
 * VideoMediaType.cs
 *
 *   Created: 2023-03-18-07:00:15
 *   Modified: 2023-03-18-07:00:15
 *
 *   Author: David G. Moore, Jr. <david@dgmjr.io>
 *
 *   Copyright © 2022-2023 David G. Moore, Jr., All Rights Reserved
 *      License: MIT (https://opensource.org/licenses/MIT)
 */

namespace Dgmjr.Mime.Enums;

using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

[GenerateEnumerationRecordStruct("Video", "Dgmjr.Mime")]
public enum VideoMediaTypes : int
{
    [Display(Name = VideoMediaTypeNames.Any, Description = nameof(Any))]
    [Uri(IanaMediaTypeUrlBase + "#video")]
    Any = int.MaxValue,

    [Display(Name = VideoMediaTypeNames.Base, Description = nameof(Base))]
    [Uri(IanaMediaTypeUrlBase + "#video-*")]
    Base = 0,

    [Display(Name = VideoMediaTypeNames.Mpeg, Description = nameof(Mpeg))]
    [Uri(IanaMediaTypeUrlBase + VideoMediaTypeNames.Mpeg)]
    Mpeg,

    [Display(Name = VideoMediaTypeNames.Mpeg4, Description = nameof(Mpeg4))]
    [Uri(IanaMediaTypeUrlBase + VideoMediaTypeNames.Mpeg4)]
    Mpeg4,

    [Display(Name = VideoMediaTypeNames.Mpeg4Generic, Description = nameof(Mpeg4Generic))]
    [Uri(IanaMediaTypeUrlBase + VideoMediaTypeNames.Mpeg4Generic)]
    Mpeg4Generic,

    [Display(Name = VideoMediaTypeNames.Mp4, Description = nameof(Mp4))]
    [Uri(IanaMediaTypeUrlBase + VideoMediaTypeNames.Mp4)]
    Mp4,

    [Display(Name = VideoMediaTypeNames.Ogg, Description = nameof(Ogg))]
    [Uri(IanaMediaTypeUrlBase + VideoMediaTypeNames.Ogg)]
    Ogg,

    [Display(Name = VideoMediaTypeNames.QuickTime, Description = nameof(QuickTime))]
    [Uri(IanaMediaTypeUrlBase + VideoMediaTypeNames.QuickTime)]
    QuickTime,

    [Display(Name = VideoMediaTypeNames.WebM, Description = nameof(WebM))]
    [Uri(IanaMediaTypeUrlBase + VideoMediaTypeNames.WebM)]
    WebM,

    [Display(Name = VideoMediaTypeNames.H264, Description = nameof(H264))]
    [Uri(IanaMediaTypeUrlBase + VideoMediaTypeNames.H264)]
    H264,

    [Display(Name = VideoMediaTypeNames.H265, Description = nameof(H265))]
    [Uri(IanaMediaTypeUrlBase + VideoMediaTypeNames.H265)]
    H265,

    [Display(Name = VideoMediaTypeNames.Theora, Description = nameof(Theora))]
    [Uri(IanaMediaTypeUrlBase + VideoMediaTypeNames.Theora)]
    Theora,

    [Display(Name = VideoMediaTypeNames.Vp8, Description = nameof(Vp8))]
    [Uri(IanaMediaTypeUrlBase + VideoMediaTypeNames.Vp8)]
    Vp8,

    [Display(Name = VideoMediaTypeNames.Vp9, Description = nameof(Vp9))]
    [Uri(IanaMediaTypeUrlBase + VideoMediaTypeNames.Vp9)]
    Vp9,

    [Display(Name = VideoMediaTypeNames.Vorbis, Description = nameof(Vorbis))]
    [Uri(IanaMediaTypeUrlBase + VideoMediaTypeNames.Vorbis)]
    Vorbis
}
