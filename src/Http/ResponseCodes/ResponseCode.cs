using System.Runtime.CompilerServices;

namespace Dgmjr.Http.Enums;

[GenerateEnumerationRecordStruct(nameof(StatusCode), "Dgmjr.Http")]
public enum StatusCode : ushort
{
    /// <summary>The server has received the request headers and the client should proceed to send the request body (in the case of a request for which a body needs to be sent; for example, a POST request).</summary>
    /// <value>100</value>
    [Display(
        Name = "Continue",
        Description = "The server has received the request headers and the client should proceed to send the request body (in the case of a request for which a body needs to be sent; for example, a POST request). Sending a large request body to a server after a request has been rejected for inappropriate headers would be inefficient. To have a server check the request's headers, a client must send Expect: 100-continue as a header in its initial request and receive a 100 Continue status code in response before sending the body. If the client receives an error code such as 403 (Forbidden) or 405 (Method Not Allowed) then it should not send the request's body. The response 417 Expectation Failed indicates that the request should be repeated without the Expect header as it indicates that the server does not support expectations (this is the case, for example, of HTTP/1.0 servers)."
    )]
    /// <see href="https://developer.mozilla.org/en-US/docs/Web/HTTP/Status/100" />
    [Uri($"{UriBase}100")]
    Continue = 100,

    /// <summary>The requester has asked the server to switch protocols and the server has agreed to do so.</summary>
    /// <value>101</value>
    [Display(
        Name = "Switching Protocols",
        ShortName = "SwitchingProtocols",
        Description = "The requester has asked the server to switch protocols and the server has agreed to do so."
    )]
    /// <see href="https://developer.mozilla.org/en-US/docs/Web/HTTP/Status/101" />
    [Uri($"{UriBase}101")]
    SwitchingProtocols = 101,

    /// <summary>Used to return some response headers before final HTTP message.</summary>
    /// <value>102</value>
    [Display(
        Name = "Processing",
        Description = "A WebDAV request may contain many sub-requests involving file operations, requiring a long time to complete the request. This code indicates that the server has received and is processing the request, but no response is available yet.[3] This prevents the client from timing out and assuming the request was lost. The status code is deprecated."
    )]
    /// <see href="https://developer.mozilla.org/en-US/docs/Web/HTTP/Status/102" />
    [Uri($"{UriBase}102")]
    Processing = 102,

    /// <summary>Used to return some response headers before final HTTP message.</summary>
    /// <value>103</value>
    [Display(
        Name = "Early Hints",
        Description = "Used to return some response headers before final HTTP message."
    )]
    /// <see href="https://developer.mozilla.org/en-US/docs/Web/HTTP/Status/103" />
    [Uri($"{UriBase}103")]
    EarlyHinds = 103,

    /// <summary>The request has succeeded. The meaning of the success depends on the HTTP method:</summary>
    /// <value>200</value>
    [Display(
        Name = "OK",
        Description = "The request has succeeded. The meaning of the success depends on the HTTP method:"
    )]
    /// <see href="https://developer.mozilla.org/en-US/docs/Web/HTTP/Status/200" />
    [Uri($"{UriBase}200")]
    OK = 200,

    /// <summary>The request has succeeded and a new resource has been created as a result. This is typically the response sent after a PUT request.</summary>
    /// <value>201</value>
    [Display(
        Name = "Created",
        Description = "The request has succeeded and a new resource has been created as a result. This is typically the response sent after a PUT request."
    )]
    /// <see href="https://developer.mozilla.org/en-US/docs/Web/HTTP/Status/201" />
    [Uri($"{UriBase}201")]
    Created = 201,

    /// <summary>The request has been received but not yet acted upon. It is non-committal, meaning that there is no way in HTTP to later send an asynchronous response indicating the outcome of processing the request. It is intended for cases where another process or server handles the request, or for batch processing.</summary>
    /// <value>202</value>
    [Display(
        Name = "Accepted",
        Description = "The request has been received but not yet acted upon. It is non-committal, meaning that there is no way in HTTP to later send an asynchronous response indicating the outcome of processing the request. It is intended for cases where another process or server handles the request, or for batch processing."
    )]
    /// <see href="https://developer.mozilla.org/en-US/docs/Web/HTTP/Status/202" />
    [Uri($"{UriBase}202")]
    Accepted = 202,

    /// <summary>The server is a transforming proxy (e.g. a Web accelerator) that received a 200 OK from its origin, but is returning a modified version of the origin's response.</summary>
    /// <value>203</value>
    [Display(
        Name = "Non-Authoritative Information",
        ShortName = "NonAuthoritativeInformation",
        Description = "The server is a transforming proxy (e.g. a Web accelerator) that received a 200 OK from its origin, but is returning a modified version of the origin's response."
    )]
    /// <see href="https://developer.mozilla.org/en-US/docs/Web/HTTP/Status/203" />
    [Uri($"{UriBase}203")]
    NonAuthoritativeInformation = 203,

    /// <summary>The server successfully processed the request and is not returning any content.</summary>
    /// <value>204</value>
    [Display(
        Name = "No Content",
        ShortName = "NoContent",
        Description = "The server successfully processed the request and is not returning any content."
    )]
    /// <see href="https://developer.mozilla.org/en-US/docs/Web/HTTP/Status/204" />
    [Uri($"{UriBase}204")]
    NoContent = 204,

    /// <summary>The server successfully processed the request, but is not returning any content. Unlike a 204 response, this response requires that the requester reset the document view.</summary>
    /// <value>205</value>
    [Display(
        Name = "Reset Content",
        ShortName = "ResetContent",
        Description = "The server successfully processed the request, but is not returning any content. Unlike a 204 response, this response requires that the requester reset the document view."
    )]
    /// <see href="https://developer.mozilla.org/en-US/docs/Web/HTTP/Status/205" />
    [Uri($"{UriBase}205")]
    ResetContent = 205,

