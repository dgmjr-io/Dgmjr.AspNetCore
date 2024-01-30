/** <summary> The above code is defining a C# enum named "MailSendReponseCode" that represents various SMTP
response codes that can be returned by a mail server. It includes enum members with values
representing specific SMTP response codes and their corresponding descriptions. The code also
includes attributes for JSON serialization and code generation. </summary> */
using System.Text.Json.Serialization;

namespace Dgmjr.AspNetCore.Communication.Email.Enums;

/// <summary>
/// This is a C# enum representing various SMTP response codes that can be returned by a mail server.
/// </summary>
[JConverter(typeof(JStringEnumConverter))]
[GenerateEnumerationRecordStruct("MailSendResponseCode", "Dgmjr.AspNetCore.Communication.Email")]
public enum MailSendResponseCode
{
    [Display(
        Name = "Succeeded",
        Description = "The request was successful and the message has been queued for delivery."
    )]
    Succeeded = 200,

    [Display(
        Name = "Accepted",
        Description = "The request was successful and the message has been accepted to be queued for delivery."
    )]
    NotStarted = 201,

    [Display(
        Name = "Running",
        Description = "The request is running and the message is being sent"
    )]
    Running = 202,

    [Display(Name = "Cancelled", Description = "The request has been cancelled.")]
    Canceled = 406,

    [Display(Name = "Failed", Description = "The request failed.")]
    Failed = 500
}
