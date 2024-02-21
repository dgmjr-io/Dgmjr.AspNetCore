namespace Dgmjr.Blazor.ActiveUsers;

using Microsoft.AspNetCore.Builder;
using System.Security.Claims;
using Microsoft.Extensions.DependencyInjection;

public class ActiveUsersAutoConfigurator : IConfigureIHostApplicationBuilder
{
    public ConfigurationOrder Order => ConfigurationOrder.AnyTime;

    public void Configure(WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<ActiveUser>();
        builder.Services.AddSingleton<IActiveUsersList, ActiveUsersList>();
    }
}
