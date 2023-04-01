// using System.Reflection.Metadata.Ecma335;
// using Microsoft.AspNetCore.Diagnostics;
// using Microsoft.AspNetCore.Mvc;
// using Microsoft.Extensions.Hosting;
// /*
// * ErrorsController.cs
// *
// *   Created: 2022-12-05-07:09:24
// *   Modified: 2022-12-05-07:09:24
// *
// *   Author: David G. Moore, Jr, <david@dgmjr.io>
// *
// *   Copyright © 2022-2023 David G. Moore, Jr,, All Rights Reserved
// *      License: MIT (https://opensource.org/licenses/MIT)
// */

// namespace Dgmjr.AspNetCore.ErrorHandling;

// public class ErrorsController : ControllerBase
// {
//     [Route("/error-development")]
//     public IActionResult HandleErrorDevelopment(
//         [FromServices] IHostEnvironment hostEnvironment)
//     {
//         if (!hostEnvironment.IsDevelopment())
//         {
//             return NotFound();
//         }

//         var exceptionHandlerFeature =
//             HttpContext.Features.Get<IExceptionHandlerFeature>()!;

//         return Problem(
//             detail: exceptionHandlerFeature.Error.StackTrace,
//             title: exceptionHandlerFeature.Error.Message);
//     }

//     [Route("/error")]
//     public IActionResult HandleError() =>
//         Problem();
// }
