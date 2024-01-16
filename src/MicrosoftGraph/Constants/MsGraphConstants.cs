namespace Dgmjr.Graph;
using Dgmjr.Web.DownstreamApis;

public static class MsGraphConstants
{
    public const string Scopes = nameof(Scopes);
    public const string MicrosoftGraph = "MicrosoftGraph";

    public const string MicrosoftGraph_ClientId = "ClientId";

    public const string MicrosoftGraph_ClientSecret = "ClientSecret";

    public const string DownstreamApis_MicrosoftGraph = $"{DownstreamApis.AppSettingsKey}:{MicrosoftGraph}";
    public const string DownstreamApis_MicrosoftGraph_Scopes = $"{DownstreamApis.AppSettingsKey}:{MicrosoftGraph}:{Scopes}";

    public const string AzureAdB2CExtensionsApplicationId = nameof(AzureAdB2CExtensionsApplicationId);

    public const string DownstreamApis_MicrosoftGraph_AzureAdB2CExtensionsApplicationId = $"{DownstreamApis_MicrosoftGraph}:{AzureAdB2CExtensionsApplicationId}";
}
