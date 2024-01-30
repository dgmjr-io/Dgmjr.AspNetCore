using System.Runtime.CompilerServices;

namespace Dgmjr.Http.Enums;

[GenerateEnumerationRecordStruct(nameof(StatusCode), "Dgmjr.Http")]
public enum StatusCode : ushort
{
    /// <summary>The server has received the request headers and the client should proceed to send the request body (in the case of a request for which a body needs to be sent; for example, a POST request).</summary>
    /// <value>100</value>
    /// <see href="https://developer.mozilla.org/en-US/docs/Web/HTTP/Status/100" />
    [Display(
        Name = "Continue",
        Description = "The server has received the request headers and the client should proceed to send the request body (in the case of a request for which a body needs to be sent; for example, a POST request). Sending a large request body to a server after a request has been rejected for inappropriate headers would be inefficient. To have a server check the request's headers, a client must send Expect: 100-continue as a header in its initial request and receive a 100 Continue status code in response before sending the body. If the client receives an error code such as 403 (Forbidden) or 405 (Method Not Allowed) then it should not send the request's body. The response 417 Expectation Failed indicates that the request should be repeated without the Expect header as it indicates that the server does not support expectations (this is the case, for example, of HTTP/1.0 servers)."
    )]
    [Uri($"{UriBase}100")]
    Continue = 100,

    /// <summary>The requester has asked the server to switch protocols and the server has agreed to do so.</summary>
    /// <value>101</value>
    /// <see href="https://developer.mozilla.org/en-US/docs/Web/HTTP/Status/101" />
    [Display(
        Name = "Switching Protocols",
        ShortName = "SwitchingProtocols",
        Description = "The requester has asked the server to switch protocols and the server has agreed to do so."
    )]
    [Uri($"{UriBase}101")]
    SwitchingProtocols = 101,

    /// <summary>Used to return some response headers before final HTTP message.</summary>
    /// <value>102</value>
    /// <see href="https://developer.mozilla.org/en-US/docs/Web/HTTP/Status/102" />
    [Display(
        Name = "Processing",
        Description = "A WebDAV request may contain many sub-requests involving file operations, requiring a long time to complete the request. This code indicates that the server has received and is processing the request, but no response is available yet.[3] This prevents the client from timing out and assuming the request was lost. The status code is deprecated."
    )]
    [Uri($"{UriBase}102")]
    Processing = 102,

    /// <summary>Used to return some response headers before final HTTP message.</summary>
    /// <value>103</value>
    /// <see href="https://developer.mozilla.org/en-US/docs/Web/HTTP/Status/103" />
    [Display(
        Name = "Early Hints",
        Description = "Used to return some response headers before final HTTP message."
    )]
    [Uri($"{UriBase}103")]
    EarlyHints = 103,

    ///// <summary>The request has succeeded. The meaning of the success depends on the HTTP method:</summary>
    /// <summary>Yay! You didn't fuck up!</summary>
    /// <value>200</value>
    /// <see href="https://developer.mozilla.org/en-US/docs/Web/HTTP/Status/200" />
    [Display(
        Name = "OK",
        // Description = "The request has succeeded. The meaning of the success depends on the HTTP method:"
        Description = "Yay! You didn't fuck up!"
    )]
    [Uri($"{UriBase}200")]
    OK = 200,

    ///// <summary>The request has succeeded and a new resource has been created as a result. This is typically the response sent after a PUT request.</summary>
    /// <summary>Here.  I created the thing for you.  Are you fucking happy?!</summary>
    /// <value>201</value>
    /// <see href="https://developer.mozilla.org/en-US/docs/Web/HTTP/Status/201" />
    [Display(
        Name = "Created",
        // Description = "The request has succeeded and a new resource has been created as a result. This is typically the response sent after a PUT request."
        Description = "Here.  I created the thing for you.  Are you fucking happy?!"
    )]
    [Uri($"{UriBase}201")]
    Created = 201,

    ///// <summary>The request has been received but not yet acted upon. It is non-committal, meaning that there is no way in HTTP to later send an asynchronous response indicating the outcome of processing the request. It is intended for cases where another process or server handles the request, or for batch processing.</summary>
    /// <summary>I got it, I'm taking care of it, and you can go do other stuff while I work on it for you; don't wait for me.</summary>
    /// <value>202</value>
    /// <see href="https://developer.mozilla.org/en-US/docs/Web/HTTP/Status/202" />
    [Display(
        Name = "Accepted",
        // Description = "The request has been received but not yet acted upon. It is non-committal, meaning that there is no way in HTTP to later send an asynchronous response indicating the outcome of processing the request. It is intended for cases where another process or server handles the request, or for batch processing."
        Description = "I got it, I'm taking care of it, and you can go do other stuff while I work on it for you; don't wait for me."
    )]
    [Uri($"{UriBase}202")]
    Accepted = 202,

    /// <summary>The server is a transforming proxy (e.g. a Web accelerator) that received a 200 OK from its origin, but is returning a modified version of the origin's response.</summary>
    /// <value>203</value>
    /// <see href="https://developer.mozilla.org/en-US/docs/Web/HTTP/Status/203" />
    [Display(
        Name = "Non-Authoritative Information",
        ShortName = "NonAuthoritativeInformation",
        Description = "The server is a transforming proxy (e.g. a Web accelerator) that received a 200 OK from its origin, but is returning a modified version of the origin's response."
    )]
    [Uri($"{UriBase}203")]
    NonAuthoritativeInformation = 203,

