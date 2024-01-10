namespace Dgmjr.AspNetCore.Mvc;

[Flags]
public enum StandardInputMediaTypes : byte
{
    None = 0,
    Bson = 2,
    FormData = 4,
    FormUrlEncoded = 8,
    Json = 16,
    MessagePack = 32,
    PlainText = 64,
    Xml = 128,
    Binary = MessagePack | Bson,
    Forms = FormUrlEncoded | FormData,
    Text = PlainText | Json | Xml,
    JsonXml = Json | Xml,
    All = Json | Xml | PlainText | MessagePack | Bson | FormUrlEncoded | FormData
}
