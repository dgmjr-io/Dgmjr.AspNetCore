namespace Dgmjr.Graph.Options;

public class MicrosoftB2CGraphOptions : Microsoft.Identity.Web.MicrosoftGraphOptions
{
    /// <value>MicrosoftGraphOptions</value>
    public const string AppSettingsKey = nameof(MicrosoftB2CGraphOptions);

    /// <summary>The <see cref="guid" /> of the Azure AD B2C extensions application</summary>
    public guid AzureAdB2CExtensionsApplicationId { get; set; }

    public bool AppOnly { get; set; } = false;
}
