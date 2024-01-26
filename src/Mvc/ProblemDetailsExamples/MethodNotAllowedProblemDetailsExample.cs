using System.Collections.Generic;

namespace Dgmjr.AspNetCore.Mvc;

public class MethodNotAllowedProblemDetails : IProblemDetails
{
    /// <inheritdoc cref="Dgmjr.Http.StatusCode.MethodNotAllowed.UriString" />
    public string? Type => Dgmjr.Http.StatusCode.MethodNotAllowed.UriString;

    /// <inheritdoc cref="Dgmjr.Http.StatusCode.MethodNotAllowed.Name" />
    public string? Title => Dgmjr.Http.StatusCode.MethodNotAllowed.Name;

    /// <inheritdoc cref="Dgmjr.Http.StatusCode.MethodNotAllowed.Id" />
    public int? Status => Dgmjr.Http.StatusCode.MethodNotAllowed.Id;

    /// <inheritdoc cref="Dgmjr.Http.StatusCode.MethodNotAllowed.Description" />
    public string? Detail => Dgmjr.Http.StatusCode.MethodNotAllowed.Description;

    public string? Instance => "/api/v1/endpoint";

    public IDictionary<string, object?> Extensions =>
        new Dictionary<string, object?>
        {
            { "traceId", Guid.NewGuid().ToString() },
            { "errors", new[] { "Method not allowed" } },
            { "method", "GET" }
        };
}