    /// <summary>The server is delivering only part of the resource (byte serving) due to a range header sent by the client. The range header is used by HTTP clients to enable resuming of interrupted downloads, or split a download into multiple simultaneous streams.</summary>
    /// <value>206</value>
    [Display(
        Name = "Partial Content",
        ShortName = "PartialContent",
        Description = "The server is delivering only part of the resource (byte serving) due to a range header sent by the client. The range header is used by HTTP clients to enable resuming of interrupted downloads, or split a download into multiple simultaneous streams."
    )]
    /// <see href="https://developer.mozilla.org/en-US/docs/Web/HTTP/Status/206" />
    [Uri($"{UriBase}206")]
    PartialContent = 206,

    /// <summary>The message body that follows is an XML message and can contain a number of separate response codes, depending on how many sub-requests were made.</summary>
    /// <value>207</value>
    [Display(
        Name = "Multi-Status",
        ShortName = "MultiStatus",
        Description = "The message body that follows is an XML message and can contain a number of separate response codes, depending on how many sub-requests were made."
    )]
    /// <see href="https://developer.mozilla.org/en-US/docs/Web/HTTP/Status/207" />
    [Uri($"{UriBase}207")]
    MultiStatus = 207,

    /// <summary>The members of a DAV binding have already been enumerated in a preceding part of the (multistatus) response, and are not being included again.</summary>
    /// <value>208</value>
    [Display(
        Name = "Already Reported",
        ShortName = "AlreadyReported",
        Description = "The members of a DAV binding have already been enumerated in a preceding part of the (multistatus) response, and are not being included again."
    )]
    /// <see href="https://developer.mozilla.org/en-US/docs/Web/HTTP/Status/208" />
    [Uri($"{UriBase}208")]
    AlreadyReported = 208,

    /// <summary>The server has fulfilled a request for the resource, and the response is a representation of the result of one or more instance-manipulations applied to the current instance.</summary>
    /// <value>226</value>
    [Display(
        Name = "IM Used",
        Description = "The server has fulfilled a request for the resource, and the response is a representation of the result of one or more instance-manipulations applied to the current instance."
    )]
    /// <see href="https://developer.mozilla.org/en-US/docs/Web/HTTP/Status/226" />
    [Uri($"{UriBase}226")]
    IMUsed = 226,

    /// <summary>The request has more than one possible response. The user-agent or user should choose one of them. (There is no standardized way of choosing one of the responses, but HTML links to the possibilities are recommended so the user can pick.)</summary>
    /// <value>300</value>
    [Display(
        Name = "Multiple Choices",
        Description = "The request has more than one possible response. The user-agent or user should choose one of them. (There is no standardized way of choosing one of the responses, but HTML links to the possibilities are recommended so the user can pick.)"
    )]
    /// <see href="https://developer.mozilla.org/en-US/docs/Web/HTTP/Status/300" />
    [Uri($"{UriBase}300")]
    MultipleChoices = 300,

    /// <summary>The URL of the requested resource has been changed permanently. This and all future requests should be directed to the given URI.</summary>
    /// <value>301</value>
    [Display(
        Name = "Moved Permanently",
        Description = "The URL of the requested resource has been changed permanently. This and all future requests should be directed to the given URI."
    )]
    /// <see href="https://developer.mozilla.org/en-US/docs/Web/HTTP/Status/301" />
    [Uri($"{UriBase}301")]
    MovedPermanently = 301,

    /// <summary>Tells the client to look at (browse to) another URL. The HTTP/1.0 specification required the client to perform a temporary redirect with the same method (the original describing phrase was "Moved Temporarily"),[9] but popular browsers implemented 302 redirects by changing the method to GET. Therefore, HTTP/1.1 added status codes 303 and 307 to distinguish between the two behaviors.</summary>
    /// <value>302</value>
    [Display(
        Name = "Found",
        Description = "Tells the client to look at (browse to) another URL. The HTTP/1.0 specification required the client to perform a temporary redirect with the same method (the original describing phrase was \\\"Moved Temporarily\\\"), but popular browsers implemented 302 redirects by changing the method to GET. Therefore, HTTP/1.1 added status codes 303 and 307 to distinguish between the two behaviors."
    )]
    /// <see href="https://developer.mozilla.org/en-US/docs/Web/HTTP/Status/302" />
    [Uri($"{UriBase}302")]
    Found = 302,

    /// <summary>The response to the request can be found under another URI using the GET method. When received in response to a POST (or PUT/DELETE), the client should presume that the server has received the data and should issue a new GET request to the given URI.</summary>
    /// <value>303</value>
    [Display(
        Name = "See Other",
        Description = "The response to the request can be found under another URI using the GET method. When received in response to a POST (or PUT/DELETE), the client should presume that the server has received the data and should issue a new GET request to the given URI."
    )]
    /// <see href="https://developer.mozilla.org/en-US/docs/Web/HTTP/Status/303" />
    [Uri($"{UriBase}303")]
    SeeOther = 303,

    /// <summary>Indicates that the resource has not been modified since the version specified by the request headers If-Modified-Since or If-None-Match. In such case, there is no need to retransmit the resource since the client still has a previously-downloaded copy.</summary>
    /// <value>304</value>
    [Display(
        Name = "Not Modified",
        Description = "Indicates that the resource has not been modified since the version specified by the request headers If-Modified-Since or If-None-Match. In such case, there is no need to retransmit the resource since the client still has a previously-downloaded copy."
    )]
    /// <see href="https://developer.mozilla.org/en-US/docs/Web/HTTP/Status/304" />
    [Uri($"{UriBase}304")]
    NotModified = 304,

