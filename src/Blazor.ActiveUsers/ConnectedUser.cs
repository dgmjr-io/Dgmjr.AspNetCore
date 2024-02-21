namespace Dgmjr.Blazor.ActiveUsers;
using System.Security.Claims;
using Microsoft.Identity.Web;

public record class ActiveUser : IDisposable
{
    public ActiveUser(ClaimsPrincipal? User = null, ActiveUsersList? ActiveUsersList = null)
    {
        this.User = User;
        this.ActiveUsersList = ActiveUsersList;
        ActiveUsersList?.Add(this);
    }

    public ClaimsPrincipal? User { get; }
    public ActiveUsersList? ActiveUsersList { get; }

    public string UserId => User?.GetObjectId() ?? "Unknown";
    public string? Name => User?.GetName();
    public string? Username => User?.GetUsername();
    public string? Email => User?.GetEmail();
    public string? PhoneNumber => User?.GetPhoneNumber();

    public void Dispose()
    {
        ActiveUsersList?.Remove(this);
    }
}
