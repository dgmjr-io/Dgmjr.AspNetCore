// /*
//  * ApiAuthorizeAttribute.cs
//  *
//  *   Created: 2022-12-10-07:15:41
//  *   Modified: 2022-12-10-07:15:41
//  *
//  *   Author: David G. Moore, Jr, <david@dgmjr.io>
//  *
//  *   Copyright © 2022-2023 David G. Moore, Jr,, All Rights Reserved
//  *      License: MIT (https://opensource.org/licenses/MIT)
//  */

// using Dgmjr.Identity.Models;
// using Microsoft.AspNetCore.Authorization;
// using Microsoft.AspNetCore.Http;
// using Microsoft.AspNetCore.Mvc;
// using Microsoft.AspNetCore.Mvc.Filters;

// namespace Dgmjr.AspNetCore.Authentication;

// [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
// public class ApiAuthorizeAttribute : AuthorizeAttribute, IAuthorizationFilter
// {
//     public void OnAuthorization(AuthorizationFilterContext context)
//     {
//         // skip authorization if action is decorated with [AllowAnonymous] attribute
//         var allowAnonymous = context.ActionDescriptor.EndpointMetadata
//             .OfType<AllowAnonymousAttribute>()
//             .Any();
//         if (allowAnonymous)
//             return;

//         var user = context.HttpContext.Items[nameof(User)] as User;
//         if (user is null)
//         {
//             // not logged in - return 401 unauthorized
//             context.Result = new JsonResult(new { message = "Unauthorized" })
//             {
//                 StatusCode = StatusCodes.Status401Unauthorized
//             };

//             // set 'WWW-Authenticate' header to trigger login popup in browsers
//             context.HttpContext.Response.Headers["WWW-Authenticate"] =
//                 "Basic realm=\"\", charset=\"UTF-8\"";
//         }
//     }
// }
