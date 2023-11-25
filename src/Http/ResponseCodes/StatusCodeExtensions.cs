namespace Dgmjr.Http;

public static class StatusCodeExtensions
{
    public static bool IsInformational(this int statusCode) =>
        statusCode >= 100 && statusCode <= 199;
    public static bool IsInformational(this Abstractions.IStatusCode statusCode) =>
        ((IHaveAValue<ushort>)statusCode).Value >= 100 && ((IHaveAValue<ushort>)statusCode).Value <= 199;

    public static bool IsSuccess(this int statusCode) => statusCode >= 200 && statusCode <= 299;
    public static bool IsSuccess(this Abstractions.IStatusCode statusCode) => ((IHaveAValue<ushort>)statusCode).Value >= 200 && ((IHaveAValue<ushort>)statusCode).Value <= 299;

    public static bool IsRedirection(this int statusCode) => statusCode >= 300 && statusCode <= 399;

    public static bool IsClientError(this int statusCode) => statusCode >= 400 && statusCode <= 499;

    public static bool IsServerError(this int statusCode) => statusCode >= 500 && statusCode <= 599;

    public static bool IsError(this int statusCode) => statusCode >= 400 && statusCode <= 599;

    public static bool IsOk(this int statusCode) => statusCode == 200;

    public static bool IsCreated(this int statusCode) => statusCode == 201;

    public static bool IsAccepted(this int statusCode) => statusCode == 202;

    public static bool IsNoContent(this int statusCode) => statusCode == 204;

    public static bool IsBadRequest(this int statusCode) => statusCode == 400;

    public static bool IsUnauthorized(this int statusCode) => statusCode == 401;

    public static bool IsPaymentRequired(this int statusCode) => statusCode == 402;

    public static bool IsForbidden(this int statusCode) => statusCode == 403;

    public static bool IsNotFound(this int statusCode) => statusCode == 404;

    public static bool IsMethodNotAllowed(this int statusCode) => statusCode == 405;

    public static bool IsNotAcceptable(this int statusCode) => statusCode == 406;

    public static bool IsProxyAuthenticationRequired(this int statusCode) => statusCode == 407;

    public static bool IsRequestTimeout(this int statusCode) => statusCode == 408;

    public static bool IsConflict(this int statusCode) => statusCode == 409;

    public static bool IsGone(this int statusCode) => statusCode == 410;

    public static bool IsLengthRequired(this int statusCode) => statusCode == 411;

    public static bool IsPreconditionFailed(this int statusCode) => statusCode == 412;

    public static bool IsPayloadTooLarge(this int statusCode) => statusCode == 413;

    public static bool IsUnsupportedMediaType(this int statusCode) => statusCode == 415;

    public static bool IsTooManyRequests(this int statusCode) => statusCode == 429;

    public static bool IsInternalServerError(this int statusCode) => statusCode == 500;

    public static bool IsNotImplemented(this int statusCode) => statusCode == 501;

    public static bool IsBadGateway(this int statusCode) => statusCode == 502;

    public static bool IsServiceUnavailable(this int statusCode) => statusCode == 503;

    public static bool IsGatewayTimeout(this int statusCode) => statusCode == 504;

    public static bool IsHttpVersionNotSupported(this int statusCode) => statusCode == 505;

    public static bool IsInsufficientStorage(this int statusCode) => statusCode == 507;

    public static bool IsLoopDetected(this int statusCode) => statusCode == 508;

    public static bool IsNotExtended(this int statusCode) => statusCode == 510;

    public static bool IsNetworkAuthenticationRequired(this int statusCode) => statusCode == 511;

    public static bool IsUnknown(this int statusCode) => statusCode == 0;
}
