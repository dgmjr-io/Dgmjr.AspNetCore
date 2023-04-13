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
    public const string ApiAuthenticationSchemeName = "Api";
    public const string ApiAuthenticationSchemeDisplayName = "API Combined Auhentication";
    public const string BasicAuthenticationSchemeName = "Basic";
    public const string BasicAuthenticationSchemeDisplayName = "Basic Authentication with username and password";
    public const string BearerAuthenticationSchemeName = JwtBearerDefaults.AuthenticationScheme;
    public const string BearerAuthenticationSchemeDisplayName = JwtBearerDefaults.AuthenticationScheme;
    public const string SharedSecretAuthenticationSchemeName = "SharedSecret";
    public const string SharedSecretAuthenticationSchemeDisplayName = "Shared Secret";
}
