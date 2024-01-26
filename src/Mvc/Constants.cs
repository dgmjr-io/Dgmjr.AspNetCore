namespace Dgmjr.AspNetCore.Mvc;
using Dgmjr.Mime;

public static class Constants
{
    public static readonly string[] StandardResponseMediaTypes =
    [
        ApplicationMediaTypeNames.Json,
        ApplicationMediaTypeNames.Xml,
        TextMediaTypeNames.Plain,
        ApplicationMediaTypeNames.MessagePack,
        ApplicationMediaTypeNames.Bson
    ];
    public static readonly string[] StandardAcceptedMediaTypes =
    [
        ApplicationMediaTypeNames.Json,
        ApplicationMediaTypeNames.Xml,
        TextMediaTypeNames.Plain,
        ApplicationMediaTypeNames.MessagePack,
        ApplicationMediaTypeNames.Bson,
        ApplicationMediaTypeNames.FormUrlEncoded,
        MultipartMediaTypeNames.FormData
    ];
}