    //// / <summary>The server successfully processed the request and is not returning any content.</summary>
    /// <summary>I got it and I took care of it but I don't have anything else to say about it.</summary>
    /// <value>204</value>
    /// <see href="https://developer.mozilla.org/en-US/docs/Web/HTTP/Status/204" />
    [Display(
        Name = "No Content",
        ShortName = "NoContent",
        // Description = "The server successfully processed the request and is not returning any content."
        Description = "I got it and I took care of it but I don't have anything else to say about it."
    )]
    [Uri($"{UriBase}204")]
    NoContent = 204,

    /// <summary>The server successfully processed the request, but is not returning any content. Unlike a 204 response, this response requires that the requester reset the document view.</summary>
    /// <value>205</value>
    /// <see href="https://developer.mozilla.org/en-US/docs/Web/HTTP/Status/205" />
    [Display(
        Name = "Reset Content",
        ShortName = "ResetContent",
        Description = "The server successfully processed the request, but is not returning any content. Unlike a 204 response, this response requires that the requester reset the document view."
    )]
    [Uri($"{UriBase}205")]
    ResetContent = 205,

    /// <summary>The server is delivering only part of the resource (byte serving) due to a range header sent by the client. The range header is used by HTTP clients to enable resuming of interrupted downloads, or split a download into multiple simultaneous streams.</summary>
    /// <value>206</value>
    /// <see href="https://developer.mozilla.org/en-US/docs/Web/HTTP/Status/206" />
    [Display(
        Name = "Partial Content",
        ShortName = "PartialContent",
        Description = "The server is delivering only part of the resource (byte serving) due to a range header sent by the client. The range header is used by HTTP clients to enable resuming of interrupted downloads, or split a download into multiple simultaneous streams."
    )]
    [Uri($"{UriBase}206")]
    PartialContent = 206,

    /// <summary>The message body that follows is an XML message and can contain a number of separate response codes, depending on how many sub-requests were made.</summary>
    /// <value>207</value>
    /// <see href="https://developer.mozilla.org/en-US/docs/Web/HTTP/Status/207" />
    [Display(
        Name = "Multi-Status",
        ShortName = "MultiStatus",
        Description = "The message body that follows is an XML message and can contain a number of separate response codes, depending on how many sub-requests were made."
    )]
    [Uri($"{UriBase}207")]
    MultiStatus = 207,

    /// <summary>The members of a DAV binding have already been enumerated in a preceding part of the (multistatus) response, and are not being included again.</summary>
    /// <value>208</value>
    /// <see href="https://developer.mozilla.org/en-US/docs/Web/HTTP/Status/208" />
    [Display(
        Name = "Already Reported",
        ShortName = "AlreadyReported",
        Description = "The members of a DAV binding have already been enumerated in a preceding part of the (multistatus) response, and are not being included again."
    )]
    [Uri($"{UriBase}208")]
    AlreadyReported = 208,

    /// <summary>Used by Apache servers. A catch-all error condition allowing the passage of message bodies through the server when the ProxyErrorOverride setting is enabled. It is displayed in this situation instead of a 4xx or 5xx error message.</summary>
    /// <value>218</value>
    /// <see href="https://developer.mozilla.org/en-US/docs/Web/HTTP/Status/218" />
    [Display(
        Name = "This Is Fine",
        Description = "Used by Apache servers. A catch-all error condition allowing the passage of message bodies through the server when the ProxyErrorOverride setting is enabled. It is displayed in this situation instead of a 4xx or 5xx error message."
    )]
    [Uri($"{UriBase}218")]
    ThisIsFine = 218,

    /// <summary>The server has fulfilled a request for the resource, and the response is a representation of the result of one or more instance-manipulations applied to the current instance.</summary>
    /// <value>226</value>
    /// <see href="https://developer.mozilla.org/en-US/docs/Web/HTTP/Status/226" />
    [Display(
        Name = "IM Used",
        Description = "The server has fulfilled a request for the resource, and the response is a representation of the result of one or more instance-manipulations applied to the current instance."
    )]
    [Uri($"{UriBase}226")]
    IMUsed = 226,

    /// <summary>The request has more than one possible response. The user-agent or user should choose one of them. (There is no standardized way of choosing one of the responses, but HTML links to the possibilities are recommended so the user can pick.)</summary>
    /// <value>300</value>
    /// <see href="https://developer.mozilla.org/en-US/docs/Web/HTTP/Status/300" />
    [Display(
        Name = "Multiple Choices",
        Description = "The request has more than one possible response. The user-agent or user should choose one of them. (There is no standardized way of choosing one of the responses, but HTML links to the possibilities are recommended so the user can pick.)"
    )]
    [Uri($"{UriBase}300")]
    MultipleChoices = 300,

    ///// <summary>The URL of the requested resource has been changed permanently. This and all future requests should be directed to the given URI.</summary>
    /// <summary>The shit you're looking for ain't here any more.  Look over here instead.</summary>
    /// <value>301</value>
    /// <see href="https://developer.mozilla.org/en-US/docs/Web/HTTP/Status/301" />
    [Display(
        Name = "Moved Permanently",
        // Description = "The URL of the requested resource has been changed permanently. This and all future requests should be directed to the given URI."
        Description = "The shit you're looking for ain't here any more.  Look over here instead."
    )]
    [Uri($"{UriBase}301")]
    MovedPermanently = 301,

    ///// <summary>Tells the client to look at (browse to) another URL. The HTTP/1.0 specification required the client to perform a temporary redirect with the same method (the original describing phrase was "Moved Temporarily"),[9] but popular browsers implemented 302 redirects by changing the method to GET. Therefore, HTTP/1.1 added status codes 303 and 307 to distinguish between the two behaviors.</summary>
    /// <summary>The shit you're looking for has been moved, but it might move back so don't remember this redirection.  Just do it this once and keep asking me whenever you want the shit that you asked for.</summary>
    /// <value>302</value>
    /// <see href="https://developer.mozilla.org/en-US/docs/Web/HTTP/Status/302" />
    [Display(
        Name = "Found",
        // Description = "Tells the client to look at (browse to) another URL. The HTTP/1.0 specification required the client to perform a temporary redirect with the same method (the original describing phrase was \\\"Moved Temporarily\\\"), but popular browsers implemented 302 redirects by changing the method to GET. Therefore, HTTP/1.1 added status codes 303 and 307 to distinguish between the two behaviors."
        Description = "The shit you're looking for has been moved, but it might move back so don't remember this redirection.  Just do it this once and keep asking me whenever you want the shit that you asked for."
    )]
    [Uri($"{UriBase}302")]
    Found = 302,

