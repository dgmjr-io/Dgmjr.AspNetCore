namespace Dgmjr.AspNetCore.Communication.Sms;

/// <summary>
/// Represents the result of sending an SMS message.
/// </summary>
public readonly record struct SmsSendResult : ISmsSendResult
{
    public SmsSendResult(Azure.Communication.Sms.SmsSendResult result)
    {
        StatusCode = result.HttpStatusCode;
        ErrorMessage = result.ErrorMessage;
        To = (PhoneNumber)result.To;
    }

    public string? ErrorMessage { get; init; }
    public PhoneNumber To { get; init; }

    /// <summary>
    /// Gets the status code of the message send result.
    /// </summary>
    public int StatusCode { get; init; }

    /// <summary>
    /// Gets a value indicating whether the SMS message was sent successfully.
    /// </summary>
    public bool IsSuccess =>
        StatusCode is SmsSendResponseCode.Success.Id or SmsSendResponseCode.Accepted.Id;

    /// <summary>
    /// Gets or sets the response code of the SMS send result.
    /// </summary>
    public Abstractions.ISmsSendResponseCode Status
    {
        get => SmsSendResponseCode.FromId(StatusCode);
        init => StatusCode = ((IIdentifiable<int>)value).Id;
    }
}
