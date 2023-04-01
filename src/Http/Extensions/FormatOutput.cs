/*
 * FormatOutput.cs
 *
 *   Created: 2022-12-02-03:19:16
 *   Modified: 2022-12-02-03:19:16
 *
 *   Author: David G. Moore, Jr, <david@dgmjr.io>
 *
 *   Copyright © 2022-2023 David G. Moore, Jr,, All Rights Reserved
 *      License: MIT (https://opensource.org/licenses/MIT)
 */

namespace Dgmjr.Http.Extensions;

public static class FormatOutputMethod
{
    // public static IActionResult FormatResponse<T>(this HttpContext ctx, object? value, int page = 1, int pageSize = 1, int total = 1)
    // {
    //     ctx.Response.Headers.Add(HttpResponseHeaderNames.XPageNumber, page.ToString());
    //     ctx.Response.Headers.Add(HttpResponseHeaderNames.XPageSize, pageSize.ToString());
    //     ctx.Response.Headers.Add(HttpResponseHeaderNames.XTotalPages, total.ToString());

    //     string accept = ctx.Request.Headers[HttpRequestHeaderNames.Accept];

    //     if (accept.Contains(TextMediaTypeNames.Plain/*, StringComparison.OrdinalIgnoreCase*/))
    //     {
    //         return new ContentResult
    //         {
    //             Content = value.AsString(),
    //             ContentType = TextMediaTypeNames.Plain,
    //             StatusCode = 200
    //         };
    //     }
    //     else if (accept.Contains(ApplicationMediaTypeNames.JsonWithPlainText))
    //     {
    //         if (pageSize == 1)
    //         {
    //             return new OkObjectResult(new StringResponsePayload(value?.AsString()));
    //         }
    //         else
    //         {
    //             return new OkObjectResult(new SingleItemPager<string>(string.Join(", ", (value as IEnumerable<T?>).Select(item => item?.ToString())), page, total));
    //         }
    //     }
    //     else
    //     {
    //         if (pageSize == 1)
    //         {
    //             return new OkObjectResult(new ResponsePayload<T>((T?)value));
    //         }
    //         else
    //         {
    //             return new OkObjectResult(new Pager<T>((value as IEnumerable<T>)?.ToArray(), page, pageSize, total));
    //         }
    //     }
    // }

    // public static string AsString<T>(this T? value)
    // {
    //     if(typeof(IEnumerable).IsAssignableFrom(typeof(T)))
    //     {
    //         return string.Join(", ", ((IEnumerable)value).OfType<object>().Select(item => item?.ToString()));
    //     }
    //     else
    //     {
    //         return value?.ToString() ?? string.Empty;
    //     }
    // }
}