    /// <summary>The response to the request can be found under another URI using the GET method. When received in response to a POST (or PUT/DELETE), the client should presume that the server has received the data and should issue a new GET request to the given URI.</summary>
    /// <value>303</value>
    /// <see href="https://developer.mozilla.org/en-US/docs/Web/HTTP/Status/303" />
    [Display(
        Name = "See Other",
        Description = "The response to the request can be found under another URI using the GET method. When received in response to a POST (or PUT/DELETE), the client should presume that the server has received the data and should issue a new GET request to the given URI."
    )]
    [Uri($"{UriBase}303")]
    SeeOther = 303,

    ///// <summary>Indicates that the resource has not been modified since the version specified by the request headers If-Modified-Since or If-None-Match. In such case, there is no need to retransmit the resource since the client still has a previously-downloaded copy.</summary>
    /// <summary>Nothing's new; you can use the copy that you already have.</summary>
    /// <value>304</value>
    /// <see href="https://developer.mozilla.org/en-US/docs/Web/HTTP/Status/304" />
    [Display(
        Name = "Not Modified",
        // Description = "Indicates that the resource has not been modified since the version specified by the request headers If-Modified-Since or If-None-Match. In such case, there is no need to retransmit the resource since the client still has a previously-downloaded copy."
        Description = "Nothing's new; you can use the copy that you already have."
    )]
    [Uri($"{UriBase}304")]
    NotModified = 304,

    /// <summary>The requested resource is available only through a proxy, the address for which is provided in the response. For security reasons, many HTTP clients (such as Mozilla Firefox and Internet Explorer) do not obey this status code.</summary>
    /// <value>305</value>
    /// <see href="https://developer.mozilla.org/en-US/docs/Web/HTTP/Status/305" />
    [Display(
        Name = "Use Proxy",
        Description = "The requested resource is available only through a proxy, the address for which is provided in the response. For security reasons, many HTTP clients (such as Mozilla Firefox and Internet Explorer) do not obey this status code."
    )]
    [Uri($"{UriBase}305")]
    UseProxy = 305,

    /// <summary>No longer used. Originally meant "Subsequent requests should use the specified proxy."</summary>
    /// <value>306</value>
    /// <see href="https://developer.mozilla.org/en-US/docs/Web/HTTP/Status/306" />
    [Display(
        Name = "Switch Proxy",
        Description = "No longer used. Originally meant \\\"Subsequent requests should use the specified proxy.\\\""
    )]
    [Uri($"{UriBase}306")]
    SwitchProxy = 306,

    /// <summary>In this case, the request should be repeated with another URI; however, future requests should still use the original URI. In contrast to how 302 was historically implemented, the request method is not allowed to be changed when reissuing the original request. For example, a POST request should be repeated using another POST request.</summary>
    /// <value>307</value>
    /// <see href="https://developer.mozilla.org/en-US/docs/Web/HTTP/Status/307" />
    [Display(
        Name = "Temporary Redirect",
        Description = "In this case, the request should be repeated with another URI; however, future requests should still use the original URI. In contrast to how 302 was historically implemented, the request method is not allowed to be changed when reissuing the original request. For example, a POST request should be repeated using another POST request."
    )]
    [Uri($"{UriBase}307")]
    TemporaryRedirect = 307,

    /// <summary>The request and all future requests should be repeated using another URI. 307 and 308 parallel the behaviors of 302 and 301, but do not allow the HTTP method to change. So, for example, submitting a form to a permanently redirected resource may continue smoothly.</summary>
    /// <value>308</value>
    /// <see href="https://developer.mozilla.org/en-US/docs/Web/HTTP/Status/308" />
    [Display(
        Name = "Permanent Redirect",
        Description = "The request and all future requests should be repeated using another URI. 307 and 308 parallel the behaviors of 302 and 301, but do not allow the HTTP method to change. So, for example, submitting a form to a permanently redirected resource may continue smoothly."
    )]
    [Uri($"{UriBase}308")]
    PermanentRedirect = 308,

    /// <summary>You dumb fuck!</summary>
    /// <value>400</value>
    /// <see href="https://developer.mozilla.org/en-US/docs/Web/HTTP/Status/400" />
    [Display(
        Name = "Bad Request",
        // Description = "The server cannot or will not process the request due to an apparent client error (e.g., malformed request syntax, size too large, invalid request message framing, or deceptive request routing)."
        Description = "You dumb fuck!"
    )]
    [Uri($"{UriBase}400")]
    BadRequest = 400,

    /// <summary>Similar to 403 Forbidden, but specifically for use when authentication is required and has failed or has not yet been provided. The response must include a WWW-Authenticate header field containing a challenge applicable to the requested resource.</summary>
    /// <value>401</value>
    /// <see href="https://developer.mozilla.org/en-US/docs/Web/HTTP/Status/401" />
    [Display(
        Name = "Unauthorized",
        Description = "Similar to 403 Forbidden, but specifically for use when authentication is required and has failed or has not yet been provided. The response must include a WWW-Authenticate header field containing a challenge applicable to the requested resource."
    )]
    [Uri($"{UriBase}401")]
    Unauthorized = 401,