    /// <summary>The requested resource is available only through a proxy, the address for which is provided in the response. For security reasons, many HTTP clients (such as Mozilla Firefox and Internet Explorer) do not obey this status code.</summary>
    /// <value>305</value>
    [Display(
        Name = "Use Proxy",
        Description = "The requested resource is available only through a proxy, the address for which is provided in the response. For security reasons, many HTTP clients (such as Mozilla Firefox and Internet Explorer) do not obey this status code."
    )]
    /// <see href="https://developer.mozilla.org/en-US/docs/Web/HTTP/Status/305" />
    [Uri($"{UriBase}305")]
    UseProxy = 305,

    /// <summary>No longer used. Originally meant "Subsequent requests should use the specified proxy."</summary>
    /// <value>306</value>
    [Display(
        Name = "Switch Proxy",
        Description = "No longer used. Originally meant \\\"Subsequent requests should use the specified proxy.\\\""
    )]
    /// <see href="https://developer.mozilla.org/en-US/docs/Web/HTTP/Status/306" />
    [Uri($"{UriBase}306")]
    SwitchProxy = 306,

    /// <summary>In this case, the request should be repeated with another URI; however, future requests should still use the original URI. In contrast to how 302 was historically implemented, the request method is not allowed to be changed when reissuing the original request. For example, a POST request should be repeated using another POST request.</summary>
    /// <value>307</value>
    [Display(
        Name = "Temporary Redirect",
        Description = "In this case, the request should be repeated with another URI; however, future requests should still use the original URI. In contrast to how 302 was historically implemented, the request method is not allowed to be changed when reissuing the original request. For example, a POST request should be repeated using another POST request."
    )]
    /// <see href="https://developer.mozilla.org/en-US/docs/Web/HTTP/Status/307" />
    [Uri($"{UriBase}307")]
    TemporaryRedirect = 307,

    /// <summary>The request and all future requests should be repeated using another URI. 307 and 308 parallel the behaviors of 302 and 301, but do not allow the HTTP method to change. So, for example, submitting a form to a permanently redirected resource may continue smoothly.</summary>
    /// <value>308</value>
    [Display(
        Name = "Permanent Redirect",
        Description = "The request and all future requests should be repeated using another URI. 307 and 308 parallel the behaviors of 302 and 301, but do not allow the HTTP method to change. So, for example, submitting a form to a permanently redirected resource may continue smoothly."
    )]
    /// <see href="https://developer.mozilla.org/en-US/docs/Web/HTTP/Status/308" />
    [Uri($"{UriBase}308")]
    PermanentRedirect = 308,

    /// <summary>The server cannot or will not process the request due to an apparent client error (e.g., malformed request syntax, size too large, invalid request message framing, or deceptive request routing).</summary>
    /// <value>400</value>
    [Display(
        Name = "Bad Request",
        Description = "The server cannot or will not process the request due to an apparent client error (e.g., malformed request syntax, size too large, invalid request message framing, or deceptive request routing)."
    )]
    /// <see href="https://developer.mozilla.org/en-US/docs/Web/HTTP/Status/400" />
    [Uri($"{UriBase}400")]
    BadRequest = 400,

    /// <summary>Similar to 403 Forbidden, but specifically for use when authentication is required and has failed or has not yet been provided. The response must include a WWW-Authenticate header field containing a challenge applicable to the requested resource.</summary>
    /// <value>401</value>
    [Display(
        Name = "Unauthorized",
        Description = "Similar to 403 Forbidden, but specifically for use when authentication is required and has failed or has not yet been provided. The response must include a WWW-Authenticate header field containing a challenge applicable to the requested resource."
    )]
    /// <see href="https://developer.mozilla.org/en-US/docs/Web/HTTP/Status/401" />
    [Uri($"{UriBase}401")]
    Unauthorized = 401,

    /// <summary>Reserved for future use. The original intention was that this code might be used as part of some form of digital cash or micropayment scheme, as proposed for example by GNU Taler,[60] but that has not yet happened, and this code is not usually used. Google Developers API uses this status if a particular developer has exceeded the daily limit on requests.[61] Sipgate uses this code if an account does not have sufficient funds to start a call.[62] Shopify uses this code when the store has not paid their fees and is temporarily disabled.[63] Stripe uses this code for failed payments where parameters were correct, for example blocked fraudulent payments.[64]</summary>
    /// <value>402</value>
    [Display(
        Name = "Payment Required",
        Description = "Reserved for future use. The original intention was that this code might be used as part of some form of digital cash or micropayment scheme, as proposed for example by GNU Taler, but that has not yet happened, and this code is not usually used. Google Developers API uses this status if a particular developer has exceeded the daily limit on requests. Sipgate uses this code if an account does not have sufficient funds to start a call. Shopify uses this code when the store has not paid their fees and is temporarily disabled. Stripe uses this code for failed payments where parameters were correct, for example blocked fraudulent payments."
    )]
    /// <see href="https://developer.mozilla.org/en-US/docs/Web/HTTP/Status/402" />
    [Uri($"{UriBase}402")]
    PaymentRequired = 402,

    /// <summary>The request was valid, but the server is refusing action. The user might not have the necessary permissions for a resource, or may need an account of some sort.</summary>
    /// <value>403</value>
    [Display(
        Name = "Forbidden",
        Description = "The request was valid, but the server is refusing action. The user might not have the necessary permissions for a resource, or may need an account of some sort."
    )]
    /// <see href="https://developer.mozilla.org/en-US/docs/Web/HTTP/Status/403" />
    [Uri($"{UriBase}403")]
    Forbidden = 403,

