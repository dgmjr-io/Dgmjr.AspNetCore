namespace Dgmjr.AspNetCore.Authentication.Basic;

using System.Collections;

using Microsoft.AspNetCore.Authentication;

public class BasicAuthenticationWithUsersOptions : AuthenticationSchemeOptions
{
    public const string ConfigurationKey = $"{nameof(Authentication)}:{nameof(Basic)}";

    public BasicAuthenticationWithUsersOptions()
    {
        ForwardAuthenticate = BasicAuthenticationWithUsersDefaults.AuthenticationScheme;
        ForwardChallenge = BasicAuthenticationWithUsersDefaults.AuthenticationScheme;
        ForwardForbid = BasicAuthenticationWithUsersDefaults.AuthenticationScheme;
        ForwardSignIn = BasicAuthenticationWithUsersDefaults.AuthenticationScheme;
        ForwardSignOut = BasicAuthenticationWithUsersDefaults.AuthenticationScheme;
        ClaimsIssuer = BasicAuthenticationWithUsersDefaults.AuthenticationScheme;
        ForwardDefault = BasicAuthenticationWithUsersDefaults.AuthenticationScheme;
        ForwardDefaultSelector = context =>
            BasicAuthenticationWithUsersDefaults.AuthenticationScheme;
    }

    public ICollection<UsernameAndPassword> Users { get; set; } = new List<UsernameAndPassword>();
}

public class UsernameAndPassword
{
    public string Username { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
}
