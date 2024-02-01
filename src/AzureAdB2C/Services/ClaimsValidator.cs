namespace Dgmjr.AzureAdB2C.Services;

using System.ComponentModel.DataAnnotations;
using System.Security.Claims;

using Dgmjr.AzureAdB2C.Models;

using Microsoft.Extensions.Options;

public interface IClaimsValidator
{
    Task<ValidationResult> ValidateAsync(
        ApiRequest request,
        CancellationToken cancellationToken = default
    );
    Version Version { get; }
}

public class ClaimsValidatorOptions
{
    public virtual Version Version { get; set; } = default!;
    public virtual Func<StrKvp, ValidationResult> ValidateClaim { get; set; } = kvp => ValidationResult.Success;

    public virtual ValidationResult Validate(StrKvp kvp) => ValidateClaim(kvp);

    public virtual ValidationResult Validate(ApiRequest request)
    {
        var results = request.Select(Validate);
        var failures = results.Where(result => !IsNullOrWhiteSpace(result.ErrorMessage));
        var messages = failures.Select(result => $"{Join(", ", result.MemberNames)}: {result.ErrorMessage}");
        var message = Join(env.NewLine, messages);
        return (failures.Any() ? new ValidationResult(message, failures.SelectMany(result => result.MemberNames)) : ValidationResult.Success)!;
    }
}

public abstract class ClaimsValidator(IOptions<ClaimsValidatorOptions> options) : IClaimsValidator
{
    public Version Version => options.Value.Version;
    public abstract Task<ValidationResult> ValidateAsync(
        ApiRequest request,
        CancellationToken cancellationToken = default
    );
}