    /// <summary>The requested resource could not be found but may be available in the future. Subsequent requests by the client are permissible.</summary>
    /// <value>404</value>
    [Display(
        Name = "Not Found",
        Description = "The requested resource could not be found but may be available in the future. Subsequent requests by the client are permissible."
    )]
    /// <see href="https://developer.mozilla.org/en-US/docs/Web/HTTP/Status/404" />
    [Uri($"{UriBase}404")]
    NotFound = 404,

    /// <summary>A request method is not supported for the requested resource; for example, a GET request on a form that requires data to be presented via POST, or a PUT request on a read-only resource.</summary>
    /// <value>405</value>
    [Display(
        Name = "Method Not Allowed",
        Description = "A request method is not supported for the requested resource; for example, a GET request on a form that requires data to be presented via POST, or a PUT request on a read-only resource."
    )]
    /// <see href="https://developer.mozilla.org/en-US/docs/Web/HTTP/Status/405" />
    [Uri($"{UriBase}405")]
    MethodNotAllowed = 405,

    /// <summary>The requested resource is capable of generating only content not acceptable according to the Accept headers sent in the request.</summary>
    /// <value>406</value>
    [Display(
        Name = "Not Acceptable",
        Description = "The requested resource is capable of generating only content not acceptable according to the Accept headers sent in the request."
    )]
    /// <see href="https://developer.mozilla.org/en-US/docs/Web/HTTP/Status/406" />
    [Uri($"{UriBase}406")]
    NotAcceptable = 406,

    /// <summary>The client must first authenticate itself with the proxy.</summary>
    /// <value>407</value>
    [Display(
        Name = "Proxy Authentication Required",
        Description = "The client must first authenticate itself with the proxy."
    )]
    /// <see href="https://developer.mozilla.org/en-US/docs/Web/HTTP/Status/407" />
    [Uri($"{UriBase}407")]
    ProxyAuthenticationRequired = 407,

    /// <summary>The server timed out waiting for the request. According to HTTP specifications: "The client did not produce a request within the time that the server was prepared to wait. The client MAY repeat the request without modifications at any later time."</summary>
    /// <value>408</value>
    [Display(
        Name = "Request Timeout",
        Description = "The server timed out waiting for the request. According to HTTP specifications: \\\"The client did not produce a request within the time that the server was prepared to wait. The client MAY repeat the request without modifications at any later time.\\\""
    )]
    /// <see href="https://developer.mozilla.org/en-US/docs/Web/HTTP/Status/408" />
    [Uri($"{UriBase}408")]
    RequestTimeout = 408,

    /// <summary>Indicates that the request could not be processed because of conflict in the current state of the resource, such as an edit conflict between multiple simultaneous updates.</summary>
    /// <value>409</value>
    [Display(
        Name = "Conflict",
        Description = "Indicates that the request could not be processed because of conflict in the current state of the resource, such as an edit conflict between multiple simultaneous updates."
    )]
    /// <see href="https://developer.mozilla.org/en-US/docs/Web/HTTP/Status/409" />
    [Uri($"{UriBase}409")]
    Conflict = 409,

    /// <summary>Indicates that the resource requested is no longer available and will not be available again. This should be used when a resource has been intentionally removed and the resource should be purged. Upon receiving a 410 status code, the client should not request the resource in the future. Clients such as search engines should remove the resource from their indices.[41] Most use cases do not require clients and search engines to purge the resource, and a "404 Not Found" may be used instead.</summary>
    /// <value>410</value>
    [Display(
        Name = "Gone",
        Description = "Indicates that the resource requested is no longer available and will not be available again. This should be used when a resource has been intentionally removed and the resource should be purged. Upon receiving a 410 status code, the client should not request the resource in the future. Clients such as search engines should remove the resource from their indices. Most use cases do not require clients and search engines to purge the resource, and a \\\"404 Not Found\\\" may be used instead."
    )]
    /// <see href="https://developer.mozilla.org/en-US/docs/Web/HTTP/Status/410" />
    [Uri($"{UriBase}410")]
    Gone = 410,

    /// <summary>The request did not specify the length of its content, which is required by the requested resource.</summary>
    /// <value>411</value>
    [Display(
        Name = "Length Required",
        Description = "The request did not specify the length of its content, which is required by the requested resource."
    )]
    /// <see href="https://developer.mozilla.org/en-US/docs/Web/HTTP/Status/411" />
    [Uri($"{UriBase}411")]
    LengthRequired = 411,

    /// <summary>The server does not meet one of the preconditions that the requester put on the request.</summary>
    /// <value>412</value>
    [Display(
        Name = "Precondition Failed",
        Description = "The server does not meet one of the preconditions that the requester put on the request."
    )]
    /// <see href="https://developer.mozilla.org/en-US/docs/Web/HTTP/Status/412" />
    [Uri($"{UriBase}412")]
    PreconditionFailed = 412,

    /// <summary>The request is larger than the server is willing or able to process. Previously called "Request Entity Too Large".[44]</summary>
    /// <value>413</value>
    [Display(
        Name = "Payload Too Large",
        Description = "The request is larger than the server is willing or able to process. Previously called \\\"Request Entity Too Large\\\"."
    )]
    /// <see href="https://developer.mozilla.org/en-US/docs/Web/HTTP/Status/413" />
    [Uri($"{UriBase}413")]
    PayloadTooLarge = 413,

