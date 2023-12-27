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
    Succeeded = 200,
    NotStarted = 201,
    Running = 202,
    Canceled = 406,
    Failed = 500
}
