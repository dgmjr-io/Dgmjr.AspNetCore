// /*
//  * PageOutputJsonFormatter.cs
//  *
//  *   Created: 2022-12-19-04:21:55
//  *   Modified: 2022-12-19-04:21:55
//  *
//  *   Author: David G. Moore, Jr, <david@dgmjr.io>
//  *
//  *   Copyright © 2022-2023 David G. Moore, Jr,, All Rights Reserved
//  *      License: MIT (https://opensource.org/licenses/MIT)
//  */

// using System.Net.Mime.MediaTypes;
// using Microsoft.AspNetCore.Http;
// using Microsoft.AspNetCore.Mvc.Formatters;
// using static Dgmjr.Http.Headers.HttpResponseHeaderNames;
// using TextMediaTypeNames = Dgmjr.Mime.TextMediaTypeNames;

// namespace Dgmjr.Payloads.Formatters;

// public class PagedOutputJsonFormatter : OutputFormatter
// {
//     public PagedOutputJsonFormatter()
//     {
//         SupportedMediaTypes.Add(TextMediaTypeNames.Plain);
//         SupportedMediaTypes.Add(TextMediaTypeNames.Any);
//     }

//     public override bool CanWriteResult(OutputFormatterCanWriteContext context)
//     {
//         return context.Object is IPager
//             && context.HttpContext.Request
//                 .GetTypedHeaders()
//                 .Accept.Any(a => a.MediaType.Value.ToMediaType().Matches(TextMediaTypeNames.Plain));
//     }

//     public override void WriteResponseHeaders(OutputFormatterWriteContext context)
//     {
//         var payload = context.Object as IPayload;
//         var response = context.HttpContext.Response;
//         response.ContentType = !IsNullOrEmpty(context.ContentType.ToString())
//             ? context.ContentType.ToString()
//             : TextMediaTypeNames.Plain;

//         if (payload is IPager pagedPayload)
//         {
//             response.StatusCode =
//                 (!pagedPayload.HasNextPage && !pagedPayload.HasPreviousPage)
//                     ? StatusCodes.Status200OK
//                     : StatusCodes.Status206PartialContent;
//             response.GetTypedHeaders().ContentRange = new(
//                 pagedPayload.PageStartIndex,
//                 pagedPayload.PageEndIndex,
//                 pagedPayload.TotalRecords
//             )
//             {
//                 Unit = "items"
//             };

//             response.Headers.Add(XPageNumber.DisplayName, pagedPayload.Page.ToString());
//             response.Headers.Add(XPageSize.DisplayName, pagedPayload.PageSize.ToString());
//             response.Headers.Add(XTotalRecords.DisplayName, pagedPayload.TotalRecords.ToString());
//             response.Headers.Add(XTotalPages.DisplayName, pagedPayload.TotalPages.ToString());
//             response.Headers.Add(XStartIndex.DisplayName, pagedPayload.PageStartIndex.ToString());
//             response.Headers.Add(XEndIndex.DisplayName, pagedPayload.PageEndIndex.ToString());
//         }
//     }

//     public override async Task WriteResponseBodyAsync(OutputFormatterWriteContext? context)
//     {
//         var payload = context?.Object as IPayload;
//         var response = context?.HttpContext.Response;
//         if (response != null)
//         {
//             response.ContentType = !IsNullOrEmpty(context.ContentType.ToString())
//                 ? context.ContentType.ToString()
//                 : TextMediaTypeNames.Plain;
//             await response.WriteAsync(payload?.ToString() ?? string.Empty);
//         }
//     }

//     // public async Task WriteAsync(OutputFormatterWriteContext context)
//     // {
//     //     var payload = context.Object as IPayload;
//     //     var response = context.HttpContext.Response;
//     //     response.ContentType = TextMediaTypeNames.Plain;

//     //     if (payload is IPager pagedPayload)
//     //     {
//     //         response.StatusCode = (!pagedPayload.HasNextPage && !pagedPayload.HasPreviousPage)
//     //             ? StatusCodes.Status200OK
//     //             : StatusCodes.Status206PartialContent;
//     //         response.GetTypedHeaders().ContentRange = new(
//     //             pagedPayload.PageStartIndex,
//     //             pagedPayload.PageEndIndex,
//     //             pagedPayload.TotalRecords)
//     //         { Unit = "items" };
//     //         response.Headers.Add(XPageNumber, pagedPayload.Page.ToString());
//     //         response.Headers.Add(XPageSize, pagedPayload.PageSize.ToString());
//     //         response.Headers.Add(XTotalRecords, pagedPayload.TotalRecords.ToString());
//     //         response.Headers.Add(XTotalPages, pagedPayload.TotalPages.ToString());
//     //         response.Headers.Add(XStartIndex, pagedPayload.PageStartIndex.ToString());
//     //         response.Headers.Add(XEndIndex, pagedPayload.PageEndIndex.ToString());
//     //         response.Headers.Add(XHasNextPage, pagedPayload.HasNextPage.ToString());
//     //         response.Headers.Add(XHasPreviousPage, pagedPayload.HasPreviousPage.ToString());
//     //         response.Headers.Add(XIsLastPage, pagedPayload.IsLastPage.ToString());
//     //         response.Headers.Add(ContentRange, $"items {pagedPayload.PageStartIndex}-{pagedPayload.PageEndIndex}/{pagedPayload.TotalRecords}");
//     //     }

//     //     await response.WriteAsync(payload.StringValue);
//     // }
// }
