namespace Dgmjr.MicrosoftGraph.Models;
using System.Text.RegularExpressions;

[RegexDto(@"^extension_(?<AppId:Guid>[a-fA-F0-9]{32})_(?<PropertyName>\w+)$", BaseType: typeof(MgExtensionProperty), RegexOptions: _RegexOptions)]
public readonly partial record struct ExtensionProperty
{
    public ExtensionProperty(string extensionPropertyName, guid extensionsAppId) : this()
    {
        PropertyName = extensionPropertyName;
        AppId = extensionsAppId;
    }

    public const Rxo _RegexOptions = Rxo.Compiled | Rxo.IgnoreCase | Rxo.Singleline | Rxo.IgnorePatternWhitespace | Rxo.ExplicitCapture | Rxo.CultureInvariant;

    public const string FormatString = "extension_{0}_{1}";

    public const string ExampleString = "extension_8c21ed0668e74eed94ecd1eabd572d98_example_property_name";

    public const string EmptyString = "extension_00000000000000000000000000000000_empty";

    public const string DescriptionString = $"An extension property key in the format of {ExampleString} for the {nameof(ExtensionProperty)} model.";

    public const string UriFormatString = "https://graph.microsoft.com/v1.0/applications/{0}/extensionProperties/{1}";

    public static ExtensionProperty Empty => new(EmptyString, guid.Empty);

    public string Name => Format(FormatString, AppId, PropertyName);

    public string Value => IsEmpty ? string.Empty : Name;

    public bool IsEmpty => Name == EmptyString;

    public ExtensionProperty ExampleValue => new(ExampleString);

    public Uri Uri => new(Format(UriFormatString, AppId, PropertyName), Absolute);

    public int CompareTo(ExtensionProperty other) => Value.CompareTo(other.Value);

    public int CompareTo(object obj) => obj is ExtensionProperty other ? CompareTo(other) : -1;

    public static implicit operator ExtensionProperty(MgExtensionProperty extensionProperty) => new(extensionProperty.Name);

    // public static implicit operator DgmjrExtensionProperty(string key) => new (key, guid.Empty);

    // public static implicit operator DgmjrExtensionProperty((string key, guid appId) key) => new (key.key, key.appId);

    // #if NET6_0_OR_GREATER
    //     public static Regx IRegexValueObject<ExtensionProperty>.Regex => Regex();
    // #else
    //     Regx IRegexValueObject<ExtensionProperty>.Regex() => Regex();

    //     bool IEquatable<ExtensionProperty>.Equals(ExtensionProperty other)
    //     {
    //         throw new NotImplementedException();
    //     }
    // #endif
}

public static class Helpers
{
    public static ExtensionProperty GetExtensionPropertyKey(string extensionPropertyName, guid extensionAppClientId)
    {
        return new ExtensionProperty(extensionPropertyName, extensionAppClientId);
    }
}
