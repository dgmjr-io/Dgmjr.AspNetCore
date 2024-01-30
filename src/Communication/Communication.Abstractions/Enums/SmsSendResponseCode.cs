using System.Text.Json.Serialization;

namespace Dgmjr.AspNetCore.Communication.Sms.Enums;

/// <summary>
/// Specifies the JSON converter to use when serializing and deserializing the enumeration.
/// </summary>
[JConverter(typeof(JStringEnumConverter))]
/// <summary>
/// Generates a record struct for the specified enumeration, in the specified namespace.
/// </summary>
/// <remarks>
/// The generated struct includes properties for each value of the enumeration, with the property name
/// based on the enumeration value name, and the property value set to the enumeration value.
/// </remarks>
[GenerateEnumerationRecordStruct("SmsSendResponseCode", "Dgmjr.AspNetCore.Communication.Sms")]
public enum SmsSendResponseCode
{
    /// <summary>
    /// The request was successful and the message has been queued for delivery.
    /// </summary>
    [Display(
        Name = "Success",
        Description = "The request was successful and the message has been queued for delivery."
    )]
    Success = 200,

    /// <summary>
    /// The request was successful and the message has been accepted to be queued for delivery.
    /// </summary>
    [Display(
        Name = "Accepted",
        Description = "The request was successful and the message has been accepted to be queued for delivery."
    )]
    Accepted = 250,

    /// <summary>
    /// There was a problem with the request, such as invalid parameters or authentication failure.
    /// </summary>
    [Display(
        Name = "Bad Request",
        Description = "There was a problem with the request, such as invalid parameters or authentication failure."
    )]
    BadRequest = 400,

    /// <summary>
    /// Authentication failure. The request requires authentication and the provided credentials were incorrect.
    /// </summary>
    [Display(
        Name = "Unauthorized",
        Description = "Authentication failure. The request requires authentication and the provided credentials were incorrect."
    )]
    Unauthorized = 401,

    /// <summary>
    /// Access to the requested resource is forbidden.
    /// </summary>
    [Display(Name = "Forbidden", Description = "Access to the requested resource is forbidden.")]
    Forbidden = 403,

    /// <summary>
    /// The requested resource could not be found.
    /// </summary>
    [Display(Name = "Not Found", Description = "The requested resource could not be found.")]
    NotFound = 404,

    /// <summary>
    /// An internal server error occurred.
    /// </summary>
    [Display(Name = "Internal Server Error", Description = "An internal server error occurred.")]
    InternalServerError = 500
}
