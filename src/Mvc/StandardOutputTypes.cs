namespace Dgmjr.AspNetCore.Mvc;

[Flags]
public enum StandardOutputMediaTypes : byte
{
    None = 0,
    Bson = 2,
    Json = 16,
    MessagePack = 32,
    PlainText = 64,
    Xml = 128,
    Binary = MessagePack | Bson,
    Text = PlainText | Json | Xml,
    JsonXml = Json | Xml,
    All = Json | Xml | PlainText | MessagePack | Bson
}
