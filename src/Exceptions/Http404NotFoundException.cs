/*
 * Http404NotFoundException.cs
 *
 *   Created: 2022-12-05-11:47:13
 *   Modified: 2022-12-05-11:47:14
 *
 *   Author: David G. Moore, Jr, <david@dgmjr.io>
 *
 *   Copyright © 2022-2023 David G. Moore, Jr,, All Rights Reserved
 *      License: MIT (https://opensource.org/licenses/MIT)
 */

namespace Microsoft.AspNetCore;

public class Http404NotFoundException : HttpRequestException
{
    public const string DefaultMessage = "The requested item could not be found.";

    public Http404NotFoundException() : this(DefaultMessage) { }

    public Http404NotFoundException(string message = DefaultMessage) : base(message, null, NotFound)
    { }

    public Http404NotFoundException(string message = DefaultMessage, Exception? inner = default)
        : base(message, inner, NotFound) { }
}
