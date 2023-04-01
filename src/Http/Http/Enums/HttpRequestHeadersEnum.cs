/*
 * HttpRequestHeadersEnum.cs
 *
 *   Created: 2022-12-22-12:36:03
 *   Modified: 2022-12-22-12:36:04
 *
 *   Author: David G. Moore, Jr, <david@dgmjr.io>
 *
 *   Copyright © 2022-2023 David G. Moore, Jr,, All Rights Reserved
 *      License: MIT (https://opensource.org/licenses/MIT)
 */
namespace System.Net.Http.Headers.Enums;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

/// <summary>
/// Contains the standard set of headers applicable to an HTTP request.
/// </summary>
[GenerateEnumerationRecordStruct("HttpRequestHeaderName", "System.Net.Http.Headers")]
public enum HttpRequestHeaderName
{
    /// <summary>The number of the page being requested</summary>
    /// <value>X-Page-Number</value>
    [EnumMember(Value = "X-Page-Number")]
    [Display(Name = HReqH.XPageNumber, Description = "The number of the page being requested")]
    XPageNumber,

    /// <summary>The size of the page being requested</summary>
    /// <value>X-Page-Size</value>
    [EnumMember(Value = "X-Page-Size")]
    [Display(Name = HReqH.XPageSize, Description = "The size of the page being requested")]
    XPageSize,

    /// <summary>Content-Types that are acceptable</summary>
    /// <value>"Accept"</value>
    [EnumMember(Value = nameof(Accept))]
    [Display(Name = HReqH.Accept, Description = "Content-Types that are acceptable")]
    Accept,

    /// <summary>Character sets that are acceptable</summary>
    /// <value>"Accept-Charset"</value>
    [EnumMember(Value = "Accept-Charset")]
    [Display(Name = HReqH.AcceptCharset, Description = "Character sets that are acceptable")]
    AcceptCharset,

    /// <summary>Acceptable encodings. See HTTP compression.</summary>
    /// <value>"Accept-Encoding"</value>
    [EnumMember(Value = "Accept-Encoding")]
    [Display(
        Name = HReqH.AcceptEncoding,
        Description = "Acceptable encodings. See HTTP compression."
    )]
    AcceptEncoding,

    /// <summary>Acceptable languages for response</summary>
    /// <value>"Accept-Language"</value>
    [EnumMember(Value = "Accept-Language")]
    [Display(Name = HReqH.AcceptLanguage, Description = "Acceptable languages for response")]
    AcceptLanguage,

    /// <summary>Acceptable version in time</summary>
    /// <value>"Accept-Datetime"</value>
    [EnumMember(Value = "Accept-Datetime")]
    [Display(Name = HReqH.AcceptDatetime, Description = "Acceptable version in time")]
    AcceptDatetime,

    /// <summary>Authentication credentials for HTTP authentication</summary>
    /// <value>"Authorization"</value>
    [EnumMember(Value = nameof(Authorization))]
    [Display(
        Name = HReqH.Authorization,
        Description = "Authentication credentials for HTTP authentication"
    )]
    Authorization,

    /// <summary>Used to specify directives that MUST be obeyed by all caching mechanisms along the request/response chain</summary>
    /// <value>"Cache-Control"</value>
    [EnumMember(Value = "Cache-Control")]
    [Display(
        Name = HReqH.CacheControl,
        Description = "Used to specify directives that MUST be obeyed by all caching mechanisms along the request/response chain"
    )]
    CacheControl,

    /// <summary>What type of connection the user-agent would prefer</summary>
    /// <value>"Connection"</value>
    [EnumMember(Value = nameof(Connection))]
    [Display(
        Name = HReqH.Connection,
        Description = "What type of connection the user-agent would prefer"
    )]
    Connection,

    /// <summary>an HTTP cookie previously sent by the server with Set-Cookie (below)</summary>
    /// <value>"Cookie"</value>
    [EnumMember(Value = nameof(Cookie))]
    [Display(
        Name = HReqH.Cookie,
        Description = "an HTTP cookie previously sent by the server with Set-Cookie (below)"
    )]
    Cookie,

