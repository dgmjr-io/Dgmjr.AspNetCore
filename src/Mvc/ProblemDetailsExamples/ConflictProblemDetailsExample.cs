using System.Collections.Generic;

namespace Dgmjr.AspNetCore.Mvc;

public record class ConflictProblemDetailsExample : IProblemDetails
{
    /// <summary>A short, human-readable summary of the problem.</summary>
    /// <value><inheritdoc cref="Dgmjr.Http.StatusCode.Conflict.UriString" path="/value" /></value>
    /// <example><inheritdoc cref="Dgmjr.Http.StatusCode.Conflict.UriString" path="/value" /></example>
    public string? Type => Dgmjr.Http.StatusCode.Conflict.UriString;

    /// <value><inheritdoc cref="Dgmjr.Http.StatusCode.Conflict.DisplayName" path="/value" /></value>
    /// <example><inheritdoc cref="Dgmjr.Http.StatusCode.Conflict.DisplayName" path="/value" /></example>
    public string? Title => Dgmjr.Http.StatusCode.Conflict.DisplayName;

    /// <value><inheritdoc cref="Dgmjr.Http.StatusCode.Conflict.Id" path="/value" /></value>
    /// <example><inheritdoc cref="Dgmjr.Http.StatusCode.Conflict.Id" path="/value" /></example>
    public int? Status => Dgmjr.Http.StatusCode.Conflict.Id;

    /// <value><inheritdoc cref="Dgmjr.Http.StatusCode.Conflict.Description" path="/value" /></value>
    /// <example><inheritdoc cref="Dgmjr.Http.StatusCode.Conflict.Description" path="/value" /></example>
    public string? Detail => Dgmjr.Http.StatusCode.Conflict.Description;

    /// <value>/api/endpoint</value>
    /// <example>/api/endpoint</example>
    public string? Instance => "/api/endpoint";

    /// <value>{ { "traceId", "0HLQ9V1J3Q0:40000003" } }</value>
    /// <example>{ { "traceId", "0HLQ9V1J3Q0:40000003" } }</example>
    public IDictionary<string, object?> Extensions =>
        new Dictionary<string, object?> { { "traceId", "0HLQ9V1J3Q0:40000003" } };
}
