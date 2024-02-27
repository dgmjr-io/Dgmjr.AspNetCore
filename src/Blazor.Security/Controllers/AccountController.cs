using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Mvc;
using Dgmjr.Blazor.Security.Models;
using Microsoft.Extensions.Logging;
using Dgmjr.AspNetCore.Mvc;

namespace Dgmjr.Blazor.Security.Controllers;

[Route("Account/[action]")]
[ApiController]
public partial class AccountController(ILogger<AccountController> logger) : ApiControllerBase(logger)
{
    public IActionResult Login(string redirectUri)
    {
        var redirectUrl = redirectUri ?? Url.Content("~/");

        return Challenge(
            new AuthenticationProperties { RedirectUri = redirectUrl },
            OpenIdConnectDefaults.AuthenticationScheme
        );
    }

    public IActionResult Logout()
    {
        var redirectUrl = Url.Content("~/");

        return SignOut(
            new AuthenticationProperties { RedirectUri = redirectUrl },
            CookieAuthenticationDefaults.AuthenticationScheme,
            OpenIdConnectDefaults.AuthenticationScheme
        );
    }

    [HttpPost]
    public ApplicationAuthenticationState CurrentUser()
    {
        return new ApplicationAuthenticationState
        {
            IsAuthenticated = User.Identities.Any(id => id.IsAuthenticated),
            Name = User.Identity.Name,
            Claims = User.Claims.Select(
                c => new ApplicationClaim { Type = c.Type, Value = c.Value }
            )
        };
    }
}
