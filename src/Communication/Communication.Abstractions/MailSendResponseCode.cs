namespace Dgmjr.AspNetCore.Communication.Email;

public readonly partial record struct MailSendResponseCode
{
    public Azure.Communication.Email.EmailSendStatus ToAzureEmailSendStatus(
        Abstractions.IMailSendResponseCode @this
    ) =>
        @this.Name switch
        {
            Succeeded.Name => Azure.Communication.Email.EmailSendStatus.Succeeded,
            NotStarted.Name => Azure.Communication.Email.EmailSendStatus.NotStarted,
            Running.Name => Azure.Communication.Email.EmailSendStatus.Running,
            Canceled.Name => Azure.Communication.Email.EmailSendStatus.Canceled,
            Failed.Name => Azure.Communication.Email.EmailSendStatus.Failed,
            _
                => throw new ArgumentException(
                    $"The value {@this.Name} is not a valid {nameof(Azure.Communication.Email.EmailSendStatus)}."
                )
        };

    public static Abstractions.IMailSendResponseCode AzureEmailSendStatus(
        Azure.Communication.Email.EmailSendStatus status
    ) =>
        status.ToString() switch
        {
            Succeeded.Name => Succeeded.Instance,
            NotStarted.Name => NotStarted.Instance,
            Running.Name => Running.Instance,
            Canceled.Name => Canceled.Instance,
            Failed.Name => Failed.Instance,
            _
                => throw new ArgumentException(
                    $"The value {status} is not a valid {nameof(Azure.Communication.Email.EmailSendStatus)}."
                )
        };

    // public static Abstractions.IMailSendResponseCode FromValue(Enums.MailSendResponseCode code) =>
    //     code switch
    //     {
    //         Enums.MailSendResponseCode.Succeeded => Succeeded.Instance,
    //         Enums.MailSendResponseCode.NotStarted => NotStarted.Instance,
    //         Enums.MailSendResponseCode.Running => Running.Instance,
    //         Enums.MailSendResponseCode.Canceled => Canceled.Instance,
    //         Enums.MailSendResponseCode.Failed => Failed.Instance,
    //         _
    //             => throw new ArgumentException(
    //                 $"The value {code} is not a valid {nameof(Enums.MailSendResponseCode)}."
    //             )
    //     };

    public static Abstractions.IMailSendResponseCode? FromId(int id) =>
        FromValue((Enums.MailSendResponseCode)id);
}
