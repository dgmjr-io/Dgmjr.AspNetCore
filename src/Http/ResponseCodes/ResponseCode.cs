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
    Continue = 100,

    /// <summary>The requester has asked the server to switch protocols and the server has agreed to do so.</summary>
    /// <value>101</value>
    [Display(
        Name = "Switching Protocols",
        ShortName = "SwitchingProtocols",
        Description = "The requester has asked the server to switch protocols and the server has agreed to do so."
    )]
    SwitchingProtocols = 101,

    /// <summary>Used to return some response headers before final HTTP message.</summary>
    /// <value>102</value>
    [Display(
        Name = "Processing",
        Description = "A WebDAV request may contain many sub-requests involving file operations, requiring a long time to complete the request. This code indicates that the server has received and is processing the request, but no response is available yet.[3] This prevents the client from timing out and assuming the request was lost. The status code is deprecated."
    )]
    Processing = 102,

    /// <summary>Used to return some response headers before final HTTP message.</summary>
    /// <value>103</value>
    [Display(
        Name = "Early Hints",
        Description = "Used to return some response headers before final HTTP message."
    )]
    EarlyHinds = 103,

    /// <summary>The request has succeeded. The meaning of the success depends on the HTTP method:</summary>
    /// <value>200</value>
    [Display(
        Name = "OK",
        Description = "The request has succeeded. The meaning of the success depends on the HTTP method:"
    )]
    OK = 200,

    /// <summary>The request has succeeded and a new resource has been created as a result. This is typically the response sent after a PUT request.</summary>
    /// <value>201</value>
    [Display(
        Name = "Created",
        Description = "The request has succeeded and a new resource has been created as a result. This is typically the response sent after a PUT request."
    )]
    Created = 201,

    /// <summary>The request has been received but not yet acted upon. It is non-committal, meaning that there is no way in HTTP to later send an asynchronous response indicating the outcome of processing the request. It is intended for cases where another process or server handles the request, or for batch processing.</summary>
    /// <value>202</value>
    [Display(
        Name = "Accepted",
        Description = "The request has been received but not yet acted upon. It is non-committal, meaning that there is no way in HTTP to later send an asynchronous response indicating the outcome of processing the request. It is intended for cases where another process or server handles the request, or for batch processing."
    )]
    Accepted = 202,

    /// <summary>The server is a transforming proxy (e.g. a Web accelerator) that received a 200 OK from its origin, but is returning a modified version of the origin's response.</summary>
    /// <value>203</value>
    [Display(
        Name = "Non-Authoritative Information",
        ShortName = "NonAuthoritativeInformation",
        Description = "The server is a transforming proxy (e.g. a Web accelerator) that received a 200 OK from its origin, but is returning a modified version of the origin's response."
    )]
    NonAuthoritativeInformation = 203,

    /// <summary>The server successfully processed the request and is not returning any content.</summary>
    /// <value>204</value>
    [Display(
        Name = "No Content",
        ShortName = "NoContent",
        Description = "The server successfully processed the request and is not returning any content."
    )]
    NoContent = 204,

    /// <summary>The server successfully processed the request, but is not returning any content. Unlike a 204 response, this response requires that the requester reset the document view.</summary>
    /// <value>205</value>
    [Display(
        Name = "Reset Content",
        ShortName = "ResetContent",
        Description = "The server successfully processed the request, but is not returning any content. Unlike a 204 response, this response requires that the requester reset the document view."
    )]
    ResetContent = 205,

    /// <summary>The server is delivering only part of the resource (byte serving) due to a range header sent by the client. The range header is used by HTTP clients to enable resuming of interrupted downloads, or split a download into multiple simultaneous streams.</summary>
    /// <value>206</value>
    [Display(
        Name = "Partial Content",
        ShortName = "PartialContent",
        Description = "The server is delivering only part of the resource (byte serving) due to a range header sent by the client. The range header is used by HTTP clients to enable resuming of interrupted downloads, or split a download into multiple simultaneous streams."
    )]
    PartialContent = 206,

    /// <summary>The message body that follows is an XML message and can contain a number of separate response codes, depending on how many sub-requests were made.</summary>
    /// <value>207</value>
    [Display(
        Name = "Multi-Status",
        ShortName = "MultiStatus",
        Description = "The message body that follows is an XML message and can contain a number of separate response codes, depending on how many sub-requests were made."
    )]
    MultiStatus = 207,

    /// <summary>The members of a DAV binding have already been enumerated in a preceding part of the (multistatus) response, and are not being included again.</summary>
    /// <value>208</value>
    [Display(
        Name = "Already Reported",
        ShortName = "AlreadyReported",
        Description = "The members of a DAV binding have already been enumerated in a preceding part of the (multistatus) response, and are not being included again."
    )]
    AlreadyReported = 208,

    /// <summary>The server has fulfilled a request for the resource, and the response is a representation of the result of one or more instance-manipulations applied to the current instance.</summary>
    /// <value>226</value>
    [Display(
        Name = "IM Used",
        Description = "The server has fulfilled a request for the resource, and the response is a representation of the result of one or more instance-manipulations applied to the current instance."
    )]
    IMUsed = 226,

    /// <summary>The request has more than one possible response. The user-agent or user should choose one of them. (There is no standardized way of choosing one of the responses, but HTML links to the possibilities are recommended so the user can pick.)</summary>
    /// <value>300</value>
    [Display(
        Name = "Multiple Choices",
        Description = "The request has more than one possible response. The user-agent or user should choose one of them. (There is no standardized way of choosing one of the responses, but HTML links to the possibilities are recommended so the user can pick.)"
    )]
    MultipleChoices = 300,

    /// <summary>The URL of the requested resource has been changed permanently. This and all future requests should be directed to the given URI.</summary>
    /// <value>301</value>
    [Display(
        Name = "Moved Permanently",
        Description = "The URL of the requested resource has been changed permanently. This and all future requests should be directed to the given URI."
    )]
    MovedPermanently = 301,

    /// <summary>Tells the client to look at (browse to) another URL. The HTTP/1.0 specification required the client to perform a temporary redirect with the same method (the original describing phrase was "Moved Temporarily"),[9] but popular browsers implemented 302 redirects by changing the method to GET. Therefore, HTTP/1.1 added status codes 303 and 307 to distinguish between the two behaviors.</summary>
    /// <value>302</value>
    [Display(
        Name = "Found",
        Description = "Tells the client to look at (browse to) another URL. The HTTP/1.0 specification required the client to perform a temporary redirect with the same method (the original describing phrase was \\\"Moved Temporarily\\\"), but popular browsers implemented 302 redirects by changing the method to GET. Therefore, HTTP/1.1 added status codes 303 and 307 to distinguish between the two behaviors."
    )]
    Found = 302,

    /// <summary>The response to the request can be found under another URI using the GET method. When received in response to a POST (or PUT/DELETE), the client should presume that the server has received the data and should issue a new GET request to the given URI.</summary>
    /// <value>303</value>
    [Display(
        Name = "See Other",
        Description = "The response to the request can be found under another URI using the GET method. When received in response to a POST (or PUT/DELETE), the client should presume that the server has received the data and should issue a new GET request to the given URI."
    )]
    SeeOther = 303,

    /// <summary>Indicates that the resource has not been modified since the version specified by the request headers If-Modified-Since or If-None-Match. In such case, there is no need to retransmit the resource since the client still has a previously-downloaded copy.</summary>
    /// <value>304</value>
    [Display(
        Name = "Not Modified",
        Description = "Indicates that the resource has not been modified since the version specified by the request headers If-Modified-Since or If-None-Match. In such case, there is no need to retransmit the resource since the client still has a previously-downloaded copy."
    )]
    NotModified = 304,

    /// <summary>The requested resource is available only through a proxy, the address for which is provided in the response. For security reasons, many HTTP clients (such as Mozilla Firefox and Internet Explorer) do not obey this status code.</summary>
    /// <value>305</value>
    [Display(
        Name = "Use Proxy",
        Description = "The requested resource is available only through a proxy, the address for which is provided in the response. For security reasons, many HTTP clients (such as Mozilla Firefox and Internet Explorer) do not obey this status code."
    )]
    UseProxy = 305,

    /// <summary>No longer used. Originally meant "Subsequent requests should use the specified proxy."</summary>
    /// <value>306</value>
    [Display(
        Name = "Switch Proxy",
        Description = "No longer used. Originally meant \\\"Subsequent requests should use the specified proxy.\\\""
    )]
    SwitchProxy = 306,

    /// <summary>In this case, the request should be repeated with another URI; however, future requests should still use the original URI. In contrast to how 302 was historically implemented, the request method is not allowed to be changed when reissuing the original request. For example, a POST request should be repeated using another POST request.</summary>
    /// <value>307</value>
    [Display(
        Name = "Temporary Redirect",
        Description = "In this case, the request should be repeated with another URI; however, future requests should still use the original URI. In contrast to how 302 was historically implemented, the request method is not allowed to be changed when reissuing the original request. For example, a POST request should be repeated using another POST request."
    )]
    TemporaryRedirect = 307,

    /// <summary>The request and all future requests should be repeated using another URI. 307 and 308 parallel the behaviors of 302 and 301, but do not allow the HTTP method to change. So, for example, submitting a form to a permanently redirected resource may continue smoothly.</summary>
    /// <value>308</value>
    [Display(
        Name = "Permanent Redirect",
        Description = "The request and all future requests should be repeated using another URI. 307 and 308 parallel the behaviors of 302 and 301, but do not allow the HTTP method to change. So, for example, submitting a form to a permanently redirected resource may continue smoothly."
    )]
    PermanentRedirect = 308,

    /// <summary>The server cannot or will not process the request due to an apparent client error (e.g., malformed request syntax, size too large, invalid request message framing, or deceptive request routing).</summary>
    /// <value>400</value>
    [Display(
        Name = "Bad Request",
        Description = "The server cannot or will not process the request due to an apparent client error (e.g., malformed request syntax, size too large, invalid request message framing, or deceptive request routing)."
    )]
    BadRequest = 400,

    /// <summary>Similar to 403 Forbidden, but specifically for use when authentication is required and has failed or has not yet been provided. The response must include a WWW-Authenticate header field containing a challenge applicable to the requested resource.</summary>
    /// <value>401</value>
    [Display(
        Name = "Unauthorized",
        Description = "Similar to 403 Forbidden, but specifically for use when authentication is required and has failed or has not yet been provided. The response must include a WWW-Authenticate header field containing a challenge applicable to the requested resource."
    )]
    Unauthorized = 401,

    /// <summary>Reserved for future use. The original intention was that this code might be used as part of some form of digital cash or micropayment scheme, as proposed for example by GNU Taler,[60] but that has not yet happened, and this code is not usually used. Google Developers API uses this status if a particular developer has exceeded the daily limit on requests.[61] Sipgate uses this code if an account does not have sufficient funds to start a call.[62] Shopify uses this code when the store has not paid their fees and is temporarily disabled.[63] Stripe uses this code for failed payments where parameters were correct, for example blocked fraudulent payments.[64]</summary>
    /// <value>402</value>
    [Display(
        Name = "Payment Required",
        Description = "Reserved for future use. The original intention was that this code might be used as part of some form of digital cash or micropayment scheme, as proposed for example by GNU Taler, but that has not yet happened, and this code is not usually used. Google Developers API uses this status if a particular developer has exceeded the daily limit on requests. Sipgate uses this code if an account does not have sufficient funds to start a call. Shopify uses this code when the store has not paid their fees and is temporarily disabled. Stripe uses this code for failed payments where parameters were correct, for example blocked fraudulent payments."
    )]
    PaymentRequired = 402,

    /// <summary>The request was valid, but the server is refusing action. The user might not have the necessary permissions for a resource, or may need an account of some sort.</summary>
    /// <value>403</value>
    [Display(
        Name = "Forbidden",
        Description = "The request was valid, but the server is refusing action. The user might not have the necessary permissions for a resource, or may need an account of some sort."
    )]
    Forbidden = 403,

    /// <summary>The requested resource could not be found but may be available in the future. Subsequent requests by the client are permissible.</summary>
    /// <value>404</value>
    [Display(
        Name = "Not Found",
        Description = "The requested resource could not be found but may be available in the future. Subsequent requests by the client are permissible."
    )]
    NotFound = 404,

    /// <summary>A request method is not supported for the requested resource; for example, a GET request on a form that requires data to be presented via POST, or a PUT request on a read-only resource.</summary>
    /// <value>405</value>
    [Display(
        Name = "Method Not Allowed",
        Description = "A request method is not supported for the requested resource; for example, a GET request on a form that requires data to be presented via POST, or a PUT request on a read-only resource."
    )]
    MethodNotAllowed = 405,

    /// <summary>The requested resource is capable of generating only content not acceptable according to the Accept headers sent in the request.</summary>
    /// <value>406</value>
    [Display(
        Name = "Not Acceptable",
        Description = "The requested resource is capable of generating only content not acceptable according to the Accept headers sent in the request."
    )]
    NotAcceptable = 406,

    /// <summary>The client must first authenticate itself with the proxy.</summary>
    /// <value>407</value>
    [Display(
        Name = "Proxy Authentication Required",
        Description = "The client must first authenticate itself with the proxy."
    )]
    ProxyAuthenticationRequired = 407,

    /// <summary>The server timed out waiting for the request. According to HTTP specifications: "The client did not produce a request within the time that the server was prepared to wait. The client MAY repeat the request without modifications at any later time."</summary>
    /// <value>408</value>
    [Display(
        Name = "Request Timeout",
        Description = "The server timed out waiting for the request. According to HTTP specifications: \\\"The client did not produce a request within the time that the server was prepared to wait. The client MAY repeat the request without modifications at any later time.\\\""
    )]
    RequestTimeout = 408,

    /// <summary>Indicates that the request could not be processed because of conflict in the current state of the resource, such as an edit conflict between multiple simultaneous updates.</summary>
    /// <value>409</value>
    [Display(
        Name = "Conflict",
        Description = "Indicates that the request could not be processed because of conflict in the current state of the resource, such as an edit conflict between multiple simultaneous updates."
    )]
    Conflict = 409,

    /// <summary>Indicates that the resource requested is no longer available and will not be available again. This should be used when a resource has been intentionally removed and the resource should be purged. Upon receiving a 410 status code, the client should not request the resource in the future. Clients such as search engines should remove the resource from their indices.[41] Most use cases do not require clients and search engines to purge the resource, and a "404 Not Found" may be used instead.</summary>
    /// <value>410</value>
    [Display(
        Name = "Gone",
        Description = "Indicates that the resource requested is no longer available and will not be available again. This should be used when a resource has been intentionally removed and the resource should be purged. Upon receiving a 410 status code, the client should not request the resource in the future. Clients such as search engines should remove the resource from their indices. Most use cases do not require clients and search engines to purge the resource, and a \\\"404 Not Found\\\" may be used instead."
    )]
    Gone = 410,

    /// <summary>The request did not specify the length of its content, which is required by the requested resource.</summary>
    /// <value>411</value>
    [Display(
        Name = "Length Required",
        Description = "The request did not specify the length of its content, which is required by the requested resource."
    )]
    LengthRequired = 411,

    /// <summary>The server does not meet one of the preconditions that the requester put on the request.</summary>
    /// <value>412</value>
    [Display(
        Name = "Precondition Failed",
        Description = "The server does not meet one of the preconditions that the requester put on the request."
    )]
    PreconditionFailed = 412,

    /// <summary>The request is larger than the server is willing or able to process. Previously called "Request Entity Too Large".[44]</summary>
    /// <value>413</value>
    [Display(
        Name = "Payload Too Large",
        Description = "The request is larger than the server is willing or able to process. Previously called \\\"Request Entity Too Large\\\"."
    )]
    PayloadTooLarge = 413,

    /// <summary>The URI provided was too long for the server to process. Often the result of too much data being encoded as a query-string of a GET request, in which case it should be converted to a POST request.[45] Called "Request-URI Too Long" previously.</summary>
    /// <value>414</value>
    [Display(
        Name = "URI Too Long",
        Description = "The URI provided was too long for the server to process. Often the result of too much data being encoded as a query-string of a GET request, in which case it should be converted to a POST request. Called \\\"Request-URI Too Long\\\" previously."
    )]
    URITooLong = 414,

    /// <summary>The request entity has a media type which the server or resource does not support. For example, the client uploads an image as image/svg+xml, but the server requires that images use a different format.</summary>
    /// <value>415</value>
    [Display(
        Name = "Unsupported Media Type",
        Description = "The request entity has a media type which the server or resource does not support. For example, the client uploads an image as image/svg+xml, but the server requires that images use a different format."
    )]
    UnsupportedMediaType = 415,

    /// <summary>The client has asked for a portion of the file (byte serving), but the server cannot supply that portion. For example, if the client asked for a part of the file that lies beyond the end of the file.[46] Called "Requested Range Not Satisfiable" previously.</summary>
    /// <value>416</value>
    [Display(
        Name = "Range Not Satisfiable",
        Description = "The client has asked for a portion of the file (byte serving), but the server cannot supply that portion. For example, if the client asked for a part of the file that lies beyond the end of the file. Called \\\"Requested Range Not Satisfiable\\\" previously."
    )]
    RangeNotSatisfiable = 416,

    /// <summary>The server cannot meet the requirements of the Expect request-header field.</summary>
    /// <value>417</value>
    [Display(
        Name = "Expectation Failed",
        Description = "The server cannot meet the requirements of the Expect request-header field."
    )]
    ExpectationFailed = 417,

    /// <summary>This code was defined in 1998 as one of the traditional IETF April Fools' jokes, in RFC 2324, Hyper Text Coffee Pot Control Protocol, and is not expected to be implemented by actual HTTP servers. The RFC specifies this code should be returned by teapots requested to brew coffee.[53] This HTTP status is used as an Easter egg in some websites, including Google.com.</summary>
    /// <value>418</value>
    [Display(
        Name = "I'm a teapot",
        Description = "This code was defined in 1998 as one of the traditional IETF April Fools' jokes, in RFC 2324, Hyper Text Coffee Pot Control Protocol, and is not expected to be implemented by actual HTTP servers. The RFC specifies this code should be returned by teapots requested to brew coffee. This HTTP status is used as an Easter egg in some websites, including Google.com."
    )]
    ImATeapot = 418,

    /// <summary>The request was directed at a server that is not able to produce a response (for example because of connection reuse).</summary>
    /// <value>421</value>
    [Display(
        Name = "Misdirected Request",
        Description = "The request was directed at a server that is not able to produce a response (for example because of connection reuse)."
    )]
    MisdirectedRequest = 421,

    /// <summary>The request was well-formed but was unable to be followed due to semantic errors.</summary>
    /// <value>422</value>
    [Display(
        Name = "Unprocessable Entity",
        Description = "The request was well-formed but was unable to be followed due to semantic errors."
    )]
    UnprocessableEntity = 422,

    /// <summary>The resource that is being accessed is locked.</summary>
    /// <value>423</value>
    [Display(Name = "Locked", Description = "The resource that is being accessed is locked.")]
    Locked = 423,

    /// <summary>The request failed due to failure of a previous request (e.g., a PROPPATCH).</summary>
    /// <value>424</value>
    [Display(
        Name = "Failed Dependency",
        Description = "The request failed due to failure of a previous request (e.g., a PROPPATCH)."
    )]
    FailedDependency = 424,

    /// <summary>The client should switch to a different protocol such as TLS/1.0, given in the Upgrade header field.</summary>
    /// <value>426</value>
    [Display(
        Name = "Upgrade Required",
        Description = "The client should switch to a different protocol such as TLS/1.0, given in the Upgrade header field."
    )]
    UpgradeRequired = 426,

    /// <summary>The origin server requires the request to be conditional. Intended to prevent the 'lost update' problem, where a client GETs a resource's state, modifies it, and PUTs it back to the server, when meanwhile a third party has modified the state on the server, leading to a conflict.</summary>
    /// <value>428</value>
    [Display(
        Name = "Precondition Required",
        Description = "The origin server requires the request to be conditional. Intended to prevent the 'lost update' problem, where a client GETs a resource's state, modifies it, and PUTs it back to the server, when meanwhile a third party has modified the state on the server, leading to a conflict."
    )]
    PreconditionRequired = 428,

    /// <summary>The user has sent too many requests in a given amount of time. Intended for use with rate-limiting schemes.</summary>
    /// <value>429</value>
    [Display(
        Name = "Too Many Requests",
        Description = "The user has sent too many requests in a given amount of time. Intended for use with rate-limiting schemes."
    )]
    TooManyRequests = 429,

    /// <summary>The server is unwilling to process the request because either an individual header field, or all the header fields collectively, are too large.</summary>
    /// <value>431</value>
    [Display(
        Name = "Request Header Fields Too Large",
        Description = "The server is unwilling to process the request because either an individual header field, or all the header fields collectively, are too large."
    )]
    RequestHeaderFieldsTooLarge = 431,

    /// <summary>A server operator has received a legal demand to deny access to a resource or to a set of resources that includes the requested resource.[60] The code 451 was chosen as a reference to the novel Fahrenheit 451 (see the Acknowledgements in the RFC).</summary>
    /// <value>451</value>
    [Display(
        Name = "Unavailable For Legal Reasons",
        Description = "A server operator has received a legal demand to deny access to a resource or to a set of resources that includes the requested resource. The code 451 was chosen as a reference to the novel Fahrenheit 451 (see the Acknowledgements in the RFC)."
    )]
    UnavailableForLegalReasons = 451,

    /// <summary>A generic error message, given when an unexpected condition was encountered and no more specific message is suitable.</summary>
    /// <value>500</value>
    [Display(
        Name = "Internal Server Error",
        Description = "A generic error message, given when an unexpected condition was encountered and no more specific message is suitable."
    )]
    InternalServerError = 500,

    /// <summary>The server either does not recognize the request method, or it lacks the ability to fulfil the request. Usually this implies future availability (e.g., a new feature of a web-service API).</summary>
    /// <value>501</value>
    [Display(
        Name = "Not Implemented",
        Description = "The server either does not recognize the request method, or it lacks the ability to fulfil the request. Usually this implies future availability (e.g., a new feature of a web-service API)."
    )]
    NotImplemented = 501,

    /// <summary>The server was acting as a gateway or proxy and received an invalid response from the upstream server.</summary>
    /// <value>502</value>
    [Display(
        Name = "Bad Gateway",
        Description = "The server was acting as a gateway or proxy and received an invalid response from the upstream server."
    )]
    BadGateway = 502,

    /// <summary>The server cannot handle the request (because it is overloaded or down for maintenance). Generally, this is a temporary state.</summary>
    /// <value>503</value>
    [Display(
        Name = "Service Unavailable",
        Description = "The server cannot handle the request (because it is overloaded or down for maintenance). Generally, this is a temporary state."
    )]
    ServiceUnavailable = 503,

    /// <summary>The server was acting as a gateway or proxy and did not receive a timely response from the upstream server.</summary>
    /// <value>504</value>
    [Display(
        Name = "Gateway Timeout",
        Description = "The server was acting as a gateway or proxy and did not receive a timely response from the upstream server."
    )]
    GatewayTimeout = 504,

    /// <summary>The server does not support the HTTP protocol version used in the request.</summary>
    /// <value>505</value>
    [Display(
        Name = "HTTP Version Not Supported",
        Description = "The server does not support the HTTP protocol version used in the request."
    )]
    HTTPVersionNotSupported = 505,

    /// <summary>Transparent content negotiation for the request results in a circular reference.</summary>
    /// <value>506</value>
    [Display(
        Name = "Variant Also Negotiates",
        Description = "Transparent content negotiation for the request results in a circular reference."
    )]
    VariantAlsoNegotiates = 506,

    /// <summary>The server is unable to store the representation needed to complete the request.</summary>
    /// <value>507</value>
    [Display(
        Name = "Insufficient Storage",
        Description = "The server is unable to store the representation needed to complete the request."
    )]
    InsufficientStorage = 507,

    /// <summary>The server detected an infinite loop while processing the request (sent in lieu of 208 Already Reported).</summary>
    /// <value>508</value>
    [Display(
        Name = "Loop Detected",
        Description = "The server detected an infinite loop while processing the request (sent in lieu of 208 Already Reported)."
    )]
    LoopDetected = 508,

    /// <summary>Further extensions to the request are required for the server to fulfil it.</summary>
    /// <value>510</value>
    [Display(
        Name = "Not Extended",
        Description = "Further extensions to the request are required for the server to fulfil it."
    )]
    NotExtended = 510,

    /// <summary>The client needs to authenticate to gain network access. Intended for use by intercepting proxies used to control access to the network (e.g., "captive portals" used to require agreement to Terms of Service before granting full Internet access via a Wi-Fi hotspot).</summary>
    /// <value>511</value>
    [Display(
        Name = "Network Authentication Required",
        Description = "The client needs to authenticate to gain network access. Intended for use by intercepting proxies used to control access to the network (e.g., \\\"captive portals\\\" used to require agreement to Terms of Service before granting full Internet access via a Wi-Fi hotspot)."
    )]
    NetworkAuthenticationRequired = 511,

    /// <summary>This status code is not specified in any RFCs. Its use is unknown.</summary>
    /// <value>520</value>
    [Display(
        Name = "Unknown Error",
        Description = "This status code is not specified in any RFCs. Its use is unknown."
    )]
    UnknownError = 520,

    /// <summary>The origin server has refused the connection from the client.</summary>
    /// <value>521</value>
    [Display(
        Name = "Web Server Is Down",
        Description = "The origin server has refused the connection from the client."
    )]
    WebServerIsDown = 521,

    /// <summary>The connection to the origin server timed out.</summary>
    /// <value>522</value>
    [Display(
        Name = "Connection Timed Out",
        Description = "The connection to the origin server timed out."
    )]
    ConnectionTimedOut = 522,

    /// <summary>The origin server refused to accept the request.</summary>
    /// <value>523</value>
    [Display(
        Name = "Origin Is Unreachable",
        Description = "The origin server refused to accept the request."
    )]
    OriginIsUnreachable = 523,

    /// <summary>The server is currently unavailable (because it is overloaded or down for maintenance). Generally, this is a temporary state.</summary>
    /// <value>524</value>
    [Display(
        Name = "A Timeout Occurred",
        Description = "The server is currently unavailable (because it is overloaded or down for maintenance). Generally, this is a temporary state."
    )]
    ATimeoutOccurred = 524,

    /// <summary>The SSL certificate presented by the origin server is not trusted by the system for one or more of the following reasons: 1. The server is self-signed. 2. The server is signed by a certificate authority that is not well-known. 3. The server is signed by a certificate authority that is not well-known by your system's trust store.</summary>
    /// <value>525</value>
    [Display(
        Name = "SSL Handshake Failed",
        Description = "The SSL certificate presented by the origin server is not trusted by the system for one or more of the following reasons: 1. The server is self-signed. 2. The server is signed by a certificate authority that is not well-known. 3. The server is signed by a certificate authority that is not well-known by your system's trust store."
    )]
    SSLHandshakeFailed = 525,

    /// <summary>The origin server has refused to accept the request because a new SSL handshake is required.</summary>
    /// <value>526</value>
    [Display(
        Name = "Invalid SSL Certificate",
        Description = "The origin server has refused to accept the request because a new SSL handshake is required."
    )]
    InvalidSSLCertificate = 526,

    /// <summary>Used by Cloudflare and Cloud Foundry's gorouter to indicate failure to validate the SSL/TLS certificate that the origin server presented.</summary>
    /// <value>527</value>
    [Display(
        Name = "Railgun Error",
        Description = "Used by Cloudflare and Cloud Foundry's gorouter to indicate failure to validate the SSL/TLS certificate that the origin server presented."
    )]
    RailgunError = 527,

    /// <summary>This status code is not specified in any RFC and is returned by certain services, for instance Microsoft Azure and CloudFlare servers: 1. Microsoft Azure: The server timed out waiting for the request. According to Microsoft Support, this error occurs because a script that uses the WinHTTP library sends an HTTP request without a request header. 2. CloudFlare: The request timed out or failed after the WAN connection had been established.</summary>
    /// <value>529</value>
    [Display(
        Name = "Site Is Overloaded",
        Description = "This status code is not specified in any RFC and is returned by certain services, for instance Microsoft Azure and CloudFlare servers: 1. Microsoft Azure: The server timed out waiting for the request. According to Microsoft Support, this error occurs because a script that uses the WinHTTP library sends an HTTP request without a request header. 2. CloudFlare: The request timed out or failed after the WAN connection had been established."
    )]
    SiteIsOverloaded = 529,

    /// <summary>This status code is not specified in any RFCs, but is used by CloudFlare's reverse proxies to signal an "unknown connection issue between CloudFlare and the origin web server" to a client in front of the proxy.</summary>
    /// <value>530</value>
    [Display(
        Name = "Site Is Frozen",
        Description = "This status code is not specified in any RFCs, but is used by CloudFlare's reverse proxies to signal an \\\"unknown connection issue between CloudFlare and the origin web server\\\" to a client in front of the proxy."
    )]
    SiteIsFrozen = 530,

    /// <summary>Used by Apache servers. A catch-all error condition allowing the passage of message bodies through the server when the ProxyErrorOverride setting is enabled. It is displayed in this situation instead of a 4xx or 5xx error message.</summary>
    /// <value>218</value>
    [Display(
        Name = "This Is Fine",
        Description = "Used by Apache servers. A catch-all error condition allowing the passage of message bodies through the server when the ProxyErrorOverride setting is enabled. It is displayed in this situation instead of a 4xx or 5xx error message."
    )]
    ThisIsFine = 218,

    /// <summary>Used by the Laravel Framework when a CSRF Token is missing or expired.<summary>
    /// <value>419</value>
    [Display(
        Name = "Page Expired",
        Description = "Used by the Laravel Framework when a CSRF Token is missing or expired."
    )]
    PageExpired = 419,

    /// <summary>Returned by version 1 of the Twitter Search and Trends API when the client is being rate limited; versions 1.1 and later use the 429 Too Many Requests response code instead. The phrase "Enhance your calm" comes from the 1993 movie Demolition Man, and its association with this number is likely a reference to cannabis.</summary>
    /// <value>420</value>
    [Display(
        Name = "Enhance Your Calm",
        Description = "Returned by version 1 of the Twitter Search and Trends API when the client is being rate limited; versions 1.1 and later use the 429 Too Many Requests response code instead. The phrase \\\"Enhance your calm\\\" comes from the 1993 movie Demolition Man, and its association with this number is likely a reference to cannabis."
    )]
    EnhanceYourCalm = 420,

    /// <summary>Returned by ArcGIS for Server. A code of 498 indicates an expired or otherwise invalid token.</summary>
    /// <value>498</value>
    [Display(
        Name = "Invalid Token",
        Description = "Returned by ArcGIS for Server. A code of 498 indicates an expired or otherwise invalid token."
    )]
    InvalidToken = 498,

    /// <summary>Returned by ArcGIS for Server. A code of 499 indicates that a token is required (if no token was submitted).</summary>
    /// <value>499</value>
    [Display(
        Name = "Token Required",
        Description = "Returned by ArcGIS for Server. A code of 499 indicates that a token is required (if no token was submitted)."
    )]
    TokenRequired = 499,

    /// <summary>Used in Exchange ActiveSync if there either is a more efficient server to use or the server cannot access the users' mailbox.[citation needed]</summary>
    /// <value>449</value>
    [Display(
        Name = "Retry With",
        Description = "Used in Exchange ActiveSync if there either is a more efficient server to use or the server cannot access the users' mailbox."
    )]
    RetryWith = 449,

    /// <summary>A Microsoft extension. The request should be retried after performing the appropriate action.</summary>
    /// <value>451</value>
    [Display(
        Name = "Redirect",
        Description = "A Microsoft extension. The request should be retried after performing the appropriate action."
    )]
    Redirect = 451
}
