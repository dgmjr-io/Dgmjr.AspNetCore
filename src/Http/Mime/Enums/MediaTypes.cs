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
public enum MediaTypes : int
{
    [Display(Description = "The '*' media type")]
    [Uri(IanaMediaTypeUrlBase)]
    All = int.MaxValue,

    [Display(Description = "The '*' media type")]
    [Uri(IanaMediaTypeUrlBase)]
    Any = All,

    [Display(Description = "The '" + nameof(Example) + "' media type")]
    [Uri(IanaMediaTypeUrlBase + "#example")]
    Example = 0,

    [Display(Description = "The '" + nameof(Text) + "' media type")]
    [Uri(IanaMediaTypeUrlBase + "#text")]
    Text,

    [Display(Description = "The '" + nameof(Image) + "' media type")]
    [Uri(IanaMediaTypeUrlBase + "#image")]
    Image,

    [Display(Description = "The '" + nameof(Audio) + "' media type")]
    [Uri(IanaMediaTypeUrlBase + "#audio")]
    Audio,

    [Display(Description = "The '" + nameof(Video) + "' media type")]
    [Uri(IanaMediaTypeUrlBase + "#video")]
    Video,

    [Display(Description = "The '" + nameof(Application) + "' media type")]
    [Uri(IanaMediaTypeUrlBase + "#application")]
    Application,

    [Display(Description = "The '" + nameof(Multipart) + "' media type")]
    [Uri(IanaMediaTypeUrlBase + "#multipart")]
    Multipart,

    [Display(Description = "The '" + nameof(Message) + "' media type")]
    [Uri(IanaMediaTypeUrlBase + "#message")]
    Message,

    [Display(Description = "The '" + nameof(Model) + "' media type")]
    [Uri(IanaMediaTypeUrlBase + "#model")]
    Model
}