    /// <summary>Reserved for future use. The original intention was that this code might be used as part of some form of digital cash or micropayment scheme, as proposed for example by GNU Taler,[60] but that has not yet happened, and this code is not usually used. Google Developers API uses this status if a particular developer has exceeded the daily limit on requests.[61] Sipgate uses this code if an account does not have sufficient funds to start a call.[62] Shopify uses this code when the store has not paid their fees and is temporarily disabled.[63] Stripe uses this code for failed payments where parameters were correct, for example blocked fraudulent payments.[64]</summary>
    /// <value>402</value>
    /// <see href="https://developer.mozilla.org/en-US/docs/Web/HTTP/Status/402" />
    [Display(
        Name = "Payment Required",
        Description = "Reserved for future use. The original intention was that this code might be used as part of some form of digital cash or micropayment scheme, as proposed for example by GNU Taler, but that has not yet happened, and this code is not usually used. Google Developers API uses this status if a particular developer has exceeded the daily limit on requests. Sipgate uses this code if an account does not have sufficient funds to start a call. Shopify uses this code when the store has not paid their fees and is temporarily disabled. Stripe uses this code for failed payments where parameters were correct, for example blocked fraudulent payments."
    )]
    [Uri($"{UriBase}402")]
    PaymentRequired = 402,

    /// <summary>The request was valid, but the server is refusing action. The user might not have the necessary permissions for a resource, or may need an account of some sort.</summary>
    /// <value>403</value>
    /// <see href="https://developer.mozilla.org/en-US/docs/Web/HTTP/Status/403" />
    [Display(
        Name = "Forbidden",
        Description = "The request was valid, but the server is refusing action. The user might not have the necessary permissions for a resource, or may need an account of some sort."
    )]
    [Uri($"{UriBase}403")]
    Forbidden = 403,

    /// <summary>The requested resource could not be found but may be available in the future. Subsequent requests by the client are permissible.</summary>
    /// <value>404</value>
    /// <see href="https://developer.mozilla.org/en-US/docs/Web/HTTP/Status/404" />
    [Display(
        Name = "Not Found",
        Description = "The requested resource could not be found but may be available in the future. Subsequent requests by the client are permissible."
    )]
    [Uri($"{UriBase}404")]
    NotFound = 404,

    /// <summary>A request method is not supported for the requested resource; for example, a GET request on a form that requires data to be presented via POST, or a PUT request on a read-only resource.</summary>
    /// <value>405</value>
    /// <see href="https://developer.mozilla.org/en-US/docs/Web/HTTP/Status/405" />
    [Display(
        Name = "Method Not Allowed",
        Description = "A request method is not supported for the requested resource; for example, a GET request on a form that requires data to be presented via POST, or a PUT request on a read-only resource."
    )]
    [Uri($"{UriBase}405")]
    MethodNotAllowed = 405,

    /// <summary>The requested resource is capable of generating only content not acceptable according to the Accept headers sent in the request.</summary>
    /// <value>406</value>
    /// <see href="https://developer.mozilla.org/en-US/docs/Web/HTTP/Status/406" />
    [Display(
        Name = "Not Acceptable",
        Description = "The requested resource is capable of generating only content not acceptable according to the Accept headers sent in the request."
    )]
    [Uri($"{UriBase}406")]
    NotAcceptable = 406,

    /// <summary>The client must first authenticate itself with the proxy.</summary>
    /// <value>407</value>
    /// <see href="https://developer.mozilla.org/en-US/docs/Web/HTTP/Status/407" />
    [Display(
        Name = "Proxy Authentication Required",
        Description = "The client must first authenticate itself with the proxy."
    )]
    [Uri($"{UriBase}407")]
    ProxyAuthenticationRequired = 407,

    /// <summary>The server timed out waiting for the request. According to HTTP specifications: "The client did not produce a request within the time that the server was prepared to wait. The client MAY repeat the request without modifications at any later time."</summary>
    /// <value>408</value>
    /// <see href="https://developer.mozilla.org/en-US/docs/Web/HTTP/Status/408" />
    [Display(
        Name = "Request Timeout",
        Description = "The server timed out waiting for the request. According to HTTP specifications: \\\"The client did not produce a request within the time that the server was prepared to wait. The client MAY repeat the request without modifications at any later time.\\\""
    )]
    [Uri($"{UriBase}408")]
    RequestTimeout = 408,

    /// <summary>Indicates that the request could not be processed because of conflict in the current state of the resource, such as an edit conflict between multiple simultaneous updates.</summary>
    /// <value>409</value>
    /// <see href="https://developer.mozilla.org/en-US/docs/Web/HTTP/Status/409" />
    [Display(
        Name = "Conflict",
        Description = "Indicates that the request could not be processed because of conflict in the current state of the resource, such as an edit conflict between multiple simultaneous updates."
    )]
    [Uri($"{UriBase}409")]
    Conflict = 409,

    /// <summary>Indicates that the resource requested is no longer available and will not be available again. This should be used when a resource has been intentionally removed and the resource should be purged. Upon receiving a 410 status code, the client should not request the resource in the future. Clients such as search engines should remove the resource from their indices.[41] Most use cases do not require clients and search engines to purge the resource, and a "404 Not Found" may be used instead.</summary>
    /// <value>410</value>
    /// <see href="https://developer.mozilla.org/en-US/docs/Web/HTTP/Status/410" />
    [Display(
        Name = "Gone",
        Description = "Indicates that the resource requested is no longer available and will not be available again. This should be used when a resource has been intentionally removed and the resource should be purged. Upon receiving a 410 status code, the client should not request the resource in the future. Clients such as search engines should remove the resource from their indices. Most use cases do not require clients and search engines to purge the resource, and a \\\"404 Not Found\\\" may be used instead."
    )]
    [Uri($"{UriBase}410")]
    Gone = 410,

