/*
 * IProblemDetails.cs
 *
 *   Created: 2023-01-04-04:30:24
 *   Modified: 2023-01-04-04:30:24
 *
 *   Author: David G. Moore, Jr, <david@dgmjr.io>
 *
 *   Copyright © 2022-2023 David G. Moore, Jr,, All Rights Reserved
 *      License: MIT (https://opensource.org/licenses/MIT)
 */

using Microsoft.AspNetCore.Mvc;

namespace Dgmjr.AspNetCore.Mvc;

// [GenerateInterface(typeof(ProblemDetails))]
public interface IProblemDetails
{
    string? Type { get; }
    string? Title { get; }
    int? Status { get; }
    string? Detail { get; }
    string? Instance { get; }

    IDictionary<string, object?> Extensions { get; }
}
