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

namespace System.Net.Mime.MediaTypes.Enums;

using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

[GenerateEnumerationRecordStruct("VideoMediaType", "System.Net.Mime.MediaTypes")]
public enum VideoMediaType
{
    [Display(Name = VideoMediaTypeNames.Any, Description = nameof(Any))]
    [EnumMember(Value = VideoMediaTypeNames.Any)]
    Any,

    [Display(Name = VideoMediaTypeNames.Base, Description = nameof(Base))]
    [EnumMember(Value = VideoMediaTypeNames.Base)]
    Base,

    [Display(Name = VideoMediaTypeNames.Mpeg, Description = nameof(Mpeg))]
    [EnumMember(Value = VideoMediaTypeNames.Mpeg)]
    Mpeg,

    [Display(Name = VideoMediaTypeNames.Mpeg4, Description = nameof(Mpeg4))]
    [EnumMember(Value = VideoMediaTypeNames.Mpeg4)]
    Mpeg4,

    [Display(Name = VideoMediaTypeNames.Mpeg4Generic, Description = nameof(Mpeg4Generic))]
    [EnumMember(Value = VideoMediaTypeNames.Mpeg4Generic)]
    Mpeg4Generic,

    [Display(Name = VideoMediaTypeNames.Mp4, Description = nameof(Mp4))]
    [EnumMember(Value = VideoMediaTypeNames.Mp4)]
    Mp4,

    [Display(Name = VideoMediaTypeNames.Ogg, Description = nameof(Ogg))]
    [EnumMember(Value = VideoMediaTypeNames.Ogg)]
    Ogg,

    [Display(Name = VideoMediaTypeNames.QuickTime, Description = nameof(QuickTime))]
    [EnumMember(Value = VideoMediaTypeNames.QuickTime)]
    QuickTime,

    [Display(Name = VideoMediaTypeNames.WebM, Description = nameof(WebM))]
    [EnumMember(Value = VideoMediaTypeNames.WebM)]
    WebM,

    [Display(Name = VideoMediaTypeNames.H264, Description = nameof(H264))]
    [EnumMember(Value = VideoMediaTypeNames.H264)]
    H264,

    [Display(Name = VideoMediaTypeNames.H265, Description = nameof(H265))]
    [EnumMember(Value = VideoMediaTypeNames.H265)]
    H265,

    [Display(Name = VideoMediaTypeNames.Theora, Description = nameof(Theora))]
    [EnumMember(Value = VideoMediaTypeNames.Theora)]
    Theora,

    [Display(Name = VideoMediaTypeNames.Vp8, Description = nameof(Vp8))]
    [EnumMember(Value = VideoMediaTypeNames.Vp8)]
    Vp8,

    [Display(Name = VideoMediaTypeNames.Vp9, Description = nameof(Vp9))]
    [EnumMember(Value = VideoMediaTypeNames.Vp9)]
    Vp9,

    [Display(Name = VideoMediaTypeNames.Vorbis, Description = nameof(Vorbis))]
    [EnumMember(Value = VideoMediaTypeNames.Vorbis)]
    Vorbis
}