    /// <summary>The request did not specify the length of its content, which is required by the requested resource.</summary>
    /// <value>411</value>
    /// <see href="https://developer.mozilla.org/en-US/docs/Web/HTTP/Status/411" />
    [Display(
        Name = "Length Required",
        Description = "The request did not specify the length of its content, which is required by the requested resource."
    )]
    [Uri($"{UriBase}411")]
    LengthRequired = 411,

    /// <summary>The server does not meet one of the preconditions that the requester put on the request.</summary>
    /// <value>412</value>
    /// <see href="https://developer.mozilla.org/en-US/docs/Web/HTTP/Status/412" />
    [Display(
        Name = "Precondition Failed",
        Description = "The server does not meet one of the preconditions that the requester put on the request."
    )]
    [Uri($"{UriBase}412")]
    PreconditionFailed = 412,

    /// <summary>The request is larger than the server is willing or able to process. Previously called "Request Entity Too Large".[44]</summary>
    /// <value>413</value>
    /// <see href="https://developer.mozilla.org/en-US/docs/Web/HTTP/Status/413" />
    [Display(
        Name = "Payload Too Large",
        Description = "The request is larger than the server is willing or able to process. Previously called \\\"Request Entity Too Large\\\"."
    )]
    [Uri($"{UriBase}413")]
    PayloadTooLarge = 413,

    /// <summary>The URI provided was too long for the server to process. Often the result of too much data being encoded as a query-string of a GET request, in which case it should be converted to a POST request.[45] Called "Request-URI Too Long" previously.</summary>
    /// <value>414</value>
    /// <see href="https://developer.mozilla.org/en-US/docs/Web/HTTP/Status/414" />
    [Display(
        Name = "URI Too Long",
        Description = "The URI provided was too long for the server to process. Often the result of too much data being encoded as a query-string of a GET request, in which case it should be converted to a POST request. Called \\\"Request-URI Too Long\\\" previously."
    )]
    [Uri($"{UriBase}414")]
    URITooLong = 414,

    /// <summary>The request entity has a media type which the server or resource does not support. For example, the client uploads an image as image/svg+xml, but the server requires that images use a different format.</summary>
    /// <value>415</value>
    /// <see href="https://developer.mozilla.org/en-US/docs/Web/HTTP/Status/415" />
    [Display(
        Name = "Unsupported Media Type",
        Description = "The request entity has a media type which the server or resource does not support. For example, the client uploads an image as image/svg+xml, but the server requires that images use a different format."
    )]
    [Uri($"{UriBase}415")]
    UnsupportedMediaType = 415,

    /// <summary>The client has asked for a portion of the file (byte serving), but the server cannot supply that portion. For example, if the client asked for a part of the file that lies beyond the end of the file.[46] Called "Requested Range Not Satisfiable" previously.</summary>
    /// <value>416</value>
    /// <see href="https://developer.mozilla.org/en-US/docs/Web/HTTP/Status/416" />
    [Display(
        Name = "Range Not Satisfiable",
        Description = "The client has asked for a portion of the file (byte serving), but the server cannot supply that portion. For example, if the client asked for a part of the file that lies beyond the end of the file. Called \\\"Requested Range Not Satisfiable\\\" previously."
    )]
    [Uri($"{UriBase}416")]
    RangeNotSatisfiable = 416,

    /// <summary>The server cannot meet the requirements of the Expect request-header field.</summary>
    /// <value>417</value>
    /// <see href="https://developer.mozilla.org/en-US/docs/Web/HTTP/Status/417" />
    [Display(
        Name = "Expectation Failed",
        Description = "The server cannot meet the requirements of the Expect request-header field."
    )]
    [Uri($"{UriBase}417")]
    ExpectationFailed = 417,

    /// <summary>This code was defined in 1998 as one of the traditional IETF April Fools' jokes, in RFC 2324, Hyper Text Coffee Pot Control Protocol, and is not expected to be implemented by actual HTTP servers. The RFC specifies this code should be returned by teapots requested to brew coffee.[53] This HTTP status is used as an Easter egg in some websites, including Google.com.</summary>
    /// <value>418</value>
    /// <see href="https://developer.mozilla.org/en-US/docs/Web/HTTP/Status/418" />
    [Display(
        Name = "I'm a teapot",
        Description = "This code was defined in 1998 as one of the traditional IETF April Fools' jokes, in RFC 2324, Hyper Text Coffee Pot Control Protocol, and is not expected to be implemented by actual HTTP servers. The RFC specifies this code should be returned by teapots requested to brew coffee. This HTTP status is used as an Easter egg in some websites, including Google.com."
    )]
    [Uri($"{UriBase}418")]
    ImATeapot = 418,

    /// <summary>Used by the Laravel Framework when a CSRF Token is missing or expired.<summary>
    /// <value>419</value>
    /// <see href="https://developer.mozilla.org/en-US/docs/Web/HTTP/Status/419" />
    [Display(
        Name = "Page Expired",
        Description = "Used by the Laravel Framework when a CSRF Token is missing or expired."
    )]
    [Uri($"{UriBase}419")]
    PageExpired = 419,

    /// <summary>Returned by version 1 of the Twitter Search and Trends API when the client is being rate limited; versions 1.1 and later use the 429 Too Many Requests response code instead. The phrase "Enhance your calm" comes from the 1993 movie Demolition Man, and its association with this number is likely a reference to cannabis.</summary>
    /// <value>420</value>
    /// <see href="https://developer.mozilla.org/en-US/docs/Web/HTTP/Status/420" />
    [Display(
        Name = "Enhance Your Calm",
        Description = "Returned by version 1 of the Twitter Search and Trends API when the client is being rate limited; versions 1.1 and later use the 429 Too Many Requests response code instead. The phrase \\\"Enhance your calm\\\" comes from the 1993 movie Demolition Man, and its association with this number is likely a reference to cannabis."
    )]
    [Uri($"{UriBase}420")]
    EnhanceYourCalm = 420,

