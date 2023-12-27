// /*
//  * AddApiAuthentication.cs
//  *
//  *   Created: 2022-12-10-08:00:57
//  *   Modified: 2022-12-10-08:00:57
//  *
//  *   Author: David G. Moore, Jr, <david@dgmjr.io>
//  *
//  *   Copyright © 2022-2023 David G. Moore, Jr,, All Rights Reserved
//  *      License: MIT (https://opensource.org/licenses/MIT)
//  */
// #pragma warning disable
// using Dgmjr.AspNetCore.Authentication;
// using Dgmjr.AspNetCore.Authentication.Handlers;
// using Dgmjr.AspNetCore.Authentication.Options;
// using Dgmjr.Identity;
// using Dgmjr.Identity.Models;
// using Microsoft.AspNetCore.Authentication;
// using Microsoft.AspNetCore.Builder;
// using Microsoft.AspNetCore.Identity;
// using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
// using IdentityDbContext = Dgmjr.Identity.IdentityDbContext;

// namespace Microsoft.Extensions.DependencyInjection;

// public static class AddApiAuthenticationExtensions
// {
//     // /// <summary>Registers the API authentication middleware.</summary>
//     // public static WebApplicationBuilder AddApiAuthentication<TUser, TRole>(
//     //     this WebApplicationBuilder builder,
//     //     Action<IBasicAuthenticationSchemeOptions>? basicConfig = null,
//     //     Action<IJwtConfigurationOptions>? jwtConfig = null,
//     //     Action<ISharedSecretAuthenticationSchemeOptions>? sharedSecretConfig = null
//     // )
//     // {
//     //     builder.Services.AddScoped<IBasicApiAuthMiddleware, BasicApiAuthMiddleware<TUser, TRole>>();
//     //     builder.Services.AddAuthentication().AddApiBasicAuthentication();
//     //     return builder;
//     // }

//     public static AuthenticationBuilder AddApiBasicAuthentication<TUser, TRole>(
//         this AuthenticationBuilder builder
//     )
//         where TUser : class, IIdentityUserBase, IHaveATelegramUsername, IIdentifiable
//         where TRole : class, IIdentityRoleBase, IIdentifiable =>
//         builder.AddScheme<BasicAuthenticationSchemeOptions, BasicApiAuthHandler<TUser, TRole>>(
//             ApiAuthenticationOptions.BasicAuthenticationSchemeName,
//             ApiAuthenticationOptions.BasicAuthenticationSchemeName,
//             _ => { }
//         );

//     public static WebApplication UseApiBasicAuthentication<TUser, TRole>(this WebApplication app)
//         where TUser : class, IIdentityUserBase, IHaveATelegramUsername, IIdentifiable
//         where TRole : class, IIdentityRoleBase, IIdentifiable
//     {
//         // app.UseAuthentication();
//         // return app;
//         app.UseMiddleware<IBasicApiAuthMiddleware<TUser, TRole>>();
//         return app;
//     }
// }
