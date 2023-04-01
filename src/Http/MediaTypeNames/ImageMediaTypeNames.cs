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

namespace System.Net.Mime.MediaTypes;

public static class ImageMediaTypeNames
{
    /// <summary>The base type for all image types.</summary>
    /// <remarks>See <see href="https://www.iana.org/assignments/media-types/media-types.xhtml#image">IANA Media Types</see> for more information.</remarks>
    /// <seealso cref="Any"/>
    /// <value>image/</value>
    public const string Base = "image";

    /// <summary>Media type for any image.</summary>
    /// <value><inheritdoc cref="Base" />*</value>
    public const string Any = Base + "/" + "*";

    /// <summary>GIF image</summary>
    /// <value><inheritdoc cref="Base" />gif</value>
    public const string Gif = Base + "/" + "gif";

    /// <summary>JPEG image</summary>
    /// <value><inheritdoc cref="Base" />jpeg</value>
    public const string Jpeg = Base + "/" + "jpeg";

    /// <summary>PNG image</summary>
    /// <value><inheritdoc cref="Base" />png</value>
    public const string Png = Base + "/" + "png";

    /// <summary>TIFF image</summary>
    /// <value><inheritdoc cref="Base" />tiff</value>
    public const string Tiff = Base + "/" + "tiff";

    /// <summary>SVG image</summary>
    /// <value><inheritdoc cref="Base" />svg+xml</value>
    public const string Svg = Base + "/" + "svg+xml";

    /// <summary>Icon image</summary>
    /// <value><inheritdoc cref="Base" />vnd.microsoft.icon</value>
    public const string Icon = Base + "/" + "vnd.microsoft.icon";

    /// <summary>AVIF image</summary>
    /// <value><inheritdoc cref="Base" />avif</value>
    public const string Avif = Base + "/" + "avif";

    /// <summary>Bitmap image</summary>
    /// <value><inheritdoc cref="Base" />bmp</value>
    public const string Bmp = Base + "/" + "bmp";

    /// <summary>WebP image</summary>
    /// <value><inheritdoc cref="Base" />webp</value>
    public const string Webp = Base + "/" + "webp";

    /// <summary>APNG image</summary>
    /// <value><inheritdoc cref="Base" />apng</value>
    public const string Apng = Base + "/" + "apng";

    /// <summary>HEIF image</summary>
    /// <value><inheritdoc cref="Base" />heif</value>
    public const string Heif = Base + "/" + "heif";

    /// <summary>HEIC image</summary>
    /// <value><inheritdoc cref="Base" />heic</value>
    public const string Heic = Base + "/" + "heic";

    /// <summary>HEIF sequence image</summary>
    /// <value><inheritdoc cref="Base" />heif-sequence</value>
    public const string HeifSequence = Base + "/" + "heif-sequence";

    /// <summary>HEIC sequence image</summary>
    /// <value><inheritdoc cref="Base" />heic-sequence</value>
    public const string HeicSequence = Base + "/" + "heic-sequence";

    /// <summary>JP2 image</summary>
    /// <value><inheritdoc cref="Base" />jp2</value>
    public const string Jp2 = Base + "/" + "jp2";

    /// <summary>JPM image</summary>
    /// <value><inheritdoc cref="Base" />jpm</value>
    public const string Jpm = Base + "/" + "jpm";

    /// <summary>JPX image</summary>
    /// <value><inheritdoc cref="Base" />jpx</value>
    public const string Jpx = Base + "/" + "jpx";

    /// <summary>JB2 image</summary>
    /// <value><inheritdoc cref="Base" />jb2</value>
    public const string Jb2 = Base + "/" + "jb2";

    /// <summary>SWF image</summary>
    /// <value><inheritdoc cref="Base" />x-shockwave-flash</value>
    public const string Swf = Base + "/" + "x-shockwave-flash";

    /// <summary>FlashPix image</summary>
    /// <value><inheritdoc cref="Base" />vnd.adobe.photoshop</value>
    public const string FlashPix = Base + "/" + "vnd.adobe.photoshop";

    /// <summary>Camera image</summary>
    /// <value><inheritdoc cref="Base" />x-canon-cr2</value>
    public const string Camera = Base + "/" + "x-canon-cr2";

    /// <summary>Camera image</summary>
    /// <value><inheritdoc cref="Base" />x-canon-crw</value>
    public const string Camera2 = Base + "/" + "x-canon-crw";

    /// <summary>Camera image</summary>
    /// <value><inheritdoc cref="Base" />x-nikon-nef</value>
    public const string Camera3 = Base + "/" + "x-nikon-nef";
}