    /// <summary>The request was directed at a server that is not able to produce a response (for example because of connection reuse).</summary>
    /// <value>421</value>
    /// <see href="https://developer.mozilla.org/en-US/docs/Web/HTTP/Status/421" />
    [Display(
        Name = "Misdirected Request",
        Description = "The request was directed at a server that is not able to produce a response (for example because of connection reuse)."
    )]
    [Uri($"{UriBase}421")]
    MisdirectedRequest = 421,

    /// <summary>The request was well-formed but was unable to be followed due to semantic errors.</summary>
    /// <value>422</value>
    /// <see href="https://developer.mozilla.org/en-US/docs/Web/HTTP/Status/422" />
    [Display(
        Name = "Unprocessable Entity",
        Description = "The request was well-formed but was unable to be followed due to semantic errors."
    )]
    [Uri($"{UriBase}422")]
    UnprocessableEntity = 422,

    /// <summary>The resource that is being accessed is locked.</summary>
    /// <value>423</value>
    /// <see href="https://developer.mozilla.org/en-US/docs/Web/HTTP/Status/423" />
    [Display(Name = "Locked", Description = "The resource that is being accessed is locked.")]
    [Uri($"{UriBase}423")]
    Locked = 423,

    /// <summary>The request failed due to failure of a previous request (e.g., a PROPPATCH).</summary>
    /// <value>424</value>
    /// <see href="https://developer.mozilla.org/en-US/docs/Web/HTTP/Status/424" />
    [Display(
        Name = "Failed Dependency",
        Description = "The request failed due to failure of a previous request (e.g., a PROPPATCH)."
    )]
    [Uri($"{UriBase}424")]
    FailedDependency = 424,

    /// <summary>The client should switch to a different protocol such as TLS/1.0, given in the Upgrade header field.</summary>
    /// <value>426</value>
    /// <see href="https://developer.mozilla.org/en-US/docs/Web/HTTP/Status/426" />
    [Display(
        Name = "Upgrade Required",
        Description = "The client should switch to a different protocol such as TLS/1.0, given in the Upgrade header field."
    )]
    [Uri($"{UriBase}426")]
    UpgradeRequired = 426,

    /// <summary>The origin server requires the request to be conditional. Intended to prevent the 'lost update' problem, where a client GETs a resource's state, modifies it, and PUTs it back to the server, when meanwhile a third party has modified the state on the server, leading to a conflict.</summary>
    /// <value>428</value>
    /// <see href="https://developer.mozilla.org/en-US/docs/Web/HTTP/Status/428" />
    [Display(
        Name = "Precondition Required",
        Description = "The origin server requires the request to be conditional. Intended to prevent the 'lost update' problem, where a client GETs a resource's state, modifies it, and PUTs it back to the server, when meanwhile a third party has modified the state on the server, leading to a conflict."
    )]
    [Uri($"{UriBase}428")]
    PreconditionRequired = 428,

    /// <summary>The user has sent too many requests in a given amount of time. Intended for use with rate-limiting schemes.</summary>
    /// <value>429</value>
    /// <see href="https://developer.mozilla.org/en-US/docs/Web/HTTP/Status/429" />
    [Display(
        Name = "Too Many Requests",
        Description = "The user has sent too many requests in a given amount of time. Intended for use with rate-limiting schemes."
    )]
    [Uri($"{UriBase}429")]
    TooManyRequests = 429,

    /// <summary>The server is unwilling to process the request because either an individual header field, or all the header fields collectively, are too large.</summary>
    /// <value>431</value>
    /// <see href="https://developer.mozilla.org/en-US/docs/Web/HTTP/Status/431" />
    [Display(
        Name = "Request Header Fields Too Large",
        Description = "The server is unwilling to process the request because either an individual header field, or all the header fields collectively, are too large."
    )]
    [Uri($"{UriBase}431")]
    RequestHeaderFieldsTooLarge = 431,

    /// <summary>Used in Exchange ActiveSync if there either is a more efficient server to use or the server cannot access the users' mailbox.[citation needed]</summary>
    /// <value>449</value>
    /// <see href="https://developer.mozilla.org/en-US/docs/Web/HTTP/Status/449" />
    [Display(
        Name = "Retry With",
        Description = "Used in Exchange ActiveSync if there either is a more efficient server to use or the server cannot access the users' mailbox."
    )]
    [Uri($"{UriBase}449")]
    RetryWith = 449,

    /// <summary>A server operator has received a legal demand to deny access to a resource or to a set of resources that includes the requested resource.[60] The code 451 was chosen as a reference to the novel Fahrenheit 451 (see the Acknowledgements in the RFC).</summary>
    /// <value>451</value>
    /// <see href="https://developer.mozilla.org/en-US/docs/Web/HTTP/Status/451" />
    [Display(
        Name = "Unavailable For Legal Reasons",
        Description = "A server operator has received a legal demand to deny access to a resource or to a set of resources that includes the requested resource. The code 451 was chosen as a reference to the novel Fahrenheit 451 (see the Acknowledgements in the RFC)."
    )]
    [Uri($"{UriBase}451")]
    UnavailableForLegalReasons = 451,

    /// <summary>A Microsoft extension. The request should be retried after performing the appropriate action.</summary>
    /// <value>451</value>
    /// <see href="https://developer.mozilla.org/en-US/docs/Web/HTTP/Status/451" />
    [Display(
        Name = "Redirect",
        Description = "A Microsoft extension. The request should be retried after performing the appropriate action."
    )]
    [Uri($"{UriBase}451")]
    Redirect = 451,

