namespace Dgmjr.AspNetCore.Communication.Mail;

public class MailSendResult : IMessageSendResult, IMailSendResult
{
    public new MailSendResponseCode StatusCode
    {
        get => (MailSendResponseCode)((ISmsSendResult)this).StatusCode;
        set => StatusCode = value.Id;
    }

    public bool IsSuccess => StatusCode == MailSendResponseCode.Success;

    int IMessageSendResult.StatusCode
    {
        get => throw new NotImplementedException();
        set => throw new NotImplementedException();
    }
}
