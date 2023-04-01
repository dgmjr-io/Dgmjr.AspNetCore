/* 
 * JwtExtensions.cs
 * 
 *   Created: 2023-03-29-04:05:26
 *   Modified: 2023-03-29-04:05:26
 * 
 *   Author: David G. Moore, Jr. <david@dgmjr.io>
 *   
 *   Copyright © 2022 - 2023 David G. Moore, Jr., All Rights Reserved
 *      License: MIT (https://opensource.org/licenses/MIT)
 */

namespace Dgmjr.AspNetCore.Authentication.JwtBearer;
using System.Buffers;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using static System.Text.Encoding;

public static class JwtExtensions
{
    public static AuthenticationBuilder AddJwtBearerAuthentication(this WebApplicationBuilder builder, Action<JwtBearerOptions> configureOptions)
    {
        return builder.Services.AddAuthentication(opts =>
        {
            opts.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            opts.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            opts.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
        })
        .AddJwtBearer(opts =>
        {
            configureOptions(opts);
            opts.SaveToken = true;
            opts.TokenValidationParameters = new TokenValidationParameters
            {
                ValidIssuer = builder.Configuration[$"{nameof(JwtConfigurationOptions)}:{nameof(JwtConfigurationOptions.Issuer)}"],
                ValidAudience = builder.Configuration[$"{nameof(JwtConfigurationOptions)}:{nameof(JwtConfigurationOptions.Audience)}"],
                IssuerSigningKey = new SymmetricSecurityKey(builder.Configuration[$"{nameof(JwtConfigurationOptions)}:{nameof(JwtConfigurationOptions.Secret)}"].ToUTF8Bytes()),
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateIssuerSigningKey = true
            };
        });
    }

    public static WebApplication UseJwtBearerAuthentication(this WebApplication app)
    {
        _ = app.MapGet("/auth/token", async context =>
        {



            var claims = new[]
            {
                new C(Ct.Name, "dgmjr"),
                new C(Ct.Role, "admin")
            };
            var key = new SymmetricSecurityKey(app.Configuration[$"{nameof(JwtConfigurationOptions)}:{nameof(JwtConfigurationOptions.Secret)}"].ToUTF8Bytes());
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                issuer: app.Configuration[$"{nameof(JwtConfigurationOptions)}:{nameof(JwtConfigurationOptions.Issuer)}"],
                audience: app.Configuration[$"{nameof(JwtConfigurationOptions)}:{nameof(JwtConfigurationOptions.Audience)}"],
                claims: claims,
                expires: Now.AddMinutes(value: 5252600),
                signingCredentials: creds
            );
            await context.Response.WriteAsync(new JwtSecurityTokenHandler().WriteToken(token));
        });
        app.UseAuthentication();
        return app;
    }
}