    /// <summary>The URI provided was too long for the server to process. Often the result of too much data being encoded as a query-string of a GET request, in which case it should be converted to a POST request.[45] Called "Request-URI Too Long" previously.</summary>
    /// <value>414</value>
    [Display(
        Name = "URI Too Long",
        Description = "The URI provided was too long for the server to process. Often the result of too much data being encoded as a query-string of a GET request, in which case it should be converted to a POST request. Called \\\"Request-URI Too Long\\\" previously."
    )]
    /// <see href="https://developer.mozilla.org/en-US/docs/Web/HTTP/Status/414" />
    [Uri($"{UriBase}414")]
    URITooLong = 414,

    /// <summary>The request entity has a media type which the server or resource does not support. For example, the client uploads an image as image/svg+xml, but the server requires that images use a different format.</summary>
    /// <value>415</value>
    [Display(
        Name = "Unsupported Media Type",
        Description = "The request entity has a media type which the server or resource does not support. For example, the client uploads an image as image/svg+xml, but the server requires that images use a different format."
    )]
    /// <see href="https://developer.mozilla.org/en-US/docs/Web/HTTP/Status/415" />
    [Uri($"{UriBase}415")]
    UnsupportedMediaType = 415,

    /// <summary>The client has asked for a portion of the file (byte serving), but the server cannot supply that portion. For example, if the client asked for a part of the file that lies beyond the end of the file.[46] Called "Requested Range Not Satisfiable" previously.</summary>
    /// <value>416</value>
    [Display(
        Name = "Range Not Satisfiable",
        Description = "The client has asked for a portion of the file (byte serving), but the server cannot supply that portion. For example, if the client asked for a part of the file that lies beyond the end of the file. Called \\\"Requested Range Not Satisfiable\\\" previously."
    )]
    /// <see href="https://developer.mozilla.org/en-US/docs/Web/HTTP/Status/416" />
    [Uri($"{UriBase}416")]
    RangeNotSatisfiable = 416,

    /// <summary>The server cannot meet the requirements of the Expect request-header field.</summary>
    /// <value>417</value>
    [Display(
        Name = "Expectation Failed",
        Description = "The server cannot meet the requirements of the Expect request-header field."
    )]
    /// <see href="https://developer.mozilla.org/en-US/docs/Web/HTTP/Status/417" />
    [Uri($"{UriBase}417")]
    ExpectationFailed = 417,

    /// <summary>This code was defined in 1998 as one of the traditional IETF April Fools' jokes, in RFC 2324, Hyper Text Coffee Pot Control Protocol, and is not expected to be implemented by actual HTTP servers. The RFC specifies this code should be returned by teapots requested to brew coffee.[53] This HTTP status is used as an Easter egg in some websites, including Google.com.</summary>
    /// <value>418</value>
    [Display(
        Name = "I'm a teapot",
        Description = "This code was defined in 1998 as one of the traditional IETF April Fools' jokes, in RFC 2324, Hyper Text Coffee Pot Control Protocol, and is not expected to be implemented by actual HTTP servers. The RFC specifies this code should be returned by teapots requested to brew coffee. This HTTP status is used as an Easter egg in some websites, including Google.com."
    )]
    /// <see href="https://developer.mozilla.org/en-US/docs/Web/HTTP/Status/418" />
    [Uri($"{UriBase}418")]
    ImATeapot = 418,

    /// <summary>The request was directed at a server that is not able to produce a response (for example because of connection reuse).</summary>
    /// <value>421</value>
    [Display(
        Name = "Misdirected Request",
        Description = "The request was directed at a server that is not able to produce a response (for example because of connection reuse)."
    )]
    /// <see href="https://developer.mozilla.org/en-US/docs/Web/HTTP/Status/421" />
    [Uri($"{UriBase}421")]
    MisdirectedRequest = 421,

    /// <summary>The request was well-formed but was unable to be followed due to semantic errors.</summary>
    /// <value>422</value>
    [Display(
        Name = "Unprocessable Entity",
        Description = "The request was well-formed but was unable to be followed due to semantic errors."
    )]
    /// <see href="https://developer.mozilla.org/en-US/docs/Web/HTTP/Status/422" />
    [Uri($"{UriBase}422")]
    UnprocessableEntity = 422,

    /// <summary>The resource that is being accessed is locked.</summary>
    /// <value>423</value>
    [Display(Name = "Locked", Description = "The resource that is being accessed is locked.")]
    /// <see href="https://developer.mozilla.org/en-US/docs/Web/HTTP/Status/423" />
    [Uri($"{UriBase}423")]
    Locked = 423,

    /// <summary>The request failed due to failure of a previous request (e.g., a PROPPATCH).</summary>
    /// <value>424</value>
    [Display(
        Name = "Failed Dependency",
        Description = "The request failed due to failure of a previous request (e.g., a PROPPATCH)."
    )]
    /// <see href="https://developer.mozilla.org/en-US/docs/Web/HTTP/Status/424" />
    [Uri($"{UriBase}424")]
    FailedDependency = 424,

    /// <summary>The client should switch to a different protocol such as TLS/1.0, given in the Upgrade header field.</summary>
    /// <value>426</value>
    [Display(
        Name = "Upgrade Required",
        Description = "The client should switch to a different protocol such as TLS/1.0, given in the Upgrade header field."
    )]
    /// <see href="https://developer.mozilla.org/en-US/docs/Web/HTTP/Status/426" />
    [Uri($"{UriBase}426")]
    UpgradeRequired = 426,

