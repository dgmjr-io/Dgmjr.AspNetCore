/*
 * MediaTypeNames.cs
 *
 *   Created: 2022-11-29-01:56:37
 *   Modified: 2022-11-29-04:39:51
 *
 *   Author: David G. Moore, Jr, <david@dgmjr.io>
 *
 *   Copyright © 2022-2023 David G. Moore, Jr,, All Rights Reserved
 *      License: MIT (https://opensource.org/licenses/MIT)
 */

namespace Dgmjr.Mime;

public static class MediaTypeNames
{
    public const string All = "*/*";
    public const string Text = TextMediaTypeNames.Base + "/*";
    public const string Image = ImageMediaTypeNames.Base + "/*";
    public const string Audio = AudioMediaTypeNames.Base + "/*";
    public const string Video = VideoMediaTypeNames.Base + "/*";
    public const string Application = ApplicationMediaTypeNames.Base + "/*";
    public const string Multipart = MultipartMediaTypeNames.Base + "/*";
    public const string Message = MessageMediaTypeNames.Base + "/*";
    public const string Model = ModelMediaTypeNames.Base + "/*";

    // public const string Message = "message/*";
    // public const string Model = "model/*";
    public const string Example = "example/*";
    // public const string Font = "font/*";
}
