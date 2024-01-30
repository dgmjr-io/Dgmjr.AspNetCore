namespace Dgmjr.AspNetCore.Communication.Sms;

/// <summary>
/// Represents the result of sending an SMS message.
/// </summary>
public readonly record struct SmsSendResult(Azure.Communication.Sms.SmsSendResult result)
    : ISmsSendResult
{
    // public SmsSendResult
    // {
    //     StatusCode = result.HttpStatusCode;
    //     ErrorMessage = result.ErrorMessage;
    //     To = (PhoneNumber)result.To;
    // }

    public string? ErrorMessage => result.ErrorMessage;
public PhoneNumber To => (PhoneNumber)result.To;

/// <summary>
/// Gets the status code of the message send result.
/// </summary>
public int StatusCode => result.HttpStatusCode;

/// <summary>
/// Gets a value indicating whether the SMS message was sent successfully.
/// </summary>
public bool IsSuccess =>
    StatusCode is SmsSendResponseCode.Success.Id or SmsSendResponseCode.Accepted.Id;

/// <summary>
/// Gets or sets the response code of the SMS send result.
/// </summary>
public Abstractions.ISmsSendResponseCode Status => SmsSendResponseCode.FromId(StatusCode);
}
