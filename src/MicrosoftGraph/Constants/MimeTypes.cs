namespace Dgmjr.Graph.Constants;

using Dgmjr.Mime;

public static class MimeTypes
{
    /// <value>msgraph</value>
    private const string MsGraph = "msgraph";

    /// <value><inheritdoc cref="MsGraph" path="/value" />-extension-properties</value>
    public const string MsGraphExtensionPropertiesList = $"{MsGraph}-extension-properties";

    /// <value><inheritdoc cref="Application.Base.DisplayName" path="/value" />/<inheritdoc cref="MsGraphExtensionPropertiesList" path="/value" /><inheritdoc cref="Suffixes.Json.DisplayName" path="/value" /></value>
    public const string MsGraphExtensionPropertiesListJson =
        $"{Application.Base.DisplayName}/{MsGraphExtensionPropertiesList}{Suffixes.Json.DisplayName}";

    /// <value><inheritdoc cref="Application.Base.DisplayName" path="/value" />/<inheritdoc cref="MsGraphExtensionPropertiesList" path="/value" /><inheritdoc cref="Suffixes.Xml.DisplayName" path="/value" /></value>
    public const string MsGraphExtensionPropertiesListXml =
        $"{Application.Base.DisplayName}/{MsGraphExtensionPropertiesList}{Suffixes.Xml.DisplayName}";

    /// <value><inheritdoc cref="Application.Base.DisplayName" path="/value" />/<inheritdoc cref="MsGraphExtensionPropertiesList" path="/value" /><inheritdoc cref="Suffixes.Bson.DisplayName" path="/value" /></value>
    public const string MsGraphExtensionPropertiesListBson =
        $"{Application.Base.DisplayName}/{MsGraphExtensionPropertiesList}{Suffixes.Bson.DisplayName}";

    /// <value><inheritdoc cref="Application.Base.DisplayName" path="/value" />/<inheritdoc cref="MsGraphExtensionPropertiesList" path="/value" /><inheritdoc cref="Suffixes.MessagePack.DisplayName" path="/value" /></value>
    public const string MsGraphExtensionPropertiesListMsgPack =
        $"{Application.Base.DisplayName}/{MsGraphExtensionPropertiesList}{Suffixes.MessagePack.DisplayName}";

    /// <value><inheritdoc cref="MsGraph" path="/value" />-user</value>
    public const string MsGraphUser = $"{MsGraph}-user";

    /// <value><inheritdoc cref="Application.Base.DisplayName" path="/value" />/<inheritdoc cref="MsGraphExtensionPropertiesList" path="/value" /><inheritdoc cref="Suffixes.Json.DisplayName" path="/value" /></value>
    public const string MsGraphUserJson =
        $"{Application.Base.DisplayName}/{MsGraphUser}{Suffixes.Json.DisplayName}";

    /// <value><inheritdoc cref="Application.Base.DisplayName" path="/value" />/<inheritdoc cref="MsGraphExtensionPropertiesList" path="/value" /><inheritdoc cref="Suffixes.Xml.DisplayName" path="/value" /></value>
    public const string MsGraphUserXml =
        $"{Application.Base.DisplayName}/{MsGraphUser}{Suffixes.Xml.DisplayName}";

    /// <value><inheritdoc cref="Application.Base.DisplayName" path="/value" />/<inheritdoc cref="MsGraphExtensionPropertiesList" path="/value" /><inheritdoc cref="Suffixes.Bson.DisplayName" path="/value" /></value>
    public const string MsGraphUserBson =
        $"{Application.Base.DisplayName}/{MsGraphUser}{Suffixes.Bson.DisplayName}";

    /// <value><inheritdoc cref="Application.Base.DisplayName" path="/value" />/<inheritdoc cref="MsGraphExtensionPropertiesList" path="/value" /><inheritdoc cref="Suffixes.MessagePack.DisplayName" path="/value" /></value>
    public const string MsGraphUserMsgPack =
        $"{Application.Base.DisplayName}/{MsGraphUser}{Suffixes.MessagePack.DisplayName}";
}
