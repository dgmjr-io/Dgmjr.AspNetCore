/*
 * GeneratedCustomAuthHandler.cs
 *
 *   Created: 2023-04-01-02:38:20
 *   Modified: 2023-04-01-02:38:20
 *
 *   Author: David G. Moore, Jr. <david@dgmjr.io>
 *
 *   Copyright © 2022 - 2023 David G. Moore, Jr., All Rights Reserved
 *      License: MIT (https://opensource.org/licenses/MIT)
 */

namespace Dgmjr.AspNetCore.Authentication.Generated;

using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Dgmjr.Identity;
using Dgmjr.Identity.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

public class JwtBearerBasicAuthHandler : AuthenticationHandler<GeneratedAuthenticationSchemeOptions>
{
    private const string AuthorizationHeaderName = System
        .Net
        .Http
        .Headers
        .HttpRequestHeaderName
        .Authorization
        .Name;
    private const string BasicSchemeName = "Basic";
    private const string BearerSchemeName = "Bearer";
    protected virtual UserManager UserManager { get; init; }

    private readonly SymmetricSecurityKey _jwtKey;

    public JwtBearerBasicAuthHandler(
        IOptionsMonitor<GeneratedAuthenticationSchemeOptions> options,
        ILoggerFactory logger,
        UrlEncoder encoder,
        ISystemClock clock,
        UserManager userManager
    )
        : base(options, logger, encoder, clock)
    {
        if (options?.CurrentValue?.Secret.IsNullOrWhitespace() ?? true)
        {
            throw new ArgumentNullException(
                $"{nameof(options)}.{nameof(options.CurrentValue)}.{nameof(options.CurrentValue.Secret)}"
            );
        }
        var jwtSecret = options?.CurrentValue?.Secret.ToUTF8Bytes();
        _jwtKey = new SymmetricSecurityKey(jwtSecret);
    }

    protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
    {
        if (Request.Headers.ContainsKey(AuthorizationHeaderName))
        {
            var authHeaderStringValue = Request.Headers[AuthorizationHeaderName].FirstOrDefault();

            if (authHeaderStringValue == null)
            {
                return AuthenticateResult.NoResult();
            }

            var authHeader = AuthenticationHeaderValue.Parse(
                Request.Headers[nameof(System.Net.Http.Headers.HttpRequestHeaders.Authorization)]
            );

            if (authHeader.Scheme.Equals(BasicSchemeName, OrdinalIgnoreCase))
            {
                var credentials = FromBase64String(
                        authHeader.Parameter[(BasicSchemeName.Length + 1)..]
                    )
                    .ToUTF8String()
                    .Split(':', 2);
                var username = credentials[0];
                var password = credentials[1];

                if (
                    await IsAuthenticated(
                        username,
                        password,
                        out var user,
                        out var ticket,
                        out var identity
                    )
                )
                {
                    return AuthenticateResult.Success(ticket);
                }
                else
                {
                    return AuthenticateResult.Fail("Invalid username or password");
                }
            }
            else if (authHeader.Scheme.Equals(BearerSchemeName, OrdinalIgnoreCase))
            {
                var token = authHeader.Parameter;
                var validationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = _jwtKey,
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidIssuers = new[] { DgmjrCt.BaseUri },
                    ValidAudiences = new[] { DgmjrCt.BaseUri },
                    ClockSkew = TimeSpan.Zero
                };

                try
                {
                    var handler = new JwtSecurityTokenHandler();
                    var claimsPrincipal = handler.ValidateToken(
                        token,
                        validationParameters,
                        out var securityToken
                    );
                    var authenticationTicket = new AuthenticationTicket(
                        claimsPrincipal,
                        Scheme.Name
                    );
                    return AuthenticateResult.Success(authenticationTicket);
                }
                catch (Exception ex)
                {
                    return AuthenticateResult.Fail(ex.Message);
                }
            }
        }

        return AuthenticateResult.NoResult();
    }

    private Task<bool> IsAuthenticated(
        string username,
        string password,
        out User? user,
        out AuthenticationTicket? ticket,
        out ClaimsIdentity? identity
    )
    {
        user = UserManager.FindByNameAsync(username).Result;
        if (user is not null && UserManager.CheckPasswordAsync(user, password).Result)
        {
            identity = new ClaimsIdentity(ApiAuthenticationOptions.BasicAuthenticationSchemeName);
            var userClaims = UserManager.GetClaimsAsync(user).Result;

            userClaims.Add(new(TelegramID.ClaimType.UserId.Uri, user.Id.ToString()));
            userClaims.Add(new(DgmjrCt.NameIdentifier, user.Id.ToString()));
            userClaims.Add(new(DgmjrCt.AuthenticationInstant, DateTimeOffset.UtcNow.ToString()));
            userClaims.Add(
                new(
                    DgmjrCt.AuthenticationMethod,
                    ApiAuthenticationOptions.BasicAuthenticationSchemeName
                )
            );
            userClaims.Add(
                new(
                    DgmjrCt.CommonName,
                    user.GoByName,
                    Options.Issuer,
                    Options.Audience,
                    TelegramID.ClaimType.BaseUri.Uri
                )
            );
            userClaims.Add(
                new(
                    DgmjrCt.GivenName,
                    user.GivenName,
                    Options.Issuer,
                    Options.Audience,
                    TelegramID.ClaimType.BaseUri.Uri
                )
            );
            userClaims.Add(
                new(
                    DgmjrCt.Surname,
                    user.Surname,
                    Options.Issuer,
                    Options.Audience,
                    TelegramID.ClaimType.BaseUri.Uri
                )
            );

            if (
                !IsNullOrEmpty(user.TelegramUsername)
                && !userClaims.Any(c => c.Type == TelegramID.ClaimType.Username.Uri)
            )
            {
                userClaims.Add(
                    new(
                        TelegramID.ClaimType.Username.Uri,
                        user.TelegramUsername,
                        Options.Issuer,
                        Options.Audience,
                        TelegramID.ClaimType.BaseUri.Uri
                    )
                );
            }

            if (user.Phone.HasValue && !userClaims.Any(c => c.Type == DgmjrCt.HomePhone))
            {
                userClaims.Add(
                    new(
                        DgmjrCt.HomePhone,
                        user.PhoneNumber,
                        Options.Issuer,
                        Options.Audience,
                        TelegramID.ClaimType.BaseUri.Uri
                    )
                );
            }

            if (user.EmailAddress.HasValue && !userClaims.Any(c => c.Type == DgmjrCt.Email))
            {
                userClaims.Add(
                    new(
                        DgmjrCt.Email,
                        user.EmailAddress,
                        Options.Issuer,
                        Options.Audience,
                        Options.Issuer
                    )
                );
            }

            identity.AddClaims(userClaims);
            var principal = new ClaimsPrincipal(identity);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = identity,
                Expires = UtcNow + Options.TokenLifetime,
            };
            ticket = new AuthenticationTicket(
                principal,
                ApiAuthenticationOptions.BasicAuthenticationSchemeName
            );
            Logger.LogUserAuthenticated(username, userClaims.Count);
            return Task.FromResult(true);
        }
        ticket = null;
        identity = null;
        return Task.FromResult(false);
    }
}
