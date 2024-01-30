namespace Dgmjr.AspNetCore.Communication.Email;

using System.Runtime.CompilerServices;

/// <summary>
/// Represents the result of sending an email.
/// </summary>
public readonly record struct MailSendResult(Azure.Communication.Email.EmailSendResult result)
    : IMailSendResult
{
    /// <summary>
    /// Gets or sets the response code of the email send result.
    /// </summary>
    public Abstractions.IMailSendResponseCode Status => MailSendResponseCode.Parse(StatusName);

public string StatusName => result.Status.ToString();

/// <summary>
/// Gets a value indicating whether the email send operation was successful.
/// </summary>
public bool IsSuccess =>
    ((IHaveAValue<Enums.MailSendResponseCode>)Status).Value
    is Enums.MailSendResponseCode.Succeeded;

/// <summary>
/// Gets or sets the status code of the email send result.
/// </summary>
public int StatusCode => ((IIdentifiable<int>)Status).Id;
}