    /// <summary>The length of the request body in octets (8-bit bytes)</summary>
    /// <value>"Content-Length"</value>
    [EnumMember(Value = "Content-Length")]
    [Display(
        Name = HReqH.ContentLength,
        Description = "The length of the request body in octets (8-bit bytes)"
    )]
    ContentLength,

    /// <summary>A Base64-encoded binary MD5 sum of the content of the request body</summary>
    /// <value>"Content-MD5"</value>
    [EnumMember(Value = "Content-MD5")]
    [Display(
        Name = HReqH.ContentMD5,
        Description = "A Base64-encoded binary MD5 sum of the content of the request body"
    )]
    ContentMD5,

    /// <summary>The MIME type of the body of the request (used with POST and PUT requests)</summary>
    /// <value>"Content-Type"</value>
    [EnumMember(Value = "Content-Type")]
    [Display(
        Name = HReqH.ContentType,
        Description = "The MIME type of the body of the request (used with POST and PUT requests)"
    )]
    ContentType,

    /// <summary>The date and time that the message was sent</summary>
    /// <value>"Date"</value>
    [EnumMember(Value = nameof(Date))]
    [Display(Name = HReqH.Date, Description = "The date and time that the message was sent")]
    Date,

    /// <summary>Indicates that particular server behaviors are required by the client</summary>
    /// <value>"Expect"</value>
    [EnumMember(Value = nameof(Expect))]
    [Display(
        Name = HReqH.Expect,
        Description = "Indicates that particular server behaviors are required by the client"
    )]
    Expect,

    /// <summary>The email address of the user making the request</summary>
    /// <value>"From"</value>
    [EnumMember(Value = nameof(From))]
    [Display(Name = HReqH.From, Description = "The email address of the user making the request")]
    From,

    /// <summary>The domain name of the server (for virtual hosting), mandatory since HTTP/1.1. Although domain name are specified as case-insensitive[5][6], it is not specified whether the contents of the Host field should be interpreted in a case-insensitive manner[7] and in practice some implementations of virtual hosting interpret the contents of the Host field in a case-sensitive manner.[citation needed]</summary>
    /// <value>"Host"</value>
    [EnumMember(Value = nameof(Host))]
    [Display(
        Name = HReqH.Host,
        Description = "The domain name of the server (for virtual hosting), mandatory since HTTP/1.1. Although domain name are specified as case-insensitive[5][6], it is not specified whether the contents of the Host field should be interpreted in a case-insensitive manner[7] and in practice some implementations of virtual hosting interpret the contents of the Host field in a case-sensitive manner.[citation needed]"
    )]
    Host,

    /// <summary>Only perform the action if the client supplied entity matches the same entity on the server. This is mainly for methods like PUT to only update a resource if it has not been modified since the user last updated it.</summary>
    /// <value>"If-Match"</value>
    [EnumMember(Value = "If-Match")]
    [Display(
        Name = HReqH.IfMatch,
        Description = "Only perform the action if the client supplied entity matches the same entity on the server. This is mainly for methods like PUT to only update a resource if it has not been modified since the user last updated it."
    )]
    IfMatch,

    /// <summary>Allows a 304 Not Modified to be returned if content is unchanged</summary>
    /// <value>"If-Modified-Since"</value>
    [EnumMember(Value = "If-Modified-Since")]
    [Display(
        Name = HReqH.IfModifiedSince,
        Description = "Allows a 304 Not Modified to be returned if content is unchanged"
    )]
    IfModifiedSince,

    /// <summary>Allows a 304 Not Modified to be returned if content is unchanged, see HTTP ETag</summary>
    /// <value>"If-None-Match"</value>
    [EnumMember(Value = "If-None-Match")]
    [Display(
        Name = HReqH.IfNoneMatch,
        Description = "Allows a 304 Not Modified to be returned if content is unchanged, see HTTP ETag"
    )]
    IfNoneMatch,

    /// <summary>If the entity is unchanged, send me the part(s) that I am missing, otherwise, send me the entire new entity</summary>
    /// <value>"If-Range"</value>
    [EnumMember(Value = "If-Range")]
    [Display(
        Name = HReqH.IfRange,
        Description = "If the entity is unchanged, send me the part(s) that I am missing, otherwise, send me the entire new entity"
    )]
    IfRange,

