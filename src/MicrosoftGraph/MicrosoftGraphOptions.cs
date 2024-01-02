namespace Dgmjr.MicrosoftGraph;

public class MicrosoftGraphOptions : Microsoft.Identity.Web.MicrosoftGraphOptions
{
    /// <value>MicrosoftGraphOptions</value>
    public const string AppSettingsKey = nameof(MicrosoftGraphOptions);

    /// <summary>The <see cref="guid" /> of the Azure AD B2C extensions application</summary>
    public guid AzureAdB2CExtensionsApplicationId { get; set; }
}
