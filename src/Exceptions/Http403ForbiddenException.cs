/*
 * Http403ForbiddenException.cs
 *
 *   Created: 2022-12-05-11:48:11
 *   Modified: 2022-12-05-11:49:05
 *
 *   Author: David G. Moore, Jr, <david@dgmjr.io>
 *
 *   Copyright © 2022-2023 David G. Moore, Jr,, All Rights Reserved
 *      License: MIT (https://opensource.org/licenses/MIT)
 */

namespace Microsoft.AspNetCore;

public class Http403ForbiddenException : HttpRequestException
{
    public const string DefaultMessage = "You do not have permission to access this resource.";

    public Http403ForbiddenException() : this(DefaultMessage) { }

    public Http403ForbiddenException(string message = DefaultMessage)
        : base(message, null, Forbidden) { }

    public Http403ForbiddenException(string message = DefaultMessage, Exception? inner = default)
        : base(message, inner, Forbidden) { }
}
