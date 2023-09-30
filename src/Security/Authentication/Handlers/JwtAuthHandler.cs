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
using Dgmjr.Identity.Abstractions;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;

public class JwtAuthHandler<TUser, TRole> : JwtBearerHandler, IHttpContextAccessor, ILog
    where TUser : class, IIdentityUserBase, IHaveATelegramUsername, IIdentifiable
    where TRole : class, IIdentityRoleBase
{
    public IConfiguration Configuration { get; }
    public new ILogger Logger { get; }
    private readonly UserManager<TUser, TRole> _userManager;
    private readonly JwtConfigurationOptions _options;
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
        UserManager<TUser, TRole> userManager,
        IConfiguration configuration
    )
        : base(options, logger, encoder, clock)
    {
        _userManager = userManager;
        _options = options.CurrentValue;
        Logger = logger.CreateLogger<JwtAuthHandler<TUser, TRole>>();
        Configuration = configuration;
    }

    protected virtual string? AuthenticationSchemeName => _options?.AuthenticationSchemeName;

    protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
    {
        try
        {
            var authHeader = AuthenticationHeaderValue.Parse(
                Request.Headers[nameof(HttpRequestHeaders.Authorization)]
            );
            var authUsername = authHeader.Parameter.Split(':')[0];
            var authPassword = authHeader.Parameter.Split(':')[1].FromBase64String().ToUTF8String();
            // opts.TokenValidationParameters = new TokenValidationParameters
            // {
            //     ValidIssuer = _options?.ClaimsIssuer ?? DgmjrCt.DgmjrClaims.BaseUri,
            //     ValidAudience = Configuration[
            //         $"{nameof(JwtConfigurationOptions)}:{nameof(JwtConfigurationOptions.Audience)}"
            //     ],
            //     IssuerSigningKey = new SymmetricSecurityKey(
            //         Configuration[
            //             $"{nameof(JwtConfigurationOptions)}:{nameof(JwtConfigurationOptions.Secret)}"
            //         ].ToUTF8Bytes()
            //     ),
            //     ValidateIssuer = true,
            //     ValidateAudience = true,
            //     ValidateIssuerSigningKey = true
            // };
            Logger.LogAuthenticatingUser(authUsername, nameof(JwtAuthHandler<TUser, TRole>));

            // authenticate credentials with user service and attach user to http context
            var user = await _userManager.FindByNameAsync(authUsername);
            if (user is not null && await _userManager.CheckPasswordAsync(user, authPassword))
            {
                var identity = new ClaimsIdentity(AuthenticationSchemeName);
                var userClaims = await _userManager.GetClaimsAsync(user);

                userClaims.Add(new(TelegramID.ClaimTypes.UserId.UriString, user.Id.ToString()));
                userClaims.Add(new(DgmjrCt.NameIdentifier.UriString, user.Id.ToString()));
                userClaims.Add(
                    new(DgmjrCt.AuthenticationInstant.UriString, DateTimeOffset.UtcNow.ToString())
                );
                userClaims.Add(
                    new(DgmjrCt.AuthenticationMethod.UriString, AuthenticationSchemeName)
                );
                userClaims.Add(new(DgmjrCt.CommonName.UriString, user.GoByName));
                userClaims.Add(new(DgmjrCt.GivenName.UriString, user.GivenName));
                userClaims.Add(new(DgmjrCt.Surname.UriString, user.Surname));

                if (
                    !IsNullOrEmpty(user.TelegramUsername)
                    && !userClaims.Any(c => c.Type == TelegramID.ClaimTypes.Username.UriString)
                )
                {
                    userClaims.Add(
                        new(TelegramID.ClaimTypes.Username.UriString, user.TelegramUsername)
                    );
                }

                if (
                    !user.PhoneNumber.IsEmpty
                    && !userClaims.Any(c => c.Type == DgmjrCt.HomePhone.UriString)
                )
                {
                    userClaims.Add(new(DgmjrCt.HomePhone.UriString, user.PhoneNumber));
                }

                if (
                    !user.EmailAddress.IsEmpty
                    && !userClaims.Any(c => c.Type == DgmjrCt.Email.UriString)
                )
                {
                    userClaims.Add(new(DgmjrCt.Email.UriString, user.EmailAddress));
                }

                identity.AddClaims(userClaims);
                var principal = new ClaimsPrincipal(identity);
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = identity,
                    Expires = datetime.UtcNow + _options.TokenLifetime,
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
