namespace Dgmjr.AzureAdB2C.Models;

using System.Globalization;

public class ApiRequest : StringDictionary
{
    public string? Email { get; set; }
    public ICollection<UserIdentity>? Identities { get; set; } = new List<UserIdentity>();
    public guid ClientId { get; set; }
    public guid ObjectId { get; set; }
    public string Step { get; set; } = default!;

    [JsonConverter(typeof(JsonLocaleConverter))]
    public CultureInfo? UiLocales { get; set; }
}

public class UserIdentity
{
    public string SignInType { get; set; } = default!;
    public string Issuer { get; set; } = default!;
    public string IssuerAssignedId { get; set; } = default!;
}
