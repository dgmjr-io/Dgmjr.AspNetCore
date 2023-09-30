// /*
//  * ApiAuthorizationServerProvider.cs
//  *
//  *   Created: 2022-12-10-07:18:59
//  *   Modified: 2022-12-10-07:18:59
//  *
//  *   Author: David G. Moore, Jr, <david@dgmjr.io>
//  *
//  *   Copyright © 2022-2023 David G. Moore, Jr,, All Rights Reserved
//  *      License: MIT (https://opensource.org/licenses/MIT)
//  */
// #pragma warning disable
// namespace Dgmjr.AspNetCore.Authentication;

// using System.Net.Http.Headers;
// using System.Security.Claims;
// using System.Text;
// using System.Text.Encodings.Web;
// using System.Text.RegularExpressions;
// using Dgmjr.Identity;
// using Dgmjr.Identity.Models;
// using Microsoft.AspNetCore.Authentication;
// using Microsoft.AspNetCore.Http;
// using Microsoft.AspNetCore.Identity;
// using Microsoft.AspNetCore.Mvc;
// using Microsoft.AspNetCore.Mvc.Infrastructure;
// using Microsoft.Extensions.Logging;
// using Microsoft.Extensions.Options;

// public class ApiKeyAuthenticationHandler : AuthenticationHandler<ApiBasicAuthenticationOptions>
// {
//     private readonly UserManager<User> _userManager;

//     public ApiKeyAuthenticationHandler(
//         IOptionsMonitor<ApiBasicAuthenticationOptions> options,
//         ILoggerFactory logger,
//         UrlEncoder encoder,
//         ISystemClock clock,
//         UserManager<User> userManager
//     ) : base(options, logger, encoder, clock)
//     {
//         _userManager = userManager;
//     }

//     protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
//     {
//         if (
//             Request.Path.StartsWithSegments("/swagger")
//             || Request.Path.StartsWithSegments("/api-docs")
//             || Request.Path.StartsWithSegments("/api-docs.json")
//         )
//             return AuthenticateResult.NoResult();
//         else if (
//             Request.Path.StartsWithSegments("/api")
//             && Request.Method.Equals(
//                 HttpRequestMethodNames.Options,
//                 StringComparison.InvariantCultureIgnoreCase
//             )
//         )
//             return AuthenticateResult.NoResult();
//         if (Request.Headers.TryGetValue(HttpRequestHeaderNames.Authorization, out var authHeader))
//         {
//             var authHeaderVal = Regex.Replace(
//                 authHeader.ToString(),
//                 "Basic ",
//                 "",
//                 RegexOptions.IgnoreCase
//             );
//             var authHeaderValDecoded = System.Text.Encoding.UTF8.GetString(
//                 FromBase64String(authHeaderVal)
//             );
//             var authUsername = authHeaderVal.Substring(0, authHeaderValDecoded.IndexOf(':'));
//             var authPassword = authHeaderVal.Substring(authHeaderValDecoded.IndexOf(':') + 1);
//             var user = await _userManager.FindByNameAsync(authUsername);
//             if (user != null && await _userManager.CheckPasswordAsync(user, authPassword))
//             {
//                 var identity = new ClaimsIdentity(
//                     ApiBasicAuthenticationOptions.AuthenticationSchemeName
//                 );
//                 var userClaims = await _userManager.GetClaimsAsync(user);
//                 identity.AddClaims(userClaims);
//                 var principal = new ClaimsPrincipal(identity);
//                 var ticket = new AuthenticationTicket(
//                     principal,
//                     ApiBasicAuthenticationOptions.AuthenticationSchemeName
//                 );
//                 Context.User = principal;
//                 await Context.SignInAsync(
//                     ApiBasicAuthenticationOptions.AuthenticationSchemeName,
//                     principal
//                 );
//                 return AuthenticateResult.Success(ticket);
//             }
//             else
//             {
//                 Response.StatusCode = 401;
//                 return AuthenticateResult.Fail("Invalid username or password");
//             }
//         }
//         return AuthenticateResult.Fail("No Authorization header found");

//         //     var identity = new ClaimsIdentity(ApiKeyAuthenticationOptions.AuthenticationSchemeName);
//         //     identity.AddClaim(new Claim(ClaimTypes.Role, "user"));
//         //     identity.AddClaim(new Claim("username", "user"));
//         //     identity.AddClaim(new Claim(ClaimTypes.Name, "Hi User"));
//         //     var principal = new ClaimsPrincipal(identity);
//         //     var ticket = new AuthenticationTicket(principal, ApiKeyAuthenticationOptions.AuthenticationSchemeName);
//         //     Context.User = principal;
//         //     await Context.SignInAsync(ApiKeyAuthenticationOptions.AuthenticationSchemeName, principal);
//         //     return AuthenticateResult.Success(ticket);
//         // }
//         // else if(Request.Headers.TryGetValue(ApiKeyAuthenticationOptions.AdminHeaderName, out var adminApiKey) && adminApiKey == Options.AdminApiKey)
//         // {
//         //     var identity = new ClaimsIdentity(ApiKeyAuthenticationOptions.AuthenticationSchemeName);
//         //     identity.AddClaim(new Claim(ClaimTypes.Role, "admin"));
//         //     identity.AddClaim(new Claim("username", "admin"));
//         //     identity.AddClaim(new Claim(ClaimTypes.Name, "Hi Admin"));
//         //     var principal = new ClaimsPrincipal(identity);
//         //     var ticket = new AuthenticationTicket(principal, ApiKeyAuthenticationOptions.AuthenticationSchemeName);
//         //     Context.User = principal;
//         //     await Context.SignInAsync(ApiKeyAuthenticationOptions.AuthenticationSchemeName, principal);
//         //     return AuthenticateResult.Success(ticket);
//         // }
//         // else if(!IsNullOrEmpty(apiKey.ToString()) || !IsNullOrEmpty(adminApiKey.ToString()))
//         // {
//         //     Response.StatusCode = 401;
//         //     return AuthenticateResult.Fail("Invalid API Key");
//         // }
//         // Response.StatusCode = 401;
//         // return AuthenticateResult.Fail("Missing API Key");
//     }
// }
