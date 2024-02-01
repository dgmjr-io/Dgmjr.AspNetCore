namespace Dgmjr.AzureAdB2C.Services;

using System.Security.Claims;

using Dgmjr.AzureAdB2C.Models;

using Microsoft.Extensions.Options;

public interface IClaimsGenerator
{
    Task<ApiResponse> GenerateClaimsAsync(
        ApiRequest request,
        CancellationToken cancellationToken = default
    );
    Version Version { get; }
}

public abstract class ClaimsGenerator(IOptions<Version> version) : IClaimsGenerator
{
    public virtual Version Version => version.Value;
    public abstract Task<ApiResponse> GenerateClaimsAsync(
        ApiRequest request,
        CancellationToken cancellationToken = default
    );
}
