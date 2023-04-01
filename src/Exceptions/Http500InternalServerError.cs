/*
 * Http404NotFoundException copy.cs
 *
 *   Created: 2022-12-15-06:18:54
 *   Modified: 2022-12-15-06:18:55
 *
 *   Author: David G. Moore, Jr, <david@dgmjr.io>
 *
 *   Copyright © 2022-2023 David G. Moore, Jr,, All Rights Reserved
 *      License: MIT (https://opensource.org/licenses/MIT)
 */

namespace Microsoft.AspNetCore;

public class Http500InternalServerError : HttpRequestException
{
    public const string DefaultMessage = "An unexpected error occurred.";

    public Http500InternalServerError() : this(DefaultMessage) { }

    public Http500InternalServerError(string message = DefaultMessage)
        : base(message, null, NotFound) { }

    public Http500InternalServerError(string message = DefaultMessage, Exception? inner = default)
        : base(message, inner, NotFound) { }
}
