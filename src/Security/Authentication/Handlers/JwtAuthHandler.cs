/*
 * JwtAuthHandler.cs
 *
 *   Created: 2023-04-06-02:15:37
 *   Modified: 2023-04-06-02:15:53
 *
 *   Author: David G. Moore, Jr. <david@dgmjr.io>
 *
 *   Copyright © 2022 - 2023 David G. Moore, Jr., All Rights Reserved
 *      License: MIT (https://opensource.org/licenses/MIT)
 */


namespace Dgmjr.AspNetCore.Authentication.Handlers;

using System;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;
using Dgmjr.Abstractions;
using Dgmjr.AspNetCore.Authentication.Options;
using Dgmjr.Identity;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authentication.JwtBearer;

public class JwtAuthHandler
    : Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerHandler,
        IHttpContextAccessor,
        ILog
{
    public new ILogger Logger { get; }
    private readonly UserManager _userManager;
    private readonly BasicAuthenticationSchemeOptions _options;
    public HttpContext? HttpContext
    {
        get => Request.HttpContext;
        set { }
    }

    public JwtAuthHandler(
        IOptionsMonitor<JwtConfigurationOptions> options,
        ILoggerFactory logger,
        UrlEncoder encoder,
        ISystemClock clock,
        UserManager userManager
    )
        : base(options, logger, encoder, clock)
    {
        _userManager = userManager;
        _options = options.CurrentValue;
        Logger = logger.CreateLogger<JwtAuthHandler>();
    }

    protected virtual string? AuthenticationSchemeName => _options?.AuthenticationSchemeName;

    protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
    {
        try
        {
            var authHeader = AuthenticationHeaderValue.Parse(
                Request.Headers[nameof(HttpRequestHeaders.Authorization)]
            );
            opts.TokenValidationParameters = new TokenValidationParameters
            {
                ValidIssuer = _options?.ClaimsIssuer ?? DgmjrCt.BaseUri,
                ValidAudience = builder.Configuration[
                    $"{nameof(JwtConfigurationOptions)}:{nameof(JwtConfigurationOptions.Audience)}"
                ],
                IssuerSigningKey = new SymmetricSecurityKey(
                    builder.Configuration[
                        $"{nameof(JwtConfigurationOptions)}:{nameof(JwtConfigurationOptions.Secret)}"
                    ].ToUTF8Bytes()
                ),
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateIssuerSigningKey = true
            };
            Logger.LogAuthenticatingUser(authUsername);

            // authenticate credentials with user service and attach user to http context
            var user = await _userManager.FindByNameAsync(authUsername);
            if (user is not null && await _userManager.CheckPasswordAsync(user, authPassword))
            {
                var identity = new ClaimsIdentity(AuthenticationSchemeName);
                var userClaims = await _userManager.GetClaimsAsync(user);

                userClaims.Add(new(TelegramID.ClaimType.UserId.Uri, user.Id.ToString()));
                userClaims.Add(new(DgmjrCt.NameIdentifier, user.Id.ToString()));
                userClaims.Add(
                    new(DgmjrCt.AuthenticationInstant, DateTimeOffset.UtcNow.ToString())
                );
                userClaims.Add(new(DgmjrCt.AuthenticationMethod, AuthenticationSchemeName));
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

                if (user.EmailAddsress.HasValue && !userClaims.Any(c => c.Type == DgmjrCt.Email))
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
                var ticket = new AuthenticationTicket(principal, AuthenticationSchemeName);
                HttpContext.User = principal;
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
            Logger.LogAuthenticationError(ex.Message, ex.StackTrace);
            return AuthenticateResult.Fail("An error occurred while authenticating the user.");
        }
    }
}
