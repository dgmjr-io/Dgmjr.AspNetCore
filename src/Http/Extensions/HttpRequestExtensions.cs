/*
 * HttpRequestExtensions.cs
 *
 *   Created: 2022-11-26-11:58:30
 *   Modified: 2022-11-26-11:58:30
 *
 *   Author: David G. Moore, Jr, <david@dgmjr.io>
 *
 *   Copyright © 2022-2023 David G. Moore, Jr,, All Rights Reserved
 *      License: MIT (https://opensource.org/licenses/MIT)
 */

namespace Microsoft.AspNetCore.Http;
using static System.Net.Http.Headers.HttpRequestHeaderNames;

public static partial class HttpRequestExtensions2
{
    public static string GetContentType(this HttpRequest req) =>
        req.ContentType
        ?? req.GetHeaderParam<string>(ContentType)
        ?? ApplicationMediaTypeNames.Json;
}