    /// <summary>Returned by ArcGIS for Server. A code of 498 indicates an expired or otherwise invalid token.</summary>
    /// <value>498</value>
    /// <see href="https://developer.mozilla.org/en-US/docs/Web/HTTP/Status/498" />
    [Display(
        Name = "Invalid Token",
        Description = "Returned by ArcGIS for Server. A code of 498 indicates an expired or otherwise invalid token."
    )]
    [Uri($"{UriBase}498")]
    InvalidToken = 498,

    /// <summary>Returned by ArcGIS for Server. A code of 499 indicates that a token is required (if no token was submitted).</summary>
    /// <value>499</value>
    /// <see href="https://developer.mozilla.org/en-US/docs/Web/HTTP/Status/499" />
    [Display(
        Name = "Token Required",
        Description = "Returned by ArcGIS for Server. A code of 499 indicates that a token is required (if no token was submitted)."
    )]
    [Uri($"{UriBase}499")]
    TokenRequired = 499,

    /// <summary>A generic error message, given when an unexpected condition was encountered and no more specific message is suitable.</summary>
    /// <value>500</value>
    /// <see href="https://developer.mozilla.org/en-US/docs/Web/HTTP/Status/500" />
    [Display(
        Name = "Internal Server Error",
        Description = "A generic error message, given when an unexpected condition was encountered and no more specific message is suitable."
    )]
    [Uri($"{UriBase}500")]
    InternalServerError = 500,

    /// <summary>The server either does not recognize the request method, or it lacks the ability to fulfil the request. Usually this implies future availability (e.g., a new feature of a web-service API).</summary>
    /// <value>501</value>
    /// <see href="https://developer.mozilla.org/en-US/docs/Web/HTTP/Status/501" />
    [Display(
        Name = "Not Implemented",
        Description = "The server either does not recognize the request method, or it lacks the ability to fulfil the request. Usually this implies future availability (e.g., a new feature of a web-service API)."
    )]
    [Uri($"{UriBase}501")]
    NotImplemented = 501,

    /// <summary>The server was acting as a gateway or proxy and received an invalid response from the upstream server.</summary>
    /// <value>502</value>
    /// <see href="https://developer.mozilla.org/en-US/docs/Web/HTTP/Status/502" />
    [Display(
        Name = "Bad Gateway",
        Description = "The server was acting as a gateway or proxy and received an invalid response from the upstream server."
    )]
    [Uri($"{UriBase}502")]
    BadGateway = 502,

    /// <summary>The server cannot handle the request (because it is overloaded or down for maintenance). Generally, this is a temporary state.</summary>
    /// <value>503</value>
    /// <see href="https://developer.mozilla.org/en-US/docs/Web/HTTP/Status/503" />
    [Display(
        Name = "Service Unavailable",
        Description = "The server cannot handle the request (because it is overloaded or down for maintenance). Generally, this is a temporary state."
    )]
    [Uri($"{UriBase}503")]
    ServiceUnavailable = 503,

    /// <summary>The server was acting as a gateway or proxy and did not receive a timely response from the upstream server.</summary>
    /// <value>504</value>
    /// <see href="https://developer.mozilla.org/en-US/docs/Web/HTTP/Status/504" />
    [Display(
        Name = "Gateway Timeout",
        Description = "The server was acting as a gateway or proxy and did not receive a timely response from the upstream server."
    )]
    [Uri($"{UriBase}504")]
    GatewayTimeout = 504,

    /// <summary>The server does not support the HTTP protocol version used in the request.</summary>
    /// <value>505</value>
    /// <see href="https://developer.mozilla.org/en-US/docs/Web/HTTP/Status/505" />
    [Display(
        Name = "HTTP Version Not Supported",
        Description = "The server does not support the HTTP protocol version used in the request."
    )]
    [Uri($"{UriBase}505")]
    HTTPVersionNotSupported = 505,

    /// <summary>Transparent content negotiation for the request results in a circular reference.</summary>
    /// <value>506</value>
    /// <see href="https://developer.mozilla.org/en-US/docs/Web/HTTP/Status/506" />
    [Display(
        Name = "Variant Also Negotiates",
        Description = "Transparent content negotiation for the request results in a circular reference."
    )]
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
    /// <see href="https://developer.mozilla.org/en-US/docs/Web/HTTP/Status/508" />
    [Display(
        Name = "Loop Detected",
        Description = "The server detected an infinite loop while processing the request (sent in lieu of 208 Already Reported)."
    )]
    [Uri($"{UriBase}508")]
    LoopDetected = 508,

    /// <summary>Further extensions to the request are required for the server to fulfil it.</summary>
    /// <value>510</value>
    /// <see href="https://developer.mozilla.org/en-US/docs/Web/HTTP/Status/510" />
    [Display(
        Name = "Not Extended",
        Description = "Further extensions to the request are required for the server to fulfil it."
    )]
    [Uri($"{UriBase}510")]
    NotExtended = 510,

    /// <summary>The client needs to authenticate to gain network access. Intended for use by intercepting proxies used to control access to the network (e.g., "captive portals" used to require agreement to Terms of Service before granting full Internet access via a Wi-Fi hotspot).</summary>
    /// <value>511</value>
    /// <see href="https://developer.mozilla.org/en-US/docs/Web/HTTP/Status/511" />
    [Display(
        Name = "Network Authentication Required",
        Description = "The client needs to authenticate to gain network access. Intended for use by intercepting proxies used to control access to the network (e.g., \\\"captive portals\\\" used to require agreement to Terms of Service before granting full Internet access via a Wi-Fi hotspot)."
    )]
    [Uri($"{UriBase}511")]
    NetworkAuthenticationRequired = 511,

