namespace Dgmjr.Graph;

using Dgmjr.Web.DownstreamApis;

public static class MsGraphConstants
{
    public const string Scopes = nameof(Scopes);
    public const string MicrosoftGraph = "MicrosoftGraph";

    public const string MicrosoftGraph_ClientId = "ClientId";

    public const string MicrosoftGraph_ClientSecret = "ClientSecret";

    public const string DownstreamApis_MicrosoftGraph =
        $"{DownstreamApisBase.AppSettingsKey}:{MicrosoftGraph}";
    public const string DownstreamApis_MicrosoftGraph_Scopes =
        $"{DownstreamApisBase.AppSettingsKey}:{MicrosoftGraph}:{Scopes}";

    public const string AzureAdB2CExtensionsApplicationId = nameof(
        AzureAdB2CExtensionsApplicationId
    );

    public const string DownstreamApis_MicrosoftGraph_AzureAdB2CExtensionsApplicationId =
        $"{DownstreamApis_MicrosoftGraph}:{AzureAdB2CExtensionsApplicationId}";

    public static readonly string[] ValidMsGraphHosts =
    [
        "graph.microsoft.com",
        "graph.microsoft.us",
        "dod-graph.microsoft.us",
        "graph.microsoft.de",
        "microsoftgraph.chinacloudapi.cn"
    ];
}
