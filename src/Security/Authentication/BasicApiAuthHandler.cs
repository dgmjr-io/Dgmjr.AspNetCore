/*
 * BasicApiAuthHandler.cs
 *
 *   Created: 2022-12-19-06:50:32
 *   Modified: 2022-12-31-05:07:17
 *
 *   Author: David G. Moore, Jr, <david@dgmjr.io>
 *
 *   Copyright © 2022-2023 David G. Moore, Jr,, All Rights Reserved
 *      License: MIT (https://opensource.org/licenses/MIT)
 */

namespace Dgmjr.AspNetCore.Authentication;

using System;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;
using Dgmjr.Abstractions;
using Dgmjr.Identity;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

public class BasicApiAuthHandler
    : AuthenticationHandler<ApiBasicAuthenticationOptions>,
        IHttpContextAccessor,
        ILog
{
    public new ILogger Logger { get; init; }
    private readonly UserManager _userManager;
    private readonly ApiBasicAuthenticationOptions _options;
    public HttpContext? HttpContext
    {
        get => Request.HttpContext;
        set { }
    }

    public BasicApiAuthHandler(
        IOptionsMonitor<ApiBasicAuthenticationOptions> options,
        ILoggerFactory logger,
        UrlEncoder encoder,
        ISystemClock clock,
        UserManager userManager
    ) : base(options, logger, encoder, clock)
    {
        _userManager = userManager;
        _options = options.CurrentValue;
        Logger = logger.CreateLogger<BasicApiAuthHandler>();
    }

    protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
    {
        try
        {
            var authHeader = AuthenticationHeaderValue.Parse(
                Request.Headers[nameof(System.Net.Http.Headers.HttpRequestHeaders.Authorization)]
            );
            var credentialBytes = authHeader.Parameter.FromBase64String();
            var credentials = credentialBytes.ToUTF8String().Split(':', 2);
            var authUsername = credentials[0];
            var authPassword = credentials[1];
            Logger.LogAuthenticatingUser(authUsername);

            // authenticate credentials with user service and attach user to http context
            var user = await _userManager.FindByNameAsync(authUsername);
            if (user is not null && await _userManager.CheckPasswordAsync(user, authPassword))
            {
                var identity = new ClaimsIdentity(
                    ApiBasicAuthenticationOptions.AuthenticationSchemeName
                );
                var userClaims = await _userManager.GetClaimsAsync(user);

                userClaims.Add(new(TelegramID.ClaimType.UserId.Uri, user.Id.ToString()));
                userClaims.Add(new(DgmjrCt.NameIdentifier, user.Id.ToString()));
                userClaims.Add(new(DgmjrCt.AuthenticationInstant, DateTimeOffset.UtcNow.ToString()));
                userClaims.Add(
                    new(
                        DgmjrCt.AuthenticationMethod,
                        ApiBasicAuthenticationOptions.AuthenticationSchemeName
                    )
                );
                userClaims.Add(new(DgmjrCt.CommonName, user.GoByName));
                userClaims.Add(new(DgmjrCt.GivenName, user.GivenName));
                userClaims.Add(new(DgmjrCt.Surname, user.Surname));

                if (
                    !IsNullOrEmpty(user.TelegramUsername)
                    && !userClaims.Any(c => c.Type == TelegramID.ClaimType.Username.Uri)
                )
                {
                    userClaims.Add(new(TelegramID.ClaimType.Username.Uri, user.TelegramUsername));
                }

                if (user.Phone.HasValue && !userClaims.Any(c => c.Type == DgmjrCt.HomePhone))
                {
                    userClaims.Add(new(DgmjrCt.HomePhone, user.PhoneNumber));
                }

                if (user.EmailAddress.HasValue && !userClaims.Any(c => c.Type == DgmjrCt.Email))
                {
                    userClaims.Add(new(DgmjrCt.Email, user.EmailAddress));
                }

                identity.AddClaims(userClaims);
                var principal = new ClaimsPrincipal(identity);
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = identity,
                    Expires = UtcNow + _options.TokenLifetime,
                };
                var ticket = new AuthenticationTicket(
                    principal,
                    ApiBasicAuthenticationOptions.AuthenticationSchemeName
                );
                Logger.LogUserAuthenticated(authUsername, userClaims.Count);
                return AuthenticateResult.Success(ticket);
            }
            else if (user is null)
            {
                Logger.UserAuthenticationFailed(authUsername);
                return AuthenticateResult.Fail("Invalid username or password.");
            }
            Logger.UserAuthenticationFailed(authUsername);
            return AuthenticateResult.Fail(
                "An unknown error occurred while authenticating the user."
            );
        }
        catch (Exception ex)
        {
            Logger.LogError(ex, "An error occurred while authenticating the user.");
            return AuthenticateResult.Fail("An error occurred while authenticating the user.");
        }
    }

    // public async Task<IAuthenticationHandler?> GetHandlerAsync(HttpContext context, string authenticationScheme)
    // {
    //     if (authenticationScheme == ApiBasicAuthenticationOptions.AuthenticationSchemeName)
    //     {
    //         await InitializeAsync(new AuthenticationScheme(authenticationScheme, authenticationScheme, GetType()), context);
    //         return this;
    //     }
    //     return null;
    // }

    // public Task InitializeAsync(AuthenticationScheme scheme, HttpContext context)
    // {
    //     HttpContext = context;
    //     return Task.CompletedTask;
    // }
    // public Task<AuthenticateResult> AuthenticateAsync() => HandleAuthenticateAsync();
    // public Task ChallengeAsync(AuthenticationProperties? properties)
    // {
    //     HttpContext.Response.StatusCode = 401;
    //     HttpContext.Response.Headers["WWW-Authenticate"] = "Basic";
    //     return Task.CompletedTask;
    // }
    // public Task ForbidAsync(AuthenticationProperties? properties)
    // {
    //     HttpContext.Response.StatusCode = 403;
    //     return Task.CompletedTask;
    // }
}
