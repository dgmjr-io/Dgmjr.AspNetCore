namespace Dgmjr.AspNetCore.Communication.Mail;

public class MailSendResult
{
    SmsSendReponseCode StatusCode
    {
        get => (SmsSendReponseCode)((ISmsSendResult)this).StatusCode;
        set => ((SmsSendReponseCode)this).StatusCode = (int)value;
    }
}
