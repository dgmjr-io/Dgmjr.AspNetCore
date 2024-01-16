namespace Dgmjr.Graph.Models;
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

    public static DGraphExtensionProperty Empty => new(EmptyString, guid.Empty);

    public string Name => Format(FormatString, AppId, PropertyName);

    public string Value => IsEmpty ? string.Empty : Name;

    public bool IsEmpty => Name == EmptyString;

    public DGraphExtensionProperty ExampleValue => new(ExampleString);

    public Uri Uri => new(Format(UriFormatString, AppId, PropertyName), Absolute);

    public int CompareTo(DGraphExtensionProperty other) => Value.CompareTo(other.Value);

    public int CompareTo(object obj) => obj is DGraphExtensionProperty other ? CompareTo(other) : -1;

    public static implicit operator DGraphExtensionProperty(MgExtensionProperty extensionProperty) => new(extensionProperty.Name);
}

public static class Helpers
{
    public static DGraphExtensionProperty GetExtensionPropertyObject(string extensionPropertyName, guid extensionAppClientId)
    {
        return new DGraphExtensionProperty(extensionPropertyName, extensionAppClientId);
    }
    public static DGraphExtensionProperty GetExtensionPropertyObject((string extensionPropertyName, guid extensionAppClientId) extensionProperty)
    {
        return new DGraphExtensionProperty(extensionProperty.extensionPropertyName, extensionProperty.extensionAppClientId);
    }
    public static string GetExtensionPropertyName(this (string extensionPropertyName, guid extensionAppClientId) extensionProperty)
    {
        return new DGraphExtensionProperty(extensionProperty.extensionPropertyName, extensionProperty.extensionAppClientId).Name;
    }
}
