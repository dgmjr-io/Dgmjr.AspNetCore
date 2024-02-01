// using System;
// using System.Collections.Generic;
// using System.Threading;
// using System.Threading.Tasks;

// using Microsoft.Kiota.Abstractions.Authentication;
// using Microsoft.Identity.Web;

// namespace Dgmjr.Graph.TokenProviders;

// public class ClientSecretTokenProvider(IOptionsMonitor<MicrosoftIdentityOptions> options, ITokenAcquisition tokenAcquisition) : IAccessTokenProvider
// {
//     private MicrosoftIdentityOptions Options => options.CurrentValue;
//     public AllowedHostsValidator AllowedHostsValidator => new (ValidMsGraphHosts);

//     public async Task<string> GetAuthorizationTokenAsync(Uri uri, Dictionary<string, object>? additionalAuthenticationContext = null, CancellationToken cancellationToken = default)
//     {
//         TokenAcquirerAppTokenCredential tokenAcquisitionAppTokenCredential = new (tokenAcquisition);
//         await tokenAcquisitionAppTokenCredential.GetTokenAsync(new Azure.Core.TokenRequestContext([MsGraphScopes.Default], tenantId: Options.TenantId), cancellationToken);

//     }
// }
