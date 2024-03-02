namespace Dgmjr.Blazor.Security;

public static class BlazorSecurityConstants
{
    public const string BlazorSecurity = nameof(BlazorSecurity);
}

public static class Uris
{
    public const string AccountController = "/account";
    public const string Login = $"{AccountController}/login";
    public const string Logout = $"{AccountController}/logout";
    public const string CurrentUser = $"{AccountController}/current-user";
}
