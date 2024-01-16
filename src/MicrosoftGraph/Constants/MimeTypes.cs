namespace Dgmjr.Graph.Constants;
using Dgmjr.Mime;

public static class MimeTypes
{
    private const string MsGraph = "msgraph";

    public const string MsGraphExtensionPropertiesList = $"{MsGraph}-extension-properties";
    public const string MsGraphExtensionPropertiesListJson = $"{Application.Base.DisplayName}/{MsGraphExtensionPropertiesList}{Suffixes.Json.DisplayName}";
    public const string MsGraphExtensionPropertiesListXml = $"{Application.Base.DisplayName}/{MsGraphExtensionPropertiesList}{Suffixes.Xml.DisplayName}";
    public const string MsGraphExtensionPropertiesListBson = $"{Application.Base.DisplayName}/{MsGraphExtensionPropertiesList}{Suffixes.Bson.DisplayName}";
    public const string MsGraphExtensionPropertiesListMsgPack = $"{Application.Base.DisplayName}/{MsGraphExtensionPropertiesList}{Suffixes.MessagePack.DisplayName}";

    public const string MsGraphUser = $"{MsGraph}-user";
    public const string MsGraphUserJson = $"{Application.Base.DisplayName}/{MsGraphUser}{Suffixes.Json.DisplayName}";
    public const string MsGraphUserXml = $"{Application.Base.DisplayName}/{MsGraphUser}{Suffixes.Xml.DisplayName}";
    public const string MsGraphUserBson = $"{Application.Base.DisplayName}/{MsGraphUser}{Suffixes.Bson.DisplayName}";
    public const string MsGraphUserMsgPack = $"{Application.Base.DisplayName}/{MsGraphUser}{Suffixes.MessagePack.DisplayName}";
}
