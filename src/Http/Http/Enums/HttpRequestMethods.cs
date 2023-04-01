/*
 * HttpMethod.cs
 *
 *   Created: 2022-11-19-09:29:46
 *   Modified: 2022-11-19-09:29:47
 *
 *   Author: David G. Moore, Jr, <david@dgmjr.io>
 *
 *   Copyright © 2022-2023 David G. Moore, Jr,, All Rights Reserved
 *      License: MIT (https://opensource.org/licenses/MIT)
 */

namespace System.Net.Http.Enums;

[GenerateEnumerationRecordStruct("HttpRequestMethod", "System.Net.Http")]
public enum HttpRequestMethod
{
    [Display(Name = HttpRequestMethodNames.Get)]
    Get,

    [Display(Name = HttpRequestMethodNames.Post)]
    Post,

    [Display(Name = HttpRequestMethodNames.Put)]
    Put,

    [Display(Name = HttpRequestMethodNames.Delete)]
    Delete,

    [Display(Name = HttpRequestMethodNames.Patch)]
    Patch,

    [Display(Name = HttpRequestMethodNames.Head)]
    Head,

    [Display(Name = HttpRequestMethodNames.Options)]
    Options,

    [Display(Name = HttpRequestMethodNames.Trace)]
    Trace
}
