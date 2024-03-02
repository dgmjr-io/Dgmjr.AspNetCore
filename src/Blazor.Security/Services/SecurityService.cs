namespace Dgmjr.Blazor.Security.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Web;

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;

using Dgmjr.Blazor.Security.Models;

using Radzen;

public class SecurityService(NavigationManager navigationManager, IHttpClientFactory factory) : ISecurityService
{
    private readonly HttpClient _httpClient = factory.CreateClient(BlazorSecurityConstants.BlazorSecurity);

public ApplicationUser User { get; private set; } = new ApplicationUser { Name = "Anonymous" };

public ClaimsPrincipal Principal { get; private set; }

public async Task<ApplicationAuthenticationState> GetAuthenticationStateAsync()
{
    var uri = new Uri($"{navigationManager.BaseUri}{Uris.CurrentUser}");

    var response = await _httpClient.SendAsync(new HttpRequestMessage(HttpMethod.Post, uri));

    return await response.ReadAsync<ApplicationAuthenticationState>();
}

public bool IsInRole(params string[] roles)
    => roles.Contains("Everybody")
        || (IsAuthenticated() && (roles.Contains("Authenticated") || Exists(roles, role => Principal.IsInRole(role))));

public bool IsAuthenticated()
    => Principal?.Identity.IsAuthenticated == true;

public bool Initialize(AuthenticationState result)
{
    Principal = result.User;

    var name = Principal.FindFirstValue(ClaimTypes.Name) ?? Principal.FindFirstValue("name");

    if (name != null)
    {
        User = new ApplicationUser { Name = name };
    }

    return IsAuthenticated();
}

public void Logout()
    => navigationManager.NavigateTo(Uris.Logout, true);

public void Login()
    => navigationManager.NavigateTo(Uris.Login, true);
}
