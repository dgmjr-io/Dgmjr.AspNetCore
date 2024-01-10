using System.Diagnostics;

namespace Dgmjr.Mime.Enums;

[GenerateEnumerationRecordStruct("Suffixes", "Dgmjr.Mime")]
public enum Suffixes
{
    None = 0,

    [Display(Name = "+json")]
    [Uri($"{IetfRfcUrnBase}:6839#section-3.1")]
    Json,

    [Display(Name = "+json-seq")]
    [Uri($"{IetfRfcUrnBase}:8091")]
    JsonSeq,

    [Display(Name = "+xml")]
    [Uri($"{IetfRfcUrnBase}:6839#section-4.1")]
    Xml,

    [Display(Name = "+yaml")]
    [Uri("https://datatracker.ietf.org/doc/draft-ietf-httpapi-yaml-mediatypes")]
    Yaml,

    [Display(Name = "+cbor")]
    [Uri($"{IetfRfcUrnBase}:8949#section-9.5")]
    Cbor,

    [Display(Name = "+ber")]
    [Uri($"{IetfRfcUrnBase}:6839#section-3.2")]
    Ber,

    [Display(Name = "+der")]
    [Uri($"{IetfRfcUrnBase}:6839#section-3.3")]
    Der,

    [Display(Name = "+zip")]
    [Uri($"{IetfRfcUrnBase}:6839#section-3.6")]
    Zip,

    [Display(Name = "+fastinfoset")]
    [Uri($"{IetfRfcUrnBase}:6839#section-3.4")]
    FastInfoSet,

    [Display(Name = "+wbxml")]
    [Uri($"{IetfRfcUrnBase}:6839#section-3.5")]
    Wbxml,

    [Display(Name = "+bson")]
    [Uri("http://www.sqlite.org/fileformat2.html")]
    Sqlite3,

    [Display(Name = "+bson")]
    [Uri($"{IetfRfcUrnBase}:6839#section-3.5")]
    Bson,

    [Display(Name = "+msgpack")]
    [Uri("https://msgpack.org")]
    MessagePack,
}
