/*
 * MediaType.cs
 *
 *   Created: 2023-03-18-07:39:42
 *   Modified: 2023-03-18-07:39:43
 *
 *   Author: David G. Moore, Jr. <david@dgmjr.io>
 *
 *   Copyright © 2022-2023 David G. Moore, Jr., All Rights Reserved
 *      License: MIT (https://opensource.org/licenses/MIT)
 */

namespace Dgmjr.Mime.Enums;

[GenerateEnumerationRecordStruct("MediaType", "Dgmjr.Mime")]
public enum MediaTypes
{
    [Display(Description = "The '*' media type", Name = "*")]
    [Uri(IanaMediaTypeUrlBase)]
    All = int.MaxValue,

    [Display(Description = "The '*' media type", Name = "*")]
    [Uri(IanaMediaTypeUrlBase)]
    Any = All,

    [Display(Description = "The '" + nameof(Example) + "' media type", Name = "example")]
    [Uri(IanaMediaTypeUrlBase + "#example")]
    Example = 0,

    [Display(Description = "The '" + nameof(Text) + "' media type", Name = "text")]
    [Uri(IanaMediaTypeUrlBase + "#text")]
    Text,

    [Display(Description = "The '" + nameof(Image) + "' media type", Name = "image")]
    [Uri(IanaMediaTypeUrlBase + "#image")]
    Image,

    [Display(Description = "The '" + nameof(Audio) + "' media type", Name = "audio")]
    [Uri(IanaMediaTypeUrlBase + "#audio")]
    Audio,

    [Display(Description = "The '" + nameof(Video) + "' media type", Name = "video")]
    [Uri(IanaMediaTypeUrlBase + "#video")]
    Video,

    [Display(Description = "The '" + nameof(Application) + "' media type", Name = "application")]
    [Uri(IanaMediaTypeUrlBase + "#application")]
    Application,

    [Display(Description = "The '" + nameof(Multipart) + "' media type", Name = "multipart")]
    [Uri(IanaMediaTypeUrlBase + "#multipart")]
    Multipart,

    [Display(Description = "The '" + nameof(Message) + "' media type", Name = "message")]
    [Uri(IanaMediaTypeUrlBase + "#message")]
    Message,

    [Display(Description = "The '" + nameof(Model) + "' media type", Name = "model")]
    [Uri(IanaMediaTypeUrlBase + "#model")]
    Model
}
