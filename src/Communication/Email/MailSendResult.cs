namespace Dgmjr.AspNetCore.Communication.Mail;

public class MailSendResult
{
    MailSendReponseCode StatusCode
    {
        get => (MailSendReponseCode)((IMailSendResult)this).StatusCode;
        set => ((MailSendReponseCode)this).StatusCode = (int)value;
    }
}
