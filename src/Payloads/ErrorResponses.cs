/*
 * ErrorResponsePayload.cs
 *
 *   Created: 2022-11-26-04:57:24
 *   Modified: 2022-11-26-04:57:24
 *
 *   Author: David G. Moore, Jr, <david@dgmjr.io>
 *
 *   Copyright © 2022-2023 David G. Moore, Jr,, All Rights Reserved
 *      License: MIT (https://opensource.org/licenses/MIT)
 */

using Microsoft.AspNetCore.Mvc;

namespace Dgmjr.Payloads;

public static class ErrorResponse
{
    public static ProblemDetails FromException(Exception ex) => new() { Detail = ex.Message };

    public static ProblemDetails ArgumentNullResponse(string argumentName) =>
        new() { Detail = $"Argument '{argumentName}' cannot be null." };
}
