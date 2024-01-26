#if !NET6_0_OR_GREATER
namespace Microsoft.AspNetCore.Mvc;

public class JsonOptions
{
    /// <summary>
    /// Gets or sets a flag to determine whether error messages from JSON deserialization by the <see cref="Microsoft.AspNetCore.Mvc.Formatters.SystemTextJsonInputFormatter" /> will be added to the <see cref="Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionary" />. If false, a generic error message will be used instead.
    /// </summary>
    public bool AllowInputFormatterExceptionMessages { get; set; }

    /// <summary>
    /// Gets the <see cref="System.Text.Json.Serialization.JsonSerializerOptions" /> used by <see cref="Microsoft.AspNetCore.Mvc.Formatters.SystemTextJsonInputFormatter" /> and <see cref="Microsoft.AspNetCore.Mvc.Formatters.SystemTextJsonOutputFormatter" />.
    /// </summary>
    public Jso JsonSerializerOptions { get; }
}
#endif
