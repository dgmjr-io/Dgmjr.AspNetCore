/*
 * Attributes.cs
 *
 *   Created: 2023-01-04-04:14:24
 *   Modified: 2023-01-04-04:14:24
 *
 *   Author: David G. Moore, Jr, <david@dgmjr.io>
 *
 *   Copyright © 2022-2023 David G. Moore, Jr,, All Rights Reserved
 *      License: MIT (https://opensource.org/licenses/MIT)
 */

namespace Dgmjr.AspNetCore.Mvc;

using Swashbuckle.AspNetCore.Annotations;

using static Microsoft.AspNetCore.Http.StatusCodes;

[AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, AllowMultiple = true)]
public sealed class Produces400ErrorAttribute : SwaggerResponseAttribute
{
    public Produces400ErrorAttribute()
        : base(
            Status400BadRequest,
            "You done fucked up!",
            typeof(BadRequestProblemDetails),
            ApplicationMediaTypeNames.ProblemJson
        )
    { }
}
