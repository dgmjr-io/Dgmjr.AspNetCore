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
using Dgmjr.AspNetCore.Authentication.Options;

public class JwtBearerBasicAuthHandler<TUser, TRole>
    : AuthenticationHandler<GeneratedAuthenticationSchemeOptions>
    where TUser : class, IIdentityUserBase, IHaveATelegramUsername, IIdentifiable
    where TRole : class, IIdentityRoleBase
{
    private const string AuthorizationHeaderName = HReqH.Authorization.Name;
    private const string BasicSchemeName = "Basic";
    private const string BearerSchemeName = "Bearer";
    protected virtual UserManager<TUser, TRole> UserManager { get; init; }

    private readonly SymmetricSecurityKey _jwtKey;

    public JwtBearerBasicAuthHandler(
        IOptionsMonitor<GeneratedAuthenticationSchemeOptions> options,
        ILoggerFactory logger,
        UrlEncoder encoder,
        ISystemClock clock,
        UserManager<TUser, TRole> userManager
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
        if (Request.Headers.TryGetValue(AuthorizationHeaderName, out var authHeaderStringValues))
        {
            var authHeaderStringValue = authHeaderStringValues.Join(",");
            if (authHeaderStringValue.IsNullOrWhitespace())
            {
                return AuthenticateResult.NoResult();
            }

            var authHeader = AuthenticationHeaderValue.Parse(authHeaderStringValue);

            if (authHeader.Scheme.Equals(BasicSchemeName, OrdinalIgnoreCase))
            {
                var credentials = authHeader.Parameter[(BasicSchemeName.Length + 1)..]
                    .FromBase64String()
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
                    ValidIssuers = new[] { DgmjrCt.DgmjrClaims.BaseUri },
                    ValidAudiences = new[] { DgmjrCt.DgmjrClaims.BaseUri },
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
        out TUser? user,
        out AuthenticationTicket? ticket,
        out ClaimsIdentity? identity
    )
    {
        user = UserManager.FindByNameAsync(username).Result;
        if (user is not null && UserManager.CheckPasswordAsync(user, password).Result)
        {
            identity = new ClaimsIdentity(ApiAuthenticationOptions.BasicAuthenticationSchemeName);
            var userClaims = UserManager.GetClaimsAsync(user).Result;

            userClaims.Add(new(TelegramID.ClaimTypes.UserId.UriString, user.Id.ToString()));
            userClaims.Add(new(DgmjrCt.NameIdentifier.UriString, user.Id.ToString()));
            userClaims.Add(
                new(DgmjrCt.AuthenticationInstant.UriString, DateTimeOffset.UtcNow.ToString())
            );
            userClaims.Add(
                new(
                    DgmjrCt.AuthenticationMethod.UriString,
                    ApiAuthenticationOptions.BasicAuthenticationSchemeName
                )
            );
            userClaims.Add(
                new(
                    DgmjrCt.CommonName.UriString,
                    user.GoByName,
                    Options.Issuer,
                    Options.Audience,
                    TelegramID.ClaimTypes.TelegramClaimBase.UriString
                )
            );
            userClaims.Add(
                new(
                    DgmjrCt.GivenName.UriString,
                    user.GivenName,
                    Options.Issuer,
                    Options.Audience,
                    TelegramID.ClaimTypes.TelegramClaimBase.UriString
                )
            );
            userClaims.Add(
                new(
                    DgmjrCt.Surname.UriString,
                    user.Surname,
                    Options.Issuer,
                    Options.Audience,
                    TelegramID.ClaimTypes.TelegramClaimBase.UriString
                )
            );

            if (
                !IsNullOrEmpty(user.TelegramUsername)
                && !userClaims.Any(c => c.Type == TelegramID.ClaimTypes.Username.UriString)
            )
            {
                userClaims.Add(
                    new(
                        TelegramID.ClaimTypes.Username.UriString,
                        user.TelegramUsername,
                        Options.Issuer,
                        Options.Audience,
                        TelegramID.ClaimTypes.TelegramClaimBase.UriString
                    )
                );
            }

            if (
                !user.PhoneNumber.IsEmpty
                && !userClaims.Any(c => c.Type == DgmjrCt.HomePhone.UriString)
            )
            {
                userClaims.Add(
                    new(
                        DgmjrCt.HomePhone.UriString,
                        user.PhoneNumber,
                        Options.Issuer,
                        Options.Audience,
                        TelegramID.ClaimTypes.TelegramClaimBase.UriString
                    )
                );
            }

            if (
                !user.EmailAddress.IsEmpty
                && !userClaims.Any(c => c.Type == DgmjrCt.Email.UriString)
            )
            {
                userClaims.Add(
                    new(
                        DgmjrCt.Email.UriString,
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
                Expires = datetime.UtcNow + Options.TokenLifetime,
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