    /// <summary>The origin server requires the request to be conditional. Intended to prevent the 'lost update' problem, where a client GETs a resource's state, modifies it, and PUTs it back to the server, when meanwhile a third party has modified the state on the server, leading to a conflict.</summary>
    /// <value>428</value>
    [Display(
        Name = "Precondition Required",
        Description = "The origin server requires the request to be conditional. Intended to prevent the 'lost update' problem, where a client GETs a resource's state, modifies it, and PUTs it back to the server, when meanwhile a third party has modified the state on the server, leading to a conflict."
    )]
    /// <see href="https://developer.mozilla.org/en-US/docs/Web/HTTP/Status/428" />
    [Uri($"{UriBase}428")]
    PreconditionRequired = 428,

    /// <summary>The user has sent too many requests in a given amount of time. Intended for use with rate-limiting schemes.</summary>
    /// <value>429</value>
    [Display(
        Name = "Too Many Requests",
        Description = "The user has sent too many requests in a given amount of time. Intended for use with rate-limiting schemes."
    )]
    /// <see href="https://developer.mozilla.org/en-US/docs/Web/HTTP/Status/429" />
    [Uri($"{UriBase}429")]
    TooManyRequests = 429,

    /// <summary>The server is unwilling to process the request because either an individual header field, or all the header fields collectively, are too large.</summary>
    /// <value>431</value>
    [Display(
        Name = "Request Header Fields Too Large",
        Description = "The server is unwilling to process the request because either an individual header field, or all the header fields collectively, are too large."
    )]
    /// <see href="https://developer.mozilla.org/en-US/docs/Web/HTTP/Status/431" />
    [Uri($"{UriBase}431")]
    RequestHeaderFieldsTooLarge = 431,

    /// <summary>A server operator has received a legal demand to deny access to a resource or to a set of resources that includes the requested resource.[60] The code 451 was chosen as a reference to the novel Fahrenheit 451 (see the Acknowledgements in the RFC).</summary>
    /// <value>451</value>
    [Display(
        Name = "Unavailable For Legal Reasons",
        Description = "A server operator has received a legal demand to deny access to a resource or to a set of resources that includes the requested resource. The code 451 was chosen as a reference to the novel Fahrenheit 451 (see the Acknowledgements in the RFC)."
    )]
    /// <see href="https://developer.mozilla.org/en-US/docs/Web/HTTP/Status/451" />
    [Uri($"{UriBase}451")]
    UnavailableForLegalReasons = 451,

    /// <summary>A generic error message, given when an unexpected condition was encountered and no more specific message is suitable.</summary>
    /// <value>500</value>
    [Display(
        Name = "Internal Server Error",
        Description = "A generic error message, given when an unexpected condition was encountered and no more specific message is suitable."
    )]
    /// <see href="https://developer.mozilla.org/en-US/docs/Web/HTTP/Status/500" />
    [Uri($"{UriBase}500")]
    InternalServerError = 500,

    /// <summary>The server either does not recognize the request method, or it lacks the ability to fulfil the request. Usually this implies future availability (e.g., a new feature of a web-service API).</summary>
    /// <value>501</value>
    [Display(
        Name = "Not Implemented",
        Description = "The server either does not recognize the request method, or it lacks the ability to fulfil the request. Usually this implies future availability (e.g., a new feature of a web-service API)."
    )]
    /// <see href="https://developer.mozilla.org/en-US/docs/Web/HTTP/Status/501" />
    [Uri($"{UriBase}501")]
    NotImplemented = 501,

    /// <summary>The server was acting as a gateway or proxy and received an invalid response from the upstream server.</summary>
    /// <value>502</value>
    [Display(
        Name = "Bad Gateway",
        Description = "The server was acting as a gateway or proxy and received an invalid response from the upstream server."
    )]
    /// <see href="https://developer.mozilla.org/en-US/docs/Web/HTTP/Status/502" />
    [Uri($"{UriBase}502")]
    BadGateway = 502,

    /// <summary>The server cannot handle the request (because it is overloaded or down for maintenance). Generally, this is a temporary state.</summary>
    /// <value>503</value>
    [Display(
        Name = "Service Unavailable",
        Description = "The server cannot handle the request (because it is overloaded or down for maintenance). Generally, this is a temporary state."
    )]
    /// <see href="https://developer.mozilla.org/en-US/docs/Web/HTTP/Status/503" />
    [Uri($"{UriBase}503")]
    ServiceUnavailable = 503,

    /// <summary>The server was acting as a gateway or proxy and did not receive a timely response from the upstream server.</summary>
    /// <value>504</value>
    [Display(
        Name = "Gateway Timeout",
        Description = "The server was acting as a gateway or proxy and did not receive a timely response from the upstream server."
    )]
    /// <see href="https://developer.mozilla.org/en-US/docs/Web/HTTP/Status/504" />
    [Uri($"{UriBase}504")]
    GatewayTimeout = 504,

    /// <summary>The server does not support the HTTP protocol version used in the request.</summary>
    /// <value>505</value>
    [Display(
        Name = "HTTP Version Not Supported",
        Description = "The server does not support the HTTP protocol version used in the request."
    )]
    /// <see href="https://developer.mozilla.org/en-US/docs/Web/HTTP/Status/505" />
    [Uri($"{UriBase}505")]
    HTTPVersionNotSupported = 505,

    /// <summary>Transparent content negotiation for the request results in a circular reference.</summary>
    /// <value>506</value>
    [Display(
        Name = "Variant Also Negotiates",
        Description = "Transparent content negotiation for the request results in a circular reference."
    )]
    /// <see href="https://developer.mozilla.org/en-US/docs/Web/HTTP/Status/506" />
    [Uri($"{UriBase}506")]
    VariantAlsoNegotiates = 506,