    /// <summary>Only send the response if the entity has not been modified since a specific time.</summary>
    /// <value>"If-Unmodified-Since"</value>
    [EnumMember(Value = "If-Unmodified-Since")]
    [Display(
        Name = HReqH.IfUnmodifiedSince,
        Description = "Only send the response if the entity has not been modified since a specific time."
    )]
    IfUnmodifiedSince,

    /// <summary>Limit the number of times the message can be forwarded through proxies or gateways.</summary>
    /// <value>"Max-Forwards"</value>
    [EnumMember(Value = "Max-Forwards")]
    [Display(
        Name = HReqH.MaxForwards,
        Description = "Limit the number of times the message can be forwarded through proxies or gateways."
    )]
    MaxForwards,

    /// <summary>Implementation-specific headers that may have various effects anywhere along the request-response chain.</summary>
    /// <value>"Pragma"</value>
    [EnumMember(Value = nameof(Pragma))]
    [Display(
        Name = HReqH.Pragma,
        Description = "Implementation-specific headers that may have various effects anywhere along the request-response chain."
    )]
    Pragma,

    /// <summary>Authorization credentials for connecting to a proxy.</summary>
    /// <value>"Proxy-Authorization"</value>
    [EnumMember(Value = "Proxy-Authorization")]
    [Display(
        Name = HReqH.ProxyAuthorization,
        Description = "Authorization credentials for connecting to a proxy."
    )]
    ProxyAuthorization,

    /// <summary>Request only part of an entity. Bytes are numbered from 0.</summary>
    /// <value>"Range"</value>
    [EnumMember(Value = nameof(Range))]
    [Display(
        Name = HReqH.Range,
        Description = "Request only part of an entity. Bytes are numbered from 0."
    )]
    Range,

    /// <summary>This is the address of the previous web page from which a link to the currently requested page was followed. (The word “referrer” is misspelled in the RFC as well as in most implementations.)</summary>
    /// <value>"Referer[sic]"</value>
    [EnumMember(Value = "Referer")]
    [Display(
        Name = HReqH.Referer,
        Description = "This is the address of the previous web page from which a link to the currently requested page was followed. (The word “referrer” is misspelled in the RFC as well as in most implementations.)"
    )]
    Referer,

    /// <summary>The transfer encodings the user agent is willing to accept: the same values as for the response header Transfer-Encoding can be used, plus the trailers value (related to the chunked transfer method) to notify the server it expects to receive additional headers (the trailers) after the last, zero-sized, chunk.</summary>
    /// <value>"TE"</value>
    [EnumMember(Value = nameof(TE))]
    [Display(
        Name = HReqH.TE,
        Description = "The transfer encodings the user agent is willing to accept: the same values as for the response header Transfer-Encoding can be used, plus the trailers value (related to the chunked transfer method) to notify the server it expects to receive additional headers (the trailers) after the last, zero-sized, chunk."
    )]
    TE,

    /// <summary>Ask the server to upgrade to another protocol.</summary>
    /// <value>"Upgrade"</value>
    [EnumMember(Value = nameof(Upgrade))]
    [Display(Name = HReqH.Upgrade, Description = "Ask the server to upgrade to another protocol.")]
    Upgrade,

    /// <summary>The user agent string of the user agent</summary>
    /// <value>"User-Agent"</value>
    [EnumMember(Value = "User-Agent")]
    [Display(Name = HReqH.UserAgent, Description = "The user agent string of the user agent")]
    UserAgent,

    /// <summary>Informs the server of proxies through which the request was sent.</summary>
    /// <value>"Via"</value>
    [EnumMember(Value = nameof(Via))]
    [Display(
        Name = HReqH.Via,
        Description = "Informs the server of proxies through which the request was sent."
    )]
    Via,

    /// <summary>A general warning about possible problems with the entity body.</summary>
    /// <value>"Warning"</value>
    [EnumMember(Value = nameof(Warning))]
    [Display(
        Name = HReqH.Warning,
        Description = "A general warning about possible problems with the entity body."
    )]
    Warning,

    /// <summary>Contains the original source address of the request.</summary>
    /// <value>"X-Forwarded-For"</value>
    [EnumMember(Value = "X-Forwarded-For")]
    [Display(
        Name = HReqH.XForwardedFor,
        Description = "Contains the original source address of the request."
    )]
    XForwardedFor
}
