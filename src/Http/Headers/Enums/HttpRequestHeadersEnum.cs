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
namespace Dgmjr.Http.Headers.Enums;

using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

/// <summary>
/// Contains the standard set of headers applicable to an HTTP request.
/// </summary>
[GenerateEnumerationRecordStruct("HttpRequestHeaderNames", "Dgmjr.Http.Headers")]
public enum HttpRequestHeaderNames
{
    /// <summary>The number of the page being requested</summary>
    /// <value>X-Page-Number</value>
    [EnumMember(Value = "X-Page-Number")]
    [Display(Name = "X-Page-Number", Description = "The number of the page being requested")]
    XPageNumber,

    /// <summary>The size of the page being requested</summary>
    /// <value>X-Page-Size</value>
    [EnumMember(Value = "X-Page-Size")]
    [Display(Name = "X-Page-Size", Description = "The size of the page being requested")]
    XPageSize,

    /// <summary>The MIME types of the response the client can understand.</summary>
    /// <value>Accept</value>
    [Display(
        Name = "Accept",
        Description = "The MIME types of the response the client can understand."
    )]
    [EnumMember(Value = "Accept")]
    Accept,

    /// <summary>The character sets the client can handle.</summary>
    /// <value>Accept-Charset</value>
    [Display(Name = "Accept-Charset", Description = "The character sets the client can handle.")]
    [EnumMember(Value = "Accept-Charset")]
    AcceptCharset,

    /// <summary>The encoding algorithms the client can handle.</summary>
    /// <value>Accept-Encoding</value>
    [Display(
        Name = "Accept-Encoding",
        Description = "The encoding algorithms the client can handle."
    )]
    [EnumMember(Value = "Accept-Encoding")]
    AcceptEncoding,

    /// <summary>The natural languages the client can understand.</summary>
    /// <value>Accept-Language</value>
    [Display(
        Name = "Accept-Language",
        Description = "The natural languages the client can understand."
    )]
    [EnumMember(Value = "Accept-Language")]
    AcceptLanguage,

    /// <summary>Authentication credentials for HTTP authentication.</summary>
    /// <value>Authorization</value>
    [Display(
        Name = "Authorization",
        Description = "Authentication credentials for HTTP authentication."
    )]
    [EnumMember(Value = "Authorization")]
    Authorization,

    /// <summary>Directives that must be obeyed by all caching mechanisms along the request/response chain.</summary>
    /// <value>Cache-Control</value>
    [Display(
        Name = "Cache-Control",
        Description = "Directives that must be obeyed by all caching mechanisms along the request/response chain."
    )]
    [EnumMember(Value = "Cache-Control")]
    CacheControl,

    /// <summary>Control options for the current connection and list of hop-by-hop request fields.</summary>
    /// <value>Connection</value>
    [Display(
        Name = "Connection",
        Description = "Control options for the current connection and list of hop-by-hop request fields."
    )]
    [EnumMember(Value = "Connection")]
    Connection,

    /// <summary>The encoding format of the entity-body.</summary>
    /// <value>Content-Encoding</value>
    [Display(Name = "Content-Encoding", Description = "The encoding format of the entity-body.")]
    [EnumMember(Value = "Content-Encoding")]
    ContentEncoding,

    /// <summary>The length of the entity-body in bytes.</summary>
    /// <value>Content-Length</value>
    [Display(Name = "Content-Length", Description = "The length of the entity-body in bytes.")]
    [EnumMember(Value = "Content-Length")]
    ContentLength,

    /// <summary>The media type of the entity-body sent to the recipient.</summary>
    /// <value>Content-Type</value>
    [Display(
        Name = "Content-Type",
        Description = "The media type of the entity-body sent to the recipient."
    )]
    [EnumMember(Value = "Content-Type")]
    ContentType,

    /// <summary>An HTTP cookie previously sent by the server with Set-Cookie (below).</summary>
    /// <value>Cookie</value>
    [Display(
        Name = "Cookie",
        Description = "An HTTP cookie previously sent by the server with Set-Cookie (below)."
    )]
    [EnumMember(Value = "Cookie")]
    Cookie,

