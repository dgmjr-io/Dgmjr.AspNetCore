/*
 * BearerTokenAuthenticationProvider.cs
 *
 *   Created: 2024-12-26T12:12:00-05:00
 *   Modified: 2024-12-26T12:12:00-05:00
 *
 *   Author: David G. Moore, Jr. <david@dgmjr.io>
 *
 *   Copyright © 2023 - 2024 David G. Moore, Jr., All Rights Reserved
 *      License: MIT (https://opensource.org/licenses/MIT)
 */

using System.Net.Http;
using System.Threading.Tasks;

using Microsoft.Kiota.Abstractions;
using Microsoft.Kiota.Abstractions.Authentication;

using IAuthenticationProvider = Microsoft.Graph.IAuthenticationProvider;

namespace Dgmjr.Graph;

public class BearerTokenAuthenticationProvider(IAccessTokenProvider accessTokenProvider)
    : BaseBearerTokenAuthenticationProvider(accessTokenProvider),
        IAuthenticationProvider
{
    public Task AuthenticateRequestAsync(HttpRequestMessage request)
{
    return base.AuthenticateRequestAsync(new HttpRequestMessageWrapper(request));
}
}

internal class HttpRequestMessageWrapper(HttpRequestMessage request) : RequestInformation
{ }
