using System;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.Authorization;

using Dgmjr.Blazor.Security.Models;

namespace Dgmjr.Blazor.Security.Services;

public class ApplicationAuthenticationStateProvider(ISecurityService securityService) : AuthenticationStateProvider
{
    private ApplicationAuthenticationState _authenticationState;

public override async Task<AuthenticationState> GetAuthenticationStateAsync()
{
    var identity = new ClaimsIdentity();

    try
    {
        var state = await GetApplicationAuthenticationStateAsync();

        if (state.IsAuthenticated)
        {
            identity = new ClaimsIdentity(
                state.Claims.Select(c => new Claim(c.Type, c.Value)),
                BlazorSecurityConstants.BlazorSecurity
            );
        }
    }
    catch (HttpRequestException) { /* swallow the exception */ }

    var result = new AuthenticationState(new ClaimsPrincipal(identity));

    securityService.Initialize(result);

    return result;
}

private async Task<ApplicationAuthenticationState> GetApplicationAuthenticationStateAsync()
{
    return _authenticationState ??= await securityService.GetAuthenticationStateAsync();
}
}