    /// <summary>The date and time that the message was sent.</summary>
    /// <value>Date</value>
    [Display(Name = "Date", Description = "The date and time that the message was sent.")]
    [EnumMember(Value = "Date")]
    Date,

    /// <summary>Indicates that particular server behaviors are required by the client.</summary>
    /// <value>Expect</value>
    [Display(
        Name = "Expect",
        Description = "Indicates that particular server behaviors are required by the client."
    )]
    [EnumMember(Value = "Expect")]
    Expect,

    /// <summary>The email address of the user making the request.</summary>
    /// <value>From</value>
    [Display(Name = "From", Description = "The email address of the user making the request.")]
    [EnumMember(Value = "From")]
    From,

    /// <summary>The domain name of the server (for virtual hosting), and the TCP port number on which the server is listening.</summary>
    /// <value>Host</value>
    [Display(
        Name = "Host",
        Description = "The domain name of the server (for virtual hosting), and the TCP port number on which the server is listening."
    )]
    [EnumMember(Value = "Host")]
    Host,

    /// <summary>Only perform the action if the client supplied entity matches the same entity on the server.</summary>
    /// <value>If-Match</value>
    [Display(
        Name = "If-Match",
        Description = "Only perform the action if the client supplied entity matches the same entity on the server."
    )]
    [EnumMember(Value = "If-Match")]
    IfMatch,

    /// <summary>Allows a 304 Not Modified to be returned if content is unchanged.</summary>
    /// <value>If-Modified-Since</value>
    [Display(
        Name = "If-Modified-Since",
        Description = "Allows a 304 Not Modified to be returned if content is unchanged."
    )]
    [EnumMember(Value = "If-Modified-Since")]
    IfModifiedSince,

    /// <summary>Allows a 304 Not Modified to be returned if content is unchanged.</summary>
    /// <value>If-None-Match</value>
    [Display(
        Name = "If-None-Match",
        Description = "Allows a 304 Not Modified to be returned if content is unchanged."
    )]
    [EnumMember(Value = "If-None-Match")]
    IfNoneMatch,

    /// <summary>If the entity is unchanged, send me the part(s) that I am missing; otherwise, send me the entire new entity.</summary>
    /// <value>If-Range</value>
    [Display(
        Name = "If-Range",
        Description = "If the entity is unchanged, send me the part(s) that I am missing; otherwise, send me the entire new entity."
    )]
    [EnumMember(Value = "If-Range")]
    IfRange,

    /// <summary>Only send the response if the entity has not been modified since a specific time.</summary>
    /// <value>If-Unmodified-Since</value>
    [Display(
        Name = "If-Unmodified-Since",
        Description = "Only send the response if the entity has not been modified since a specific time."
    )]
    [EnumMember(Value = "If-Unmodified-Since")]
    IfUnmodifiedSince,

    /// <summary>Limit the number of times the message can be forwarded through proxies or gateways.</summary>
    /// <value>Max-Forwards</value>
    [Display(
        Name = "Max-Forwards",
        Description = "Limit the number of times the message can be forwarded through proxies or gateways."
    )]
    [EnumMember(Value = "Max-Forwards")]
    MaxForwards,

    /// <summary>Implementation-specific headers that may have various effects anywhere along the request-response chain.</summary>
    /// <value>Pragma</value>
    [Display(
        Name = "Pragma",
        Description = "Implementation-specific headers that may have various effects anywhere along the request-response chain."
    )]
    [EnumMember(Value = "Pragma")]
    Pragma,

    /// <summary>Authorization credentials for connecting to a proxy.</summary>
    /// <value>Proxy-Authorization</value>
    [Display(
        Name = "Proxy-Authorization",
        Description = "Authorization credentials for connecting to a proxy."
    )]
    [EnumMember(Value = "Proxy-Authorization")]
    ProxyAuthorization,

    /// <summary>Request only part of an entity.  Bytes are numbered from 0.</summary>
    /// <value>Range</value>
    [Display(
        Name = "Range",
        Description = "Request only part of an entity.  Bytes are numbered from 0."
    )]
    [EnumMember(Value = "Range")]
    Range,
}
