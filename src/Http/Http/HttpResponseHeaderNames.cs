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
namespace System.Net.Http.Headers;

/// source: https://stackoverflow.com/questions/11037004/are-there-any-constants-for-the-default-http-headers

/// <summary>
/// Contains the standard set of headers applicable to an HTTP response.
/// </summary>
public static class HttpResponseHeaderNames
{
    #region paging
    /// <summary>The number of the page being returned</summary>
    /// <value>x-page-number</value>
    public const string XPageNumber = "X-Page-Number";

    /// <summary>The size of the page being returned</summary>
    /// <value>x-page-size</value>
    public const string XPageSize = "X-Page-Size";

    /// <summary>The total number of pages in the dataset</summary>
    /// <value>x-total-pages</value>
    public const string XTotalPages = "X-Total-Pages";

    /// <summary>The total number of records in the dataset</summary>
    /// <value>x-total-records</value>
    public const string XTotalRecords = "x-total-records";

    /// <summary>The index of the first record in the page</summary>
    /// <value>x-start-index</value>
    public const string XStartIndex = "x-start-index";

    /// <summary>The index of the last record in the page</summary>
    /// <value>x-end-index</value>
    public const string XEndIndex = "x-end-index";

    /// <summary>Whether there is a next page</summary>
    /// <value>x-has-next-page</value>
    public const string XHasNextPage = "x-has-next-page";

    /// <summary>Whether there is a previous page</summary>
    /// <value>x-has-previous-page</value>
    public const string XHasPreviousPage = "x-has-previous-page";

    /// <summary>Whether this is the last page</summary>
    /// <value>x-is-last-page</value>
    public const string XIsLastPage = "x-is-last-page";
    #endregion

    #region problem details
    /// <summary>Indicates that the request has failed</summary>
    /// <value>x-failed</value>
    /// <remarks>https://tools.ietf.org/html/rfc7807</remarks>
    public const string XFailed = "x-failed";
    public const string XProblemTitle = "x-problem-title";
    public const string XProblemDetail = "x-problem-detail";
    public const string XProblemInstance = "x-problem-instance";
    public const string XProblemType = "x-problem-type";
    #endregion

    ///<summary>What partial content range types this server supports</summary>
    public const string AcceptRanges = "Accept-Ranges";

    ///<summary>HTTP header that advertises which patch document formats this server supports</summary>
    public const string AcceptPatch = "Accept-Patch";

    ///<summary>The age the object has been in a proxy cache in seconds</summary>
    public const string Age = "Age";

    ///<summary>Valid actions for a specified resource. To be used for a 405 Method not allowed</summary>
    public const string Allow = "Allow";

    ///<summary>Tells all caching mechanisms from server to client whether they may cache this object. It is measured in seconds</summary>
    public const string CacheControl = "Cache-Control";

    ///<summary>Options that are desired for the connection[17]</summary>
    public const string Connection = "Connection";

    ///<summary>The type of encoding used on the data. See HTTP compression.</summary>
    public const string ContentEncoding = "Content-Encoding";

    ///<summary>The language the content is in</summary>
    public const string ContentLanguage = "Content-Language";

    ///<summary>The length of the response body in octets (8-bit bytes)</summary>
    public const string ContentLength = "Content-Length";

    ///<summary>An alternate location for the returned data</summary>
    public const string ContentLocation = "Content-Location";

    ///<summary>A Base64-encoded binary MD5 sum of the content of the response</summary>
    public const string ContentMD5 = "Content-MD5";

    ///<summary>An opportunity to raise a File Download dialogue box for a known MIME type with binary format or suggest a filename for dynamic content. Quotes are necessary with special characters.</summary>
    public const string ContentDisposition = "Content-Disposition";

    ///<summary>Where in a full body message this partial message belongs</summary>
    public const string ContentRange = "Content-Range";

    ///<summary>The MIME type of this content</summary>
    public const string ContentType = "Content-Type";

    ///<summary>The date and time that the message was sent</summary>
    public const string Date = "Date";

    ///<summary>An identifier for a specific version of a resource, often a message digest</summary>
    public const string ETag = "ETag";

    ///<summary>Gives the date/time after which the response is considered stale</summary>
    public const string Expires = "Expires";

    ///<summary>The last modified date for the requested object, inRFC 2822 format</summary>
    public const string LastModified = "Last-Modified";

    ///<summary>Used to express a typed relationship with another resource, where the relation type is defined by RFC 5988</summary>
    public const string Link = "Link";

    ///<summary>Used in redirection, or when a new resource has been created.</summary>
    public const string Location = "Location";

    ///<summary>This header is supposed to set P3P policy, in the form of P3P:CP=your_compact_policy. However, P3P did not take off,[22] most browsers have never fully implemented it, a lot of websites set this header with fake policy text, that was enough to fool browsers the existence of P3P policy and grant permissions for third party cookies.</summary>
    public const string P3P = "P3P";

    ///<summary>Implementation-specific headers that may have various effects anywhere along the request-response chain.</summary>
    public const string Pragma = "Pragma";

    ///<summary>Request authentication to access the proxy.</summary>
    public const string ProxyAuthenticate = "Proxy-Authenticate";

    ///<summary>Used in redirection, or when a new resource has been created. This refresh redirects after 5 seconds. This is a proprietary, non-standard header extension introduced by Netscape and supported by most web browsers.</summary>
    public const string Refresh = "Refresh";

    ///<summary>If an entity is temporarily unavailable, this instructs the client to try again after a specified period of time (seconds).</summary>
    public const string RetryAfter = "Retry-After";

    ///<summary>A name for the server</summary>
    public const string Server = "Server";

    ///<summary>an HTTP cookie</summary>
    public const string SetCookie = "Set-Cookie";

    ///<summary>A HSTS Policy informing the HTTP client how long to cache the HTTPS only policy and whether this applies to subdomains.</summary>
    public const string StrictTransportSecurity = "Strict-Transport-Security";

    ///<summary>The Trailer general field value indicates that the given set of header fields is present in the trailer of a message encoded with chunked transfer-coding.</summary>
    public const string Trailer = "Trailer";

    ///<summary>The form of encoding used to safely transfer the entity to the user. Currently defined methods are:chunked, compress, deflate, gzip, identity.</summary>
    public const string TransferEncoding = "Transfer-Encoding";

    ///<summary>Tells downstream proxies how to match future request headers to decide whether the cached response can be used rather than requesting a fresh one from the origin server.</summary>
    public const string Vary = "Vary";

    ///<summary>Informs the client of proxies through which the response was sent.</summary>
    public const string Via = "Via";

    ///<summary>A general warning about possible problems with the entity body.</summary>
    public const string Warning = "Warning";

    ///<summary>Indicates the authentication scheme that should be used to access the requested entity.</summary>
    public const string WWWAuthenticate = "WWW-Authenticate";
}
