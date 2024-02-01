namespace Dgmjr.AspNetCore.Authentication.Basic;

using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

using System.Collections;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

public class BasicAuthenticationWithUsersHandler(
    IOptionsMonitor<BasicAuthenticationWithUsersOptions> options,
    ILoggerFactory loggerFactory,
    UrlEncoder urlEncoder,
    ISystemClock clock
)
    : BasicAuthenticationHandler<BasicAuthenticationWithUsersOptions>(
        options,
        loggerFactory,
        urlEncoder,
        clock
    )
{
    private ICollection<UsernameAndPassword> Users => Options.Users;

    protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
    {
        var authHeader = Request.Headers[HReqH.Authorization.DisplayName].FirstOrDefault();
        if (authHeader == null)
        {
            return AuthenticateResult.NoResult();
        }

        var authHeaderVal = AuthenticationHeaderValue.Parse(authHeader);
        if (
            !authHeaderVal.Scheme.Equals(
                BasicAuthenticationWithUsersDefaults.AuthenticationScheme,
                OrdinalIgnoreCase
            )
        )
        {
            return AuthenticateResult.NoResult();
        }

        var credentialBytes = Convert.FromBase64String(authHeaderVal.Parameter);
        var credentials = Encoding.UTF8.GetString(credentialBytes).Split(':', 2);
        if (credentials.Length != 2)
        {
            return AuthenticateResult.Fail("Invalid Basic authentication header");
        }

        var (username, password) = (credentials[0], credentials[1]);
        if (!Users.Any(u => u.Username == username && u.Password == password))
        {
            return AuthenticateResult.Fail("Invalid username or password");
        }

        return await Task.FromResult(
            AuthenticateResult.Success(
                new AuthenticationTicket(
                    new ClaimsPrincipal(
                        new ClaimsIdentity(
                            new[] { new Claim(ClaimTypes.Name, username) },
                            BasicAuthenticationWithUsersDefaults.AuthenticationScheme
                        )
                    ),
                    BasicAuthenticationWithUsersDefaults.AuthenticationScheme
                )
            )
        );
    }
}
