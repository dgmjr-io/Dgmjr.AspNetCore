// /*
//  * BasicApiAuthMiddleware.cs
//  *
//  *   Created: 2022-12-14-05:48:24
//  *   Modified: 2022-12-14-05:48:25
//  *
//  *   Author: David G. Moore, Jr, <david@dgmjr.io>
//  *
//  *   Copyright © 2022-2023 David G. Moore, Jr,, All Rights Reserved
//  *      License: MIT (https://opensource.org/licenses/MIT)
//  */

// namespace Dgmjr.AspNetCore.Authentication.Middlewares;

// using System.Net.Http.Headers;
// using System.Security.Claims;
// using System.Text;
// using Dgmjr.Abstractions;
// using Dgmjr.AspNetCore.Authentication.Handlers;
// using Dgmjr.AspNetCore.Authentication.Options;
// using Dgmjr.Identity;
// using Microsoft.AspNetCore.Authentication;
// using Microsoft.AspNetCore.Http;
// using Microsoft.Extensions.Logging;
// using Microsoft.Extensions.Options;
// using Microsoft.IdentityModel.Tokens;

// public class BasicApiAuthMiddleware : AuthMiddlewareBase<BasicApiAuthHandler, BasicAuthenticationSchemeOptions>, IBasicApiAuthMiddleware, ILog
// {
//     public UserManager UserManager { get; }

//     public ILogger Logger { get; init; }

//     public BasicApiAuthMiddleware(IOptions<BasicAuthenticationSchemeOptions> options, UserManager userManager, ILogger<BasicApiAuthMiddleware> logger)
//     {
//         UserManager = userManager;
//         Logger = logger;
//     }

//     protected string? AuthenticationSchemeName => _options?.CurrentValue.AuthenticationSchemeName;


//     public override async Task HandleAuthenticateOnceAsync(HttpContext context, RequestDelegate next)
//     {
//         var authHeader = AuthenticationHeaderValue.Parse(
//             context.Request.Headers[nameof(HttpRequestHeaders.Authorization)]
//         );
//         var credentialBytes = authHeader.Parameter.FromBase64String();
//         var credentials = credentialBytes.ToUTF8String().Split(':', 2);
//         var authUsername = credentials[0];
//         var authPassword = credentials[1];
//         Logger.LogAuthenticatingUser(authUsername);

//         // authenticate credentials with user service and attach user to http context
//         var user = await UserManager.FindByNameAsync(authUsername);
//         if (user is not null && await UserManager.CheckPasswordAsync(user, authPassword))
//         {
//             var identity = new ClaimsIdentity(
//                 AuthenticationSchemeName
//             );
//             var userClaims = await UserManager.GetClaimsAsync(user);

//             userClaims.Add(new(TelegramID.ClaimType.UserId.Uri, user.Id.ToString()));
//             userClaims.Add(new(DgmjrCt.NameIdentifier, user.Id.ToString()));
//             userClaims.Add(new(DgmjrCt.AuthenticationInstant, DateTimeOffset.UtcNow.ToString()));
//             userClaims.Add(
//                 new(
//                     type: DgmjrCt.AuthenticationMethod,
//                     AuthenticationSchemeName
//                 )
//             );
//             userClaims.Add(new(DgmjrCt.CommonName, user.GoByName));
//             userClaims.Add(new(DgmjrCt.GivenName, user.GivenName));
//             userClaims.Add(new(DgmjrCt.Surname, user.Surname));

//             if (
//                 !IsNullOrEmpty(user.TelegramUsername)
//                 && !userClaims.Any(c => c.Type == TelegramID.ClaimType.Username.Uri)
//             )
//             {
//                 userClaims.Add(new(TelegramID.ClaimType.Username.Uri, user.TelegramUsername));
//             }

//             if (user.Phone.HasValue && !userClaims.Any(c => c.Type == DgmjrCt.HomePhone))
//             {
//                 userClaims.Add(new(DgmjrCt.HomePhone, user.PhoneNumber));
//             }

//             if (user.EmailAddress.HasValue && !userClaims.Any(c => c.Type == DgmjrCt.Email))
//             {
//                 userClaims.Add(new(DgmjrCt.Email, user.EmailAddress));
//             }

//             identity.AddClaims(userClaims);
//             var principal = new ClaimsPrincipal(identity);
//             var tokenDescriptor = new SecurityTokenDescriptor
//             {
//                 Subject = identity,
//                 Expires = UtcNow + _options.TokenLifetime,
//             };
//             var ticket = new AuthenticationTicket(
//                 principal,
//                 AuthenticationSchemeName
//             );
//             Logger.LogUserAuthenticated(authUsername, userClaims.Count);
//             return AuthenticateResult.Success(ticket);
//         }
//         else if (user is null)
//         {
//             Logger.UserAuthenticationFailed(authUsername);
//         }
//         Logger.UserAuthenticationFailed(authUsername);
//         );
//     }
//         catch (Exception ex)
//         {
//             Logger.LogError(ex, "An error occurred while authenticating the user.");
//         }
//         await next(context);
//     }

//     public virtual Task HandleChallengeAsync(HttpContext context)
//     {
//         context.Response.StatusCode = 401;
//         context.Response.Headers["WWW-Authenticate"] = "Basic";
//         return Task.CompletedTask;
//     }
// }
