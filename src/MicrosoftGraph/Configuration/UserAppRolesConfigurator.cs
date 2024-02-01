namespace Dgmjr.Graph.Configuration;

using System;
using System.Security.Claims;
using System.Security.Extensions;

using Dgmjr.Graph.TokenProviders;

using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Kiota.Abstractions.Authentication;

public class UserAppRolesConfigurator(ILogger<UserAppRolesConfigurator> logger, IHttpContextAccessor httpContextAccessor) : IConfigureOptions<MicrosoftIdentityOptions>, ILog
{
    public ILogger Logger => logger;
private HttpContext HttpContext => httpContextAccessor.HttpContext!;
private IServiceProvider Services => HttpContext.RequestServices;

public void Configure(MicrosoftIdentityOptions options)
{
    options.Events.OnTokenValidated += OnTokenValidated;
    options.Events.OnAuthenticationFailed += OnAuthenticationFailed;
    options.Events.OnAuthorizationCodeReceived += OnAuthorizationCodeReceived;
    options.Events.OnMessageReceived += OnMessageReceived;
    options.Events.OnRedirectToIdentityProvider += OnRedirectToIdentityProvider;
    options.Events.OnRemoteFailure += OnRemoteFailure;
}

private async Task OnRemoteFailure(RemoteFailureContext context)
{
    Logger.RemoteFailure(context.Failure);
}

private async Task OnRedirectToIdentityProvider(RedirectContext context)
{
    Logger.RedirectToIdentityProvider(context.ProtocolMessage);
}

private async Task OnMessageReceived(MessageReceivedContext context)
{
    Logger.MessageReceived(context.ProtocolMessage);
}

private async Task OnAuthorizationCodeReceived(AuthorizationCodeReceivedContext context)
{
    Logger.AuthorizationCodeReceived(context.TokenEndpointResponse);
}

private async Task OnAuthenticationFailed(AuthenticationFailedContext context)
{
    Logger.AuthenticationFailed(context.Exception);
}

private static async Task OnTokenValidated(TokenValidatedContext context)
{
    using var scope = context.HttpContext.RequestServices.CreateScope();
    using var activity = Dgmjr.Graph.Telemetry.Activities.TokenAcquisitionActivitySource.StartActivity(
        nameof(OnTokenValidated),
        ActivityKind.Client
    );
    var logger = scope.ServiceProvider.GetRequiredService<ILogger<MicrosoftGraphAutoConfigurator>>();
    logger.BeginningSupplementaryTokenAcquisitionAndCreation(context.Principal);
    activity.AddTag("UserObjectId", context.Principal.GetObjectId());
    activity.AddTag("UserTenantId", context.Principal.GetTenantId());

    var services = scope.ServiceProvider;
    var tokenAcquisition = services.GetRequiredService<ITokenAcquisition>();
    var graphClientOptions = services.GetRequiredService<IOptions<AzureAdB2CGraphOptions>>().Value;

    var graphClient = new GraphServiceClient(
        (Microsoft.Graph.IAuthenticationProvider)(new BaseBearerTokenAuthenticationProvider(
            new TokenAcquisitionTokenProvider(
                tokenAcquisition,

                [MsGraphScopes.Default],
                context.Principal
            )
        ) as IAuthenticationProvider)
    );
    var me = await graphClient.Me.Request().GetAsync();
    var app = await graphClient.Applications[graphClientOptions.AzureAdB2CExtensionsApplicationId.ToString()].Request().GetAsync();
    var appRoles = app.AppRoles;
    var myAppRoles = me.AppRoleAssignments.Where(x => x.ResourceId == graphClientOptions.AzureAdB2CExtensionsApplicationId).ToList();
    var claims = new List<Claim>();
    foreach (var appRole in myAppRoles)
    {
        var theAppRole = appRoles.FirstOrDefault(x => x.Id.ToString() == appRole.Id);
        if (theAppRole != null)
        {
            claims.Add(new(ClaimTypes.Role, theAppRole.Value));
        }
    }
    logger.SupplementaryTokenAcquisitionAndCreationComplete(context.Principal);
}
}
