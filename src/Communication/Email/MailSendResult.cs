namespace Dgmjr.AspNetCore.Communication.Email;

/// <summary>
/// Represents the result of sending an email.
/// </summary>
public readonly record struct MailSendResult : IMailSendResult
{
    /// <summary>
    /// Gets or sets the response code of the email send result.
    /// </summary>
    public Abstractions.IMailSendResponseCode Status
    {
        get => MailSendResponseCode.FromId(StatusCode)!;
        init => StatusCode = ((IIdentifiable<int>)value).Id;
    }

    /// <summary>
    /// Gets a value indicating whether the email send operation was successful.
    /// </summary>
    public bool IsSuccess =>
        ((IHaveAValue<Enums.MailSendResponseCode>)Status).Value
        is Enums.MailSendResponseCode.Succeeded;

    /// <summary>
    /// Gets or sets the status code of the email send result.
    /// </summary>
    public int StatusCode { get; init; }
}
