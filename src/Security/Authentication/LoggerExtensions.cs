/*
 * BasicApiAuthMiddleware.cs
 *
 *   Created: 2022-12-14-05:48:24
 *   Modified: 2022-12-14-05:48:25
 *
 *   Author: David G. Moore, Jr, <david@dgmjr.io>
 *
 *   Copyright © 2022-2023 David G. Moore, Jr,, All Rights Reserved
 *      License: MIT (https://opensource.org/licenses/MIT)
 */

namespace Dgmjr.AspNetCore.Authentication;
using Microsoft.Extensions.Logging;
using static Microsoft.Extensions.Logging.LogLevel;

internal static partial class LoggerExtensions
{
    [LoggerMessage(0, Debug, "Begin authentication for request {TraceIdentifier} {Method} {Path}")]
    public static partial void LogBeginAuthentication(
        this ILogger logger,
        string traceIdentifier,
        string path,
        string method
    );

    [LoggerMessage(1, Debug, "Authenticating user {Username}")]
    public static partial void LogAuthenticatingUser(this ILogger logger, string Username);

    [LoggerMessage(100, Debug, "User {Username} authenticated successfully (claims: {claimCount}")]
    public static partial void LogUserAuthenticated(
        this ILogger logger,
        string Username,
        int claimCount
    );

    [LoggerMessage(-1, Debug, "User {Username} failed to authenticate")]
    public static partial void UserAuthenticationFailed(this ILogger logger, string Username);

    [LoggerMessage(-2, Debug, "User {Username} failed to authenticate: {Reason}")]
    public static partial void LogUserAuthenticationFailed(
        this ILogger logger,
        string Username,
        string Reason
    );

    [LoggerMessage(-3, Debug, "{TraceIdentifier} presented an invalid or missing auth header.")]
    public static partial void LogInvalidAuthHeader(this ILogger logger, string TraceIdentifier);

    [LoggerMessage(-4, Debug, "{TraceIdentifier} presented an expired auth token for use {username}.  Originally issued: {initiallyIssued}; Expiration: {originalExpiration}; Now: {now}")]
    public static partial void LogExpiredToken(this ILogger logger, string traceIdentifier, string? username, DateTimeOffset initiallyIssued, DateTimeOffset originalExpiration, DateTimeOffset now);

    [LoggerMessage(-5, Debug, "No authenticationSchemeOptions are configured. Configure named options for this middleware with services.AddAuthentication(\"SchemeName\").AddScheme<TOptions, THandler>(\"SchemeName\", o => {{ }})")]
    public static partial void LogNoDefaultAuthenticationScheme(this ILogger logger);

    [LoggerMessage(-6, Error, "An error occurred while authenticating the user: {message}, {stacktrace}")]
    public static partial void LogAuthenticationError(this ILogger logger, string message, string stackTrace);
}
