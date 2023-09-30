/*
 * Constants.cs
 *
 *   Created: 2023-04-02-06:13:16
 *   Modified: 2023-04-02-06:13:16
 *
 *   Author: David G. Moore, Jr. <david@dgmjr.io>
 *
 *   Copyright © 2022 - 2023 David G. Moore, Jr., All Rights Reserved
 *      License: MIT (https://opensource.org/licenses/MIT)
 */

using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace Dgmjr.AspNetCore.Authentication;

public static class Constants
{
    public static class AuthenticationSchemes
    {
        public static class Api
        {
            public const string Name = "Api";
            public const string DisplayName = "API Combined Auhentication";
        }

        public static class Basic
        {
            public const string Name = "Basic";
            public const string DisplayName = "Basic Authentication with username and password";
        }

        public static class Bearer
        {
            public const string Name = JwtBearerDefaults.AuthenticationScheme;
            public const string DisplayName = JwtBearerDefaults.AuthenticationScheme;
        }

        public static class JwtBearer
        {
            public const string Name = nameof(JwtBearer);
            public const string DisplayName = nameof(JwtBearer);
        }

        public static class SharedSecret
        {
            public const string Name = "SharedSecret";
            public const string DisplayName = "Shared Secret";
        }

        public static class Cookies
        {
            public const string Name = Microsoft
                .AspNetCore
                .Authentication
                .Cookies
                .CookieAuthenticationDefaults
                .AuthenticationScheme;
            public const string DisplayName = Microsoft
                .AspNetCore
                .Authentication
                .Cookies
                .CookieAuthenticationDefaults
                .AuthenticationScheme;
        }

        public static class OAuth
        {
            public const string Name = nameof(OAuth);
            public const string DisplayName = nameof(OAuth);
        }
    }
}