    /// <summary>This status code is not specified in any RFCs. Its use is unknown.</summary>
    /// <value>520</value>
    /// <see href="https://developer.mozilla.org/en-US/docs/Web/HTTP/Status/520" />
    [Display(
        Name = "Unknown Error",
        Description = "This status code is not specified in any RFCs. Its use is unknown."
    )]
    [Uri($"{UriBase}520")]
    UnknownError = 520,

    /// <summary>The origin server has refused the connection from the client.</summary>
    /// <value>521</value>
    /// <see href="https://developer.mozilla.org/en-US/docs/Web/HTTP/Status/521" />
    [Display(
        Name = "Web Server Is Down",
        Description = "The origin server has refused the connection from the client."
    )]
    [Uri($"{UriBase}521")]
    WebServerIsDown = 521,

    /// <summary>The connection to the origin server timed out.</summary>
    /// <value>522</value>
    /// <see href="https://developer.mozilla.org/en-US/docs/Web/HTTP/Status/522" />
    [Display(
        Name = "Connection Timed Out",
        Description = "The connection to the origin server timed out."
    )]
    [Uri($"{UriBase}522")]
    ConnectionTimedOut = 522,

    /// <summary>The origin server refused to accept the request.</summary>
    /// <value>523</value>
    /// <see href="https://developer.mozilla.org/en-US/docs/Web/HTTP/Status/523" />
    [Display(
        Name = "Origin Is Unreachable",
        Description = "The origin server refused to accept the request."
    )]
    [Uri($"{UriBase}523")]
    OriginIsUnreachable = 523,

    /// <summary>The server is currently unavailable (because it is overloaded or down for maintenance). Generally, this is a temporary state.</summary>
    /// <value>524</value>
    /// <see href="https://developer.mozilla.org/en-US/docs/Web/HTTP/Status/524" />
    [Display(
        Name = "A Timeout Occurred",
        Description = "The server is currently unavailable (because it is overloaded or down for maintenance). Generally, this is a temporary state."
    )]
    [Uri($"{UriBase}524")]
    ATimeoutOccurred = 524,

    /// <summary>The SSL certificate presented by the origin server is not trusted by the system for one or more of the following reasons: 1. The server is self-signed. 2. The server is signed by a certificate authority that is not well-known. 3. The server is signed by a certificate authority that is not well-known by your system's trust store.</summary>
    /// <value>525</value>
    /// <see href="https://developer.mozilla.org/en-US/docs/Web/HTTP/Status/525" />
    [Display(
        Name = "SSL Handshake Failed",
        Description = "The SSL certificate presented by the origin server is not trusted by the system for one or more of the following reasons: 1. The server is self-signed. 2. The server is signed by a certificate authority that is not well-known. 3. The server is signed by a certificate authority that is not well-known by your system's trust store."
    )]
    [Uri($"{UriBase}525")]
    SSLHandshakeFailed = 525,

    /// <summary>The origin server has refused to accept the request because a new SSL handshake is required.</summary>
    /// <value>526</value>
    /// <see href="https://developer.mozilla.org/en-US/docs/Web/HTTP/Status/526" />
    /// <see href="https://developer.mozilla.org/en-US/docs/Web/HTTP/Status/526" />
    [Display(
        Name = "Invalid SSL Certificate",
        Description = "The origin server has refused to accept the request because a new SSL handshake is required."
    )]
    [Uri($"{UriBase}526")]
    InvalidSSLCertificate = 526,

    /// <summary>Used by Cloudflare and Cloud Foundry's gorouter to indicate failure to validate the SSL/TLS certificate that the origin server presented.</summary>
    /// <value>527</value>
    /// <see href="https://developer.mozilla.org/en-US/docs/Web/HTTP/Status/527" />
    [Display(
        Name = "Railgun Error",
        Description = "Used by Cloudflare and Cloud Foundry's gorouter to indicate failure to validate the SSL/TLS certificate that the origin server presented."
    )]
    [Uri($"{UriBase}527")]
    RailgunError = 527,

    /// <summary>This status code is not specified in any RFC and is returned by certain services, for instance Microsoft Azure and CloudFlare servers: 1. Microsoft Azure: The server timed out waiting for the request. According to Microsoft Support, this error occurs because a script that uses the WinHTTP library sends an HTTP request without a request header. 2. CloudFlare: The request timed out or failed after the WAN connection had been established.</summary>
    /// <value>529</value>
    /// <see href="https://developer.mozilla.org/en-US/docs/Web/HTTP/Status/529" />
    [Display(
        Name = "Site Is Overloaded",
        Description = "This status code is not specified in any RFC and is returned by certain services, for instance Microsoft Azure and CloudFlare servers: 1. Microsoft Azure: The server timed out waiting for the request. According to Microsoft Support, this error occurs because a script that uses the WinHTTP library sends an HTTP request without a request header. 2. CloudFlare: The request timed out or failed after the WAN connection had been established."
    )]
    [Uri($"{UriBase}529")]
    SiteIsOverloaded = 529,

    /// <summary>This status code is not specified in any RFCs, but is used by CloudFlare's reverse proxies to signal an "unknown connection issue between CloudFlare and the origin web server" to a client in front of the proxy.</summary>
    /// <value>530</value>
    /// <see href="https://developer.mozilla.org/en-US/docs/Web/HTTP/Status/530" />
    [Display(
        Name = "Site Is Frozen",
        Description = "This status code is not specified in any RFCs, but is used by CloudFlare's reverse proxies to signal an \\\"unknown connection issue between CloudFlare and the origin web server\\\" to a client in front of the proxy."
    )]
    [Uri($"{UriBase}530")]
    SiteIsFrozen = 530
}