    /// <summary>The server is unable to store the representation needed to complete the request.</summary>
    /// <value>507</value>
    [Display(
        Name = "Insufficient Storage",
        Description = "The server is unable to store the representation needed to complete the request."
    )]
    /// <see href="https://developer.mozilla.org/en-US/docs/Web/HTTP/Status/507" />
    [Uri($"{UriBase}507")]
    InsufficientStorage = 507,

    /// <summary>The server detected an infinite loop while processing the request (sent in lieu of 208 Already Reported).</summary>
    /// <value>508</value>
    [Display(
        Name = "Loop Detected",
        Description = "The server detected an infinite loop while processing the request (sent in lieu of 208 Already Reported)."
    )]
    /// <see href="https://developer.mozilla.org/en-US/docs/Web/HTTP/Status/508" />
    [Uri($"{UriBase}508")]
    LoopDetected = 508,

    /// <summary>Further extensions to the request are required for the server to fulfil it.</summary>
    /// <value>510</value>
    [Display(
        Name = "Not Extended",
        Description = "Further extensions to the request are required for the server to fulfil it."
    )]
    /// <see href="https://developer.mozilla.org/en-US/docs/Web/HTTP/Status/510" />
    [Uri($"{UriBase}510")]
    NotExtended = 510,

    /// <summary>The client needs to authenticate to gain network access. Intended for use by intercepting proxies used to control access to the network (e.g., "captive portals" used to require agreement to Terms of Service before granting full Internet access via a Wi-Fi hotspot).</summary>
    /// <value>511</value>
    [Display(
        Name = "Network Authentication Required",
        Description = "The client needs to authenticate to gain network access. Intended for use by intercepting proxies used to control access to the network (e.g., \\\"captive portals\\\" used to require agreement to Terms of Service before granting full Internet access via a Wi-Fi hotspot)."
    )]
    /// <see href="https://developer.mozilla.org/en-US/docs/Web/HTTP/Status/511" />
    [Uri($"{UriBase}511")]
    NetworkAuthenticationRequired = 511,

    /// <summary>This status code is not specified in any RFCs. Its use is unknown.</summary>
    /// <value>520</value>
    [Display(
        Name = "Unknown Error",
        Description = "This status code is not specified in any RFCs. Its use is unknown."
    )]
    /// <see href="https://developer.mozilla.org/en-US/docs/Web/HTTP/Status/520" />
    [Uri($"{UriBase}520")]
    UnknownError = 520,

    /// <summary>The origin server has refused the connection from the client.</summary>
    /// <value>521</value>
    [Display(
        Name = "Web Server Is Down",
        Description = "The origin server has refused the connection from the client."
    )]
    /// <see href="https://developer.mozilla.org/en-US/docs/Web/HTTP/Status/521" />
    [Uri($"{UriBase}521")]
    WebServerIsDown = 521,

    /// <summary>The connection to the origin server timed out.</summary>
    /// <value>522</value>
    [Display(
        Name = "Connection Timed Out",
        Description = "The connection to the origin server timed out."
    )]
    /// <see href="https://developer.mozilla.org/en-US/docs/Web/HTTP/Status/522" />
    [Uri($"{UriBase}522")]
    ConnectionTimedOut = 522,

    /// <summary>The origin server refused to accept the request.</summary>
    /// <value>523</value>
    [Display(
        Name = "Origin Is Unreachable",
        Description = "The origin server refused to accept the request."
    )]
    /// <see href="https://developer.mozilla.org/en-US/docs/Web/HTTP/Status/523" />
    [Uri($"{UriBase}523")]
    OriginIsUnreachable = 523,

    /// <summary>The server is currently unavailable (because it is overloaded or down for maintenance). Generally, this is a temporary state.</summary>
    /// <value>524</value>
    [Display(
        Name = "A Timeout Occurred",
        Description = "The server is currently unavailable (because it is overloaded or down for maintenance). Generally, this is a temporary state."
    )]
    /// <see href="https://developer.mozilla.org/en-US/docs/Web/HTTP/Status/524" />
    [Uri($"{UriBase}524")]
    ATimeoutOccurred = 524,

    /// <summary>The SSL certificate presented by the origin server is not trusted by the system for one or more of the following reasons: 1. The server is self-signed. 2. The server is signed by a certificate authority that is not well-known. 3. The server is signed by a certificate authority that is not well-known by your system's trust store.</summary>
    /// <value>525</value>
    [Display(
        Name = "SSL Handshake Failed",
        Description = "The SSL certificate presented by the origin server is not trusted by the system for one or more of the following reasons: 1. The server is self-signed. 2. The server is signed by a certificate authority that is not well-known. 3. The server is signed by a certificate authority that is not well-known by your system's trust store."
    )]
    /// <see href="https://developer.mozilla.org/en-US/docs/Web/HTTP/Status/525" />
    [Uri($"{UriBase}525")]
    SSLHandshakeFailed = 525,

    /// <summary>The origin server has refused to accept the request because a new SSL handshake is required.</summary>
    /// <value>526</value>
    [Display(
        Name = "Invalid SSL Certificate",
        Description = "The origin server has refused to accept the request because a new SSL handshake is required."
    )]
    /// <see href="https://developer.mozilla.org/en-US/docs/Web/HTTP/Status/526" />
    [Uri($"{UriBase}526")]
    InvalidSSLCertificate = 526,

    /// <summary>Used by Cloudflare and Cloud Foundry's gorouter to indicate failure to validate the SSL/TLS certificate that the origin server presented.</summary>
    /// <value>527</value>
    [Display(
        Name = "Railgun Error",
        Description = "Used by Cloudflare and Cloud Foundry's gorouter to indicate failure to validate the SSL/TLS certificate that the origin server presented."
    )]
    /// <see href="https://developer.mozilla.org/en-US/docs/Web/HTTP/Status/527" />
    [Uri($"{UriBase}527")]
    RailgunError = 527,

