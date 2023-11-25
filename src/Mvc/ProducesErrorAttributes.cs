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
            Dgmjr.Mime.Application.Json.ShortName
        ) { }
}

[AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, AllowMultiple = true)]
public sealed class Produces401ErrorAttribute : SwaggerResponseAttribute
{
    public Produces401ErrorAttribute()
        : base(
            Status401Unauthorized,
            "You're not allowed to fucking do that!",
            typeof(UnauthorizedProblemDetails),
            ApplicationMediaTypeNames.ProblemJson
        ) { }
}

[AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, AllowMultiple = true)]
public sealed class Produces403ErrorAttribute : SwaggerResponseAttribute
{
    public Produces403ErrorAttribute()
        : base(
            Status403Forbidden,
            "You're not allowed to fucking do that!",
            typeof(ForbiddenProblemDetails),
            ApplicationMediaTypeNames.ProblemJson
        ) { }
}

[AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, AllowMultiple = true)]
public sealed class Produces404ErrorAttribute : SwaggerResponseAttribute
{
    public Produces404ErrorAttribute()
        : base(
            Status404NotFound,
            "The shit you're looking for doesn't fucking exist!",
            typeof(NotFoundProblemDetails),
            ApplicationMediaTypeNames.ProblemJson
        ) { }
}

[AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, AllowMultiple = true)]
public sealed class Produces418ErrorAttribute : SwaggerResponseAttribute
{
    public Produces418ErrorAttribute()
        : base(
            Status418ImATeapot,
            "I'm a fucking teapot, short and stout.  Here's my handle; here's my spout.  If you've reached this error code, you must shout, \"I'm a fuckin' idiot so kick me out!\"",
            typeof(ImATeapotProblemDetailsExample),
            ApplicationMediaTypeNames.ProblemJson
        ) { }
}

[AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, AllowMultiple = true)]
public sealed class Produces500ErrorAttribute : SwaggerResponseAttribute
{
    public Produces500ErrorAttribute()
        : base(
            Status500InternalServerError,
            "Shit hit the fucking fan!",
            typeof(InternalServerErrorProblemDetails),
            ApplicationMediaTypeNames.ProblemJson
        ) { }
}
