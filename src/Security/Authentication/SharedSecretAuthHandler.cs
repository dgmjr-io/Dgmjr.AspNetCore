// /*
//  * SharedSecretAuthHandler.cs
//  *
//  *   Created: 2022-12-31-05:06:39
//  *   Modified: 2022-12-31-05:07:21
//  *
//  *   Author: David G. Moore, Jr, <david@dgmjr.io>
//  *
//  *   Copyright © 2022-2023 David G. Moore, Jr,, All Rights Reserved
//  *      License: MIT (https://opensource.org/licenses/MIT)
//  */

// namespace Dgmjr.AspNetCore.Authorization;

// using System.Net.Http.Headers;
// using System.Security.Claims;
// using System.Text.Encodings.Web;
// using Dgmjr.Abstractions;
// using Dgmjr.Identity;
// using Microsoft.AspNetCore.Authentication;
// using Microsoft.AspNetCore.Http;
// using Microsoft.Extensions.Logging;
// using Microsoft.Extensions.Options;
// using static System.Text.TextEncodingExtensions;

// using ClaimTypes = DgmjrCt;

// public class SharedSecretAuthHandler : AuthenticationHandler<SharedSecretAuthenticationOptions>, IHttpContextAccessor, ILog
// {
//     public new ILogger Logger { get; init; }
//     private readonly UserManager _userManager;
//     private readonly SharedSecretAuthenticationOptions _options;
//     public HttpContext? HttpContext { get => Request.HttpContext; set { } }

//     public SharedSecretAuthHandler(IOptionsMonitor<SharedSecretAuthenticationOptions> options, ILoggerFactory logger, UrlEncoder encoder, ISystemClock clock, UserManager userManager) : base(options, logger, encoder, clock)
//     {
//         _userManager = userManager;
//         _options = options.CurrentValue;
//         Logger = logger.CreateLogger<SharedSecretAuthHandler>();
//     }

//     protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
//     {
//         try
//         {
//             var authHeader = AuthenticationHeaderValue.Parse(Request.Headers[HttpRequestHeaderNames.Authorization]);
//             var credentialBytes = FromBase64String(authHeader.Parameter);
//             var credentials = GetUTF8String(credentialBytes).Split(':', 2);
//             var authUsername = credentials[0];
//             var authSecret = credentials[1];
//             Logger.AuthenticatingUser(authUsername);

//             // authenticate credentials with user service and attach user to http context
//             var user = await _userManager.FindByNameAsync(authUsername);
//             if (user is not null && authSecret == _options.Secret && (await _userManager.GetClaimsAsync(user)).Any(c => c.Type == DgmjrCt.Role && DgmjrR.AnonymousUser).Count > 0)
//             {
//                 var identity = new ClaimsIdentity(SharedSecretAuthenticationOptions.AuthenticationSchemeName);
//                 var userClaims = await _userManager.GetClaimsAsync(user);

//                 userClaims.Add(new(TelegramID.Username, user.TelegramUsername));
//                 userClaims.Add(new(TelegramID.UserId, user.Id.ToString()));
//                 if (!IsNullOrEmpty(user.Email))
//                 {
//                     userClaims.Add(new(ClaimTypes.Email, user.Email));
//                 }

//                 identity.AddClaims(userClaims);
//                 var principal = new ClaimsPrincipal(identity);
//                 var ticket = new AuthenticationTicket(principal, SharedSecretAuthenticationOptions.AuthenticationSchemeName);
//                 Logger.UserAuthenticated(authUsername, userClaims.Count);
//                 return AuthenticateResult.Success(ticket);
//             }
//             else if (user is null)
//             {
//                 Logger.UserAuthenticationFailed(authUsername);
//                 return AuthenticateResult.Fail("Invalid username or password.");
//             }
//             {
//                 var identity = new ClaimsIdentity(ApiBasicAuthenticationOptions.AuthenticationSchemeName);
//                 var userClaims = await _userManager.GetClaimsAsync(user);

//                 userClaims.Add(new(TelegramID.Username, user.TelegramUsername));
//                 userClaims.Add(new(TelegramID.UserId, user.Id.ToString()));
//                 if (!IsNullOrEmpty(user.Email))
//                 {
//                     userClaims.Add(new(ClaimTypes.Email, user.Email));
//                 }

//                 identity.AddClaims(userClaims);
//                 var principal = new ClaimsPrincipal(identity);
//                 var ticket = new AuthenticationTicket(principal, ApiBasicAuthenticationOptions.AuthenticationSchemeName);
//                 Logger.UserAuthenticated(authUsername, userClaims.Count);
//                 return AuthenticateResult.Success(ticket);
//             }
//             else if (user is null)
//             {
//                 Logger.UserAuthenticationFailed(authUsername);
//                 return AuthenticateResult.Fail("Invalid username or password.");
//             }
//             Logger.UserAuthenticationFailed(authUsername);
//             return AuthenticateResult.Fail("An unknown error occurred while authenticating the user.");
//         }
//         catch(Exception ex)
//         {
//             Logger.LogError(ex, "An error occurred while authenticating the user.");
//             return AuthenticateResult.Fail("An error occurred while authenticating the user.");
//         }
//     }

//     // public async Task<IAuthenticationHandler?> GetHandlerAsync(HttpContext context, string authenticationScheme)
//     // {
//     //     if (authenticationScheme == ApiBasicAuthenticationOptions.AuthenticationSchemeName)
//     //     {
//     //         await InitializeAsync(new AuthenticationScheme(authenticationScheme, authenticationScheme, GetType()), context);
//     //         return this;
//     //     }
//     //     return null;
//     // }

//     // public Task InitializeAsync(AuthenticationScheme scheme, HttpContext context)
//     // {
//     //     HttpContext = context;
//     //     return Task.CompletedTask;
//     // }
//     // public Task<AuthenticateResult> AuthenticateAsync() => HandleAuthenticateAsync();
//     // public Task ChallengeAsync(AuthenticationProperties? properties)
//     // {
//     //     HttpContext.Response.StatusCode = 401;
//     //     HttpContext.Response.Headers["WWW-Authenticate"] = "Basic";
//     //     return Task.CompletedTask;
//     // }
//     // public Task ForbidAsync(AuthenticationProperties? properties)
//     // {
//     //     HttpContext.Response.StatusCode = 403;
//     //     return Task.CompletedTask;
//     // }
// }
