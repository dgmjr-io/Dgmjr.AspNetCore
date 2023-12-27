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

namespace Dgmjr.Mime.Enums;

using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

[GenerateEnumerationRecordStruct("Image", "Dgmjr.Mime")]
public enum ImageMediaTypes
{
    [Display(Name = ImageMediaTypeNames.Any, Description = nameof(Any))]
    [EnumMember(Value = ImageMediaTypeNames.Any)]
    [Uri(IanaMediaTypeUrlBase + "#image/*")]
    Any = int.MaxValue,

    [Display(Name = ImageMediaTypeNames.Base, Description = nameof(Base))]
    [EnumMember(Value = ImageMediaTypeNames.Base)]
    [Uri(IanaMediaTypeUrlBase + "#image")]
    Base = 0,

    /// <summary>GIF image</summary>
    [Display(Name = ImageMediaTypeNames.Gif, Description = "GIF image")]
    [EnumMember(Value = ImageMediaTypeNames.Gif)]
    [Uri(IanaMediaTypeUrlBase + ImageMediaTypeNames.Gif)]
    Gif,

    /// <summary>JPEG image</summary>
    [Display(Name = ImageMediaTypeNames.Jpeg, Description = "JPEG image")]
    [EnumMember(Value = ImageMediaTypeNames.Jpeg)]
    [Uri(IanaMediaTypeUrlBase + ImageMediaTypeNames.Jpeg)]
    Jpeg,

    /// <summary>PNG image</summary>
    [Display(Name = ImageMediaTypeNames.Png, Description = "PNG image")]
    [EnumMember(Value = ImageMediaTypeNames.Png)]
    [Uri(IanaMediaTypeUrlBase + ImageMediaTypeNames.Png)]
    Png,

    /// <summary>TIFF image</summary>
    [Display(Name = ImageMediaTypeNames.Tiff, Description = nameof(Tiff))]
    [EnumMember(Value = ImageMediaTypeNames.Tiff)]
    [Uri(IanaMediaTypeUrlBase + ImageMediaTypeNames.Tiff)]
    Tiff,

    /// <summary>SVG image</summary>
    [Display(Name = ImageMediaTypeNames.Svg, Description = "SVG image")]
    [EnumMember(Value = ImageMediaTypeNames.Svg)]
    [Uri(IanaMediaTypeUrlBase + ImageMediaTypeNames.Svg)]
    Svg,

    /// <summary>Icon image</summary>
    [Display(Name = ImageMediaTypeNames.Icon, Description = "Icon image")]
    [EnumMember(Value = ImageMediaTypeNames.Icon)]
    [Uri(IanaMediaTypeUrlBase + ImageMediaTypeNames.Icon)]
    Icon,

    /// <summary>AVIF image</summary>
    [Display(Name = ImageMediaTypeNames.Avif, Description = "AVIF image")]
    [EnumMember(Value = ImageMediaTypeNames.Avif)]
    [Uri(IanaMediaTypeUrlBase + ImageMediaTypeNames.Avif)]
    Avif,

    /// <summary>WebP image</summary>
    [Display(Name = ImageMediaTypeNames.Webp, Description = "WebP image")]
    [EnumMember(Value = ImageMediaTypeNames.Webp)]
    [Uri(IanaMediaTypeUrlBase + ImageMediaTypeNames.Webp)]
    Webp,

    /// <summary>HEIF image</summary>
    [Display(Name = ImageMediaTypeNames.Heif, Description = "HEIF image")]
    [EnumMember(Value = ImageMediaTypeNames.Heif)]
    [Uri(IanaMediaTypeUrlBase + ImageMediaTypeNames.Heif)]
    Heif,

    /// <summary>HEIC image</summary>
    [Display(Name = ImageMediaTypeNames.Heic, Description = "HEIC image")]
    [EnumMember(Value = ImageMediaTypeNames.Heic)]
    [Uri(IanaMediaTypeUrlBase + ImageMediaTypeNames.Heic)]
    Heic,

    /// <summary>BMP image</summary>
    [Display(Name = ImageMediaTypeNames.Bmp, Description = "BMP image")]
    [EnumMember(Value = ImageMediaTypeNames.Bmp)]
    [Uri(IanaMediaTypeUrlBase + ImageMediaTypeNames.Bmp)]
    Bmp,

    /// <summary>APNG image</summary>
    [Display(Name = ImageMediaTypeNames.Apng, Description = "APNG image")]
    [EnumMember(Value = ImageMediaTypeNames.Apng)]
    [Uri(IanaMediaTypeUrlBase + ImageMediaTypeNames.Apng)]
    Apng
}
