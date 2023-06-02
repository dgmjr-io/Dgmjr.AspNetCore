using System;
using System;
/* 
 * ApiAuthenticationExtensions.cs
 * 
 *   Created: 2023-03-29-11:16:18
 *   Modified: 2023-03-29-11:16:19
 * 
 *   Author: David G. Moore, Jr. <david@dgmjr.io>
 *   
 *   Copyright © 2022 - 2023 David G. Moore, Jr., All Rights Reserved
 *      License: MIT (https://opensource.org/licenses/MIT)
 */

using System.IdentityModel.Tokens.Jwt;
using System.Net.Http.Headers;
using System.Text;
using Dgmjr.AspNetCore.Authentication.JwtBearer;
using Dgmjr.Identity;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;

namespace Dgmjr.AspNetCore.Authentication;

public class ApiAuthenticationExtensions : ILog
{
    public const string Basic = nameof(Basic);
    public const string Bearer = nameof(Bearer);

    public ILogger Logger { get; }
    public IConfiguration Configuration { get; }
    public UserManager UserManager { get; }

    public ApiAuthenticationExtensions(ILogger<ApiAuthenticationExtensions> logger, IConfiguration config, UserManager userManager)
    {
        Logger = logger;
        Configuration = config;
        UserManager = userManager;
    }

    public JwtConfigurationOptions GetJwtConfigurationOptions()
    {
        var jwtConfig = new JwtConfigurationOptions();
        Configuration.GetSection(nameof(JwtConfigurationOptions)).Bind(jwtConfig);
        return jwtConfig;
    }

    public TokenValidationParameters GetTokenValidationParameters()
    {
        var jwtConfig = GetJwtConfigurationOptions();
        return new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(jwtConfig.Secret.ToUTF8Bytes()),
            ValidateIssuer = true,
            ValidIssuer = jwtConfig.Issuer,
            ValidateAudience = true,
            ValidAudience = jwtConfig.Audience,
            ValidateLifetime = true,
            ClockSkew = TimeSpan.Zero,
            RequireExpirationTime = true
        };
    }

    public async Task<AuthenticationResult> AuthenticateAsync(HttpContext context)
    {
        var jwtConfig = GetJwtConfigurationOptions();
        var tokenHandler = new JwtSecurityTokenHandler();
        Logger.LogBeginAuthentication(
            context.TraceIdentifier,
            context.Request.Path,
            context.Request.Method
        );
        try
        {
            var authHeader = AuthenticationHeaderValue.Parse(
                context.Request.Headers["Authorization"]
            );
            switch (authHeader.Scheme)
            {
                case Basic:
                    var credentialBytes = authHeader.Parameter.FromBase64String();
                    var credentials = credentialBytes.ToUTF8String().Split(':', 2);
                    var authUsername = credentials[0];
                    var authPassword = credentials[1];
                    Logger.LogAuthenticatingUser(authUsername);

                    // authenticate credentials with user service and attach user to http context
                    var user = await UserManager.FindByNameAsync(authUsername);
                    if (user is not null && await UserManager.CheckPasswordAsync(user, authPassword))
                    {
                        var identity = new ClaimsIdentity(
                        ApiAuthenticationOptions.BasicAuthenticationSchemeName
                    );
                        var userClaims = await UserManager.GetClaimsAsync(user);

                        userClaims.Add(new(TelegramID.ClaimType.UserId.Uri, user.Id.ToString()));
                        userClaims.Add(new(DgmjrCt.NameIdentifier, user.Id.ToString()));
                        userClaims.Add(new(DgmjrCt.AuthenticationInstant, DateTimeOffset.UtcNow.ToString()));
                        userClaims.Add(
                            new(
                                DgmjrCt.AuthenticationMethod,
                                ApiAuthenticationOptions.BasicAuthenticationSchemeName
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
                            Audience = jwtConfig.Audience,
                            Issuer = jwtConfig.Issuer,
                            IssuedAt = UtcNow,
                            NotBefore = UtcNow,
                            Expires = UtcNow + jwtConfig.TokenLifetime,
                        };
                        var token = tokenHandler.CreateToken(tokenDescriptor);
                        var tokenString = tokenHandler.WriteToken(token);
                        return AuthenticationResult.Success(tokenString);
                    }
                    else
                    {
                        Logger.UserAuthenticationFailed(authUsername);
                        return AuthenticationResult.FailInvalidPassword.Instance;
                    }
                case Bearer:
                    if (tokenHandler.CanReadToken(authHeader.Parameter))
                    {
                        var tokenValidationParameters = GetTokenValidationParameters();
                        var principal = tokenHandler.ValidateToken(
                            authHeader.Parameter,
                            tokenValidationParameters,
                            out var validatedToken
                        );
                        var jwtToken = (JwtSecurityToken)validatedToken;
                        var username = jwtToken.Claims.First(
                            x => x.Type == Telegram.Identity.ClaimType.Username.Uri
                        )?.Value;
                        if (jwtToken.IssuedAt + jwtConfig.TokenLifetime > UtcNow)
                        {
                            Logger.LogExpiredToken(context.TraceIdentifier, username, jwtToken.IssuedAt, jwtToken.IssuedAt + jwtConfig.TokenLifetime, UtcNow);
                            // context.Response.Headers["WWW-Authenticate"] = "Bearer";
                            // context.Response.StatusCode = (int)Unauthorized;
                            return AuthenticationResult.FailExpiredToken.Instance;
                        }
                        Logger.LogUserAuthenticated(username, jwtToken.Claims.Count());
                        context.User = principal;

                    }
                    else
                    {
                        Logger.LogInvalidAuthHeader(context.TraceIdentifier);
                        return AuthenticationResult.FailInvalidAuthHeader.Instance;
                    };
                    break;
                default:
                    return AuthenticationResult.FailInvalidAuthHeader.Instance;
            }
        }
        catch
        {
            Logger.LogInvalidAuthHeader(context.TraceIdentifier);
            return AuthenticationResult.FailInvalidAuthHeader.Instance;
        }
        return AuthenticationResult.FailUnknownReason.Instance;
    }
}
