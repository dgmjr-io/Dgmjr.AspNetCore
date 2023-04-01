/*
 * HttpResponseHeaders.cs
 *
 *   Created: 2022-11-23-09:36:52
 *   Modified: 2022-11-23-09:36:52
 *
 *   Author: David G. Moore, Jr, <david@dgmjr.io>
 *
 *   Copyright © 2022-2023 David G. Moore, Jr,, All Rights Reserved
 *      License: MIT (https://opensource.org/licenses/MIT)
 */
namespace System.Net.Http.Headers.Enums;

/// source: https://stackoverflow.com/questions/11037004/are-there-any-constants-for-the-default-http-headers

/// <summary>
/// Contains the standard set of headers applicable to an HTTP response.
/// </summary>
[GenerateEnumerationRecordStruct("HttpResponseHeaderName", "System.Net.Http.Headers")]
public enum HttpResponseHeaderName
{
    #region paging
    /// <summary>The number of the page being returned</summary>
    /// <value>x-page-number</value>
    XPageNumber, 

    /// <summary>The size of the page being returned</summary>
    /// <value>x-page-size</value>
    XPageSize, 

    /// <summary>The total number of pages in the dataset</summary>
    /// <value>x-total-pages</value>
    XTotalPages, 

    /// <summary>The total number of records in the dataset</summary>
    /// <value>x-total-records</value>
    XTotalRecords, 

    /// <summary>The index of the first record in the page</summary>
    /// <value>x-start-index</value>
    XStartIndex, 

    /// <summary>The index of the last record in the page</summary>
    /// <value>x-end-index</value>
    XEndIndex, 

    /// <summary>Whether there is a next page</summary>
    /// <value>x-has-next-page</value>
    XHasNextPage, 

    /// <summary>Whether there is a previous page</summary>
    /// <value>x-has-previous-page</value>
    XHasPreviousPage, 

    /// <summary>Whether this is the last page</summary>
    /// <value>x-is-last-page</value>
    XIsLastPage, 
    #endregion

    #region problem details
    /// <summary>Indicates that the request has failed</summary>
    /// <value>x-failed</value>
    /// <remarks>https://tools.ietf.org/html/rfc7807</remarks>
    XFailed, 
    XProblemTitle, 
    XProblemDetail, 
    XProblemInstance, 
    XProblemType, 
    #endregion

    ///<summary>What partial content range types this server supports</summary>
    AcceptRanges, 

    ///<summary>HTTP header that advertises which patch document formats this server supports</summary>
    AcceptPatch, 

    ///<summary>The age the object has been in a proxy cache in seconds</summary>
    Age, 

    ///<summary>Valid actions for a specified resource. To be used for a 405 Method not allowed</summary>
    Allow, 

    ///<summary>Tells all caching mechanisms from server to client whether they may cache this object. It is measured in seconds</summary>
    CacheControl, 

    ///<summary>Options that are desired for the connection[17]</summary>
    Connection, 

    ///<summary>The type of encoding used on the data. See HTTP compression.</summary>
    ContentEncoding, 

    ///<summary>The language the content is in</summary>
    ContentLanguage, 

    ///<summary>The length of the response body in octets (8-bit bytes)</summary>
    ContentLength, 

    ///<summary>An alternate location for the returned data</summary>
    ContentLocation, 

    ///<summary>A Base64-encoded binary MD5 sum of the content of the response</summary>
    ContentMD5, 

    ///<summary>An opportunity to raise a File Download dialogue box for a known MIME type with binary format or suggest a filename for dynamic content. Quotes are necessary with special characters.</summary>
    ContentDisposition, 

    ///<summary>Where in a full body message this partial message belongs</summary>
    ContentRange, 

    ///<summary>The MIME type of this content</summary>
    ContentType, 

    ///<summary>The date and time that the message was sent</summary>
    Date, 

    ///<summary>An identifier for a specific version of a resource, often a message digest</summary>
    ETag, 

    ///<summary>Gives the date/time after which the response is considered stale</summary>
    Expires, 

    ///<summary>The last modified date for the requested object, inRFC 2822 format</summary>
    LastModified, 

    ///<summary>Used to express a typed relationship with another resource, where the relation type is defined by RFC 5988</summary>
    Link, 

    ///<summary>Used in redirection, or when a new resource has been created.</summary>
    Location, 

    ///<summary>This header is supposed to set P3P policy, in the form of P3P:CP=your_compact_policy. However, P3P did not take off,[22] most browsers have never fully implemented it, a lot of websites set this header with fake policy text, that was enough to fool browsers the existence of P3P policy and grant permissions for third party cookies.</summary>
    P3P, 

    ///<summary>Implementation-specific headers that may have various effects anywhere along the request-response chain.</summary>
    Pragma, 

    ///<summary>Request authentication to access the proxy.</summary>
    ProxyAuthenticate, 

    ///<summary>Used in redirection, or when a new resource has been created. This refresh redirects after 5 seconds. This is a proprietary, non-standard header extension introduced by Netscape and supported by most web browsers.</summary>
    Refresh, 

    ///<summary>If an entity is temporarily unavailable, this instructs the client to try again after a specified period of time (seconds).</summary>
    RetryAfter, 

    ///<summary>A name for the server</summary>
    Server, 

    ///<summary>an HTTP cookie</summary>
    SetCookie, 

    ///<summary>A HSTS Policy informing the HTTP client how long to cache the HTTPS only policy and whether this applies to subdomains.</summary>
    StrictTransportSecurity, 

    ///<summary>The Trailer general field value indicates that the given set of header fields is present in the trailer of a message encoded with chunked transfer-coding.</summary>
    Trailer, 

    ///<summary>The form of encoding used to safely transfer the entity to the user. Currently defined methods are:chunked, compress, deflate, gzip, identity.</summary>
    TransferEncoding, 

    ///<summary>Tells downstream proxies how to match future request headers to decide whether the cached response can be used rather than requesting a fresh one from the origin server.</summary>
    Vary, 

    ///<summary>Informs the client of proxies through which the response was sent.</summary>
    Via, 

    ///<summary>A general warning about possible problems with the entity body.</summary>
    Warning, 

    ///<summary>Indicates the authentication scheme that should be used to access the requested entity.</summary>
    WWWAuthenticate, 
}
