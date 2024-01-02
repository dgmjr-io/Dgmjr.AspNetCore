namespace Dgmjr.MicrosoftGraph;

[RegexDto(@"^extension_(?<ExtensionsAppClientId>[a-zA-z0-9]{32})_(?<ExtensionName>\w+)$")]
public record struct ExtensionPropertyKey
{
    public ExtensionPropertyKey(string extensionPropertyName, guid extensionsAppClientId) : this()
    {
        ExtensionName = extensionPropertyName;
        ExtensionAppClientId = extensionAppClientId.ToString().Replace("-", "");
    }

    public string AsKey => $"extension_{ExtensionAppClientId}_{ExtensionName}";

    public static implicit operator ExtensionPropertyKey(string key) => new ExtensionPropertyKey(key);
}

public static class Helpers
{
    public static ExtensionPropertyKey GetExtensionPropertyKey(string extensionPropertyName, guid extensionAppClientId)
    {
        return new ExtensionPropertyKey(extensionPropertyName, extensionAppClientId);
    }
}