    /// <summary>This status code is not specified in any RFC and is returned by certain services, for instance Microsoft Azure and CloudFlare servers: 1. Microsoft Azure: The server timed out waiting for the request. According to Microsoft Support, this error occurs because a script that uses the WinHTTP library sends an HTTP request without a request header. 2. CloudFlare: The request timed out or failed after the WAN connection had been established.</summary>
    /// <value>529</value>
    [Display(
        Name = "Site Is Overloaded",
        Description = "This status code is not specified in any RFC and is returned by certain services, for instance Microsoft Azure and CloudFlare servers: 1. Microsoft Azure: The server timed out waiting for the request. According to Microsoft Support, this error occurs because a script that uses the WinHTTP library sends an HTTP request without a request header. 2. CloudFlare: The request timed out or failed after the WAN connection had been established."
    )]
    /// <see href="https://developer.mozilla.org/en-US/docs/Web/HTTP/Status/529" />
    [Uri($"{UriBase}529")]
    SiteIsOverloaded = 529,

    /// <summary>This status code is not specified in any RFCs, but is used by CloudFlare's reverse proxies to signal an "unknown connection issue between CloudFlare and the origin web server" to a client in front of the proxy.</summary>
    /// <value>530</value>
    [Display(
        Name = "Site Is Frozen",
        Description = "This status code is not specified in any RFCs, but is used by CloudFlare's reverse proxies to signal an \\\"unknown connection issue between CloudFlare and the origin web server\\\" to a client in front of the proxy."
    )]
    /// <see href="https://developer.mozilla.org/en-US/docs/Web/HTTP/Status/530" />
    [Uri($"{UriBase}530")]
    SiteIsFrozen = 530,

    /// <summary>Used by Apache servers. A catch-all error condition allowing the passage of message bodies through the server when the ProxyErrorOverride setting is enabled. It is displayed in this situation instead of a 4xx or 5xx error message.</summary>
    /// <value>218</value>
    [Display(
        Name = "This Is Fine",
        Description = "Used by Apache servers. A catch-all error condition allowing the passage of message bodies through the server when the ProxyErrorOverride setting is enabled. It is displayed in this situation instead of a 4xx or 5xx error message."
    )]
    /// <see href="https://developer.mozilla.org/en-US/docs/Web/HTTP/Status/218" />
    [Uri($"{UriBase}218")]
    ThisIsFine = 218,

    /// <summary>Used by the Laravel Framework when a CSRF Token is missing or expired.<summary>
    /// <value>419</value>
    [Display(
        Name = "Page Expired",
        Description = "Used by the Laravel Framework when a CSRF Token is missing or expired."
    )]
    /// <see href="https://developer.mozilla.org/en-US/docs/Web/HTTP/Status/419" />
    [Uri($"{UriBase}419")]
    PageExpired = 419,

    /// <summary>Returned by version 1 of the Twitter Search and Trends API when the client is being rate limited; versions 1.1 and later use the 429 Too Many Requests response code instead. The phrase "Enhance your calm" comes from the 1993 movie Demolition Man, and its association with this number is likely a reference to cannabis.</summary>
    /// <value>420</value>
    [Display(
        Name = "Enhance Your Calm",
        Description = "Returned by version 1 of the Twitter Search and Trends API when the client is being rate limited; versions 1.1 and later use the 429 Too Many Requests response code instead. The phrase \\\"Enhance your calm\\\" comes from the 1993 movie Demolition Man, and its association with this number is likely a reference to cannabis."
    )]
    /// <see href="https://developer.mozilla.org/en-US/docs/Web/HTTP/Status/420" />
    [Uri($"{UriBase}420")]
    EnhanceYourCalm = 420,

    /// <summary>Returned by ArcGIS for Server. A code of 498 indicates an expired or otherwise invalid token.</summary>
    /// <value>498</value>
    [Display(
        Name = "Invalid Token",
        Description = "Returned by ArcGIS for Server. A code of 498 indicates an expired or otherwise invalid token."
    )]
    /// <see href="https://developer.mozilla.org/en-US/docs/Web/HTTP/Status/498" />
    [Uri($"{UriBase}498")]
    InvalidToken = 498,

    /// <summary>Returned by ArcGIS for Server. A code of 499 indicates that a token is required (if no token was submitted).</summary>
    /// <value>499</value>
    [Display(
        Name = "Token Required",
        Description = "Returned by ArcGIS for Server. A code of 499 indicates that a token is required (if no token was submitted)."
    )]
    /// <see href="https://developer.mozilla.org/en-US/docs/Web/HTTP/Status/499" />
    [Uri($"{UriBase}499")]
    TokenRequired = 499,

    /// <summary>Used in Exchange ActiveSync if there either is a more efficient server to use or the server cannot access the users' mailbox.[citation needed]</summary>
    /// <value>449</value>
    [Display(
        Name = "Retry With",
        Description = "Used in Exchange ActiveSync if there either is a more efficient server to use or the server cannot access the users' mailbox."
    )]
    /// <see href="https://developer.mozilla.org/en-US/docs/Web/HTTP/Status/449" />
    [Uri($"{UriBase}449")]
    RetryWith = 449,

    /// <summary>A Microsoft extension. The request should be retried after performing the appropriate action.</summary>
    /// <value>451</value>
    [Display(
        Name = "Redirect",
        Description = "A Microsoft extension. The request should be retried after performing the appropriate action."
    )]
    /// <see href="https://developer.mozilla.org/en-US/docs/Web/HTTP/Status/451" />
    [Uri($"{UriBase}451")]
    Redirect = 451
}
