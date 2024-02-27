using System.Security.Claims;

using Dgmjr.Blazor.Security.Models;

using Microsoft.AspNetCore.Components.Authorization;

namespace Dgmjr.Blazor.Security.Services;

public interface ISecurityService
{
    ApplicationUser User { get; }
    ClaimsPrincipal Principal { get; }

    Task<ApplicationAuthenticationState> GetAuthenticationStateAsync();
    bool Initialize(AuthenticationState result);
    bool IsAuthenticated();
    bool IsInRole(params string[] roles);
    void Login();
    void Logout();
}
