namespace Dgmjr.AzureAdB2C.Services;

using System.Security.Claims;

using Microsoft.AspNetCore.Http;

public interface IUserHydrator
{
    Task<ClaimsPrincipal> HydrateAsync(HttpContext context, ClaimsPrincipal principal, CancellationToken cancellationToken = default);
}

public class UserHydrator : IUserHydrator
{
    public virtual Task<ClaimsPrincipal> HydrateAsync(
        HttpContext context,
        ClaimsPrincipal principal,
        CancellationToken cancellationToken = default
    )
    {

        return Task.FromResult(principal);
    }
}
