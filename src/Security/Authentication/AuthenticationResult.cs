/*
 * AuthenticationResult.cs
 *
 *   Created: 2023-03-30-08:13:27
 *   Modified: 2023-03-30-08:13:27
 *
 *   Author: David G. Moore, Jr. <david@dgmjr.io>
 *
 *   Copyright © 2022 - 2023 David G. Moore, Jr., All Rights Reserved
 *      License: MIT (https://opensource.org/licenses/MIT)
 */

namespace Dgmjr.AspNetCore.Authentication.Enums
{
    [GenerateEnumerationRecordStruct(nameof(AuthenticationResult), "Dgmjr.AspNetCore.Authentication")]
    public enum AuthenticationResult
    {
        SuccessTokenIssued,
        SuccessTokenValidated,
        FailExpiredToken,
        FailInvalidToken,
        FailInvalidCredentials,
        FailInvalidUser,
        FailInvalidPassword,
        FailInvalidAuthHeader,
        FailUnknownReason
    }
}

namespace Dgmjr.AspNetCore.Authentication.Abstractions
{
    public partial interface IAuthenticationResult { }
}

namespace Dgmjr.AspNetCore.Authentication
{
    public partial record struct AuthenticationResult
    {
        public partial record struct SuccessTokenValidated : Abstractions.IAuthenticationResult
        {
            public string Token { get; init; }

            public static Abstractions.IAuthenticationResult WithToken(string token) =>
                new SuccessTokenValidated() with
                {
                    Token = token
                };
        }

        public partial record struct SuccessTokenIssued : Abstractions.IAuthenticationResult
        {
            public string Token { get; init; }

            public static Abstractions.IAuthenticationResult WithToken(string token) =>
                new SuccessTokenIssued() with
                {
                    Token = token
                };
        }
    }
}
