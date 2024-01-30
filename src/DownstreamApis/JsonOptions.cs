/*
 * JsonOptions.cs
 *
 *   Created: 2023-06-27T00:06:27-05:00
 *   Modified: 2024-15-28T14:15:18-05:00
 *
 *   Author: David G. Moore, Jr. <david@dgmjr.io>
 *
 *   Copyright © 2024 David G. Moore, Jr., All Rights Reserved
 *      License: MIT (https://opensource.org/licenses/MIT)
 */

#if !NET5_0_OR_GREATER
namespace Microsoft.AspNetCore.Mvc;

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
