/*
 * Result.cs
 *
 *   Created: 2024-48-16T04:48:01-05:00
 *   Modified: 2024-48-16T04:48:01-05:00
 *
 *   Author: David G. Moore, Jr. <david@dgmjr.io>
 *
 *   Copyright © 2024 David G. Moore, Jr., All Rights Reserved
 *      License: MIT (https://opensource.org/licenses/MIT)
 */

namespace Dgmjr.AspNetCore.Mvc;

using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;

using OneOf;

public class Result<T> : OneOfBase<ContentResult, ObjectResult>, IConvertToActionResult, IActionResult
{
    public Result(T value, string contentType)
        : base(value is string ? new ContentResult { Content = value as string, ContentType = contentType, StatusCode = Status200OK } :
            new ObjectResult(value) { ContentTypes = [contentType], StatusCode = Status200OK, DeclaredType = typeof(T) }) { }

    protected Result(ContentResult contentResult) : base(contentResult) { }
    protected Result(ObjectResult contentResult) : base(contentResult) { }

    public IActionResult Convert() => this;

    public Task ExecuteResultAsync(ActionContext context)
        => IsT0 ? AsT0.ExecuteResultAsync(context) : AsT1.ExecuteResultAsync(context);

    public static implicit operator Result<T>(ContentResult contentResult) => new(contentResult);

    public static implicit operator Result<T>(ObjectResult objectResult) => new(objectResult);

    public static implicit operator ActionResult?(Result<T> result) => result.Convert() as ActionResult;
}

public class Result : Result<object>
{
    public Result(object value, string contentType) : base(value, contentType) { }
    public Result(ContentResult contentResult) : base(contentResult) { }
    public Result(ObjectResult contentResult) : base(contentResult) { }
}
