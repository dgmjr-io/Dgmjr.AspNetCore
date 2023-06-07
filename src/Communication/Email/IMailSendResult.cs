namespace Dgmjr.AspNetCore.Communication.Mail;

public interface IMailSendResult : IMessageSendResult
{
    new MailSendReponseCode StatusCode { get; set; }
}
