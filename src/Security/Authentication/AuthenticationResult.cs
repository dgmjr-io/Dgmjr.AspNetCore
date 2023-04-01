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

    [GenerateEnumerationClass(nameof(AuthenticationResult), "Dgmjr.AspNetCore.Authentication")]
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

namespace Dgmjr.AspNetCore.Authentication
{
    public partial class AuthenticationResult
    {
        public AuthenticationResult(Enums.AuthenticationResult result, string? token = default)
        {
            Value = result;
            Token = token;
        }

        public static AuthenticationResult Success(string token) => new (Enums.AuthenticationResult.SuccessTokenIssued, token);

        public string Token { get; set; }

        public virtual bool Equals(AuthenticationResult? other)
        {
            if (other is null)
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return Value == other.Value && Token == other.Token;
        }

        public override int GetHashCode()
        {
            return (Value + Token).GetHashCode();
        }
    }
}
