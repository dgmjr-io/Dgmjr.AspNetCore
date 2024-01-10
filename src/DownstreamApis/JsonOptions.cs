namespace Microsoft.AspNetCore.Mvc;

#if !NET5_0_OR_GREATER
public class JsonOptions
{
    /// <summary>
    /// Gets or sets a flag to determine whether error messages from JSON deserialization by the <see cref="Formatters.JsonInputFormatter" /> will be added to the <see cref="ModelBinding.ModelStateDictionary" />. If false, a generic error message will be used instead.
    /// </summary>
    public bool AllowInputFormatterExceptionMessages { get; set; }

    /// <summary>
    /// Gets the <see cref="System.Text.Json.JsonSerializerOptions" /> used by <see cref="Formatters.JsonInputFormatter" /> and <see cref="Formatters.JsonOutputFormatter" />.
    /// </summary>
    public Jso JsonSerializerOptions { get; }
}
#endif
