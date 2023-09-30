namespace Dgmjr.AspNetCore.Communication.Mail;

public interface IMailSendResult : IMessageSendResult
{
    new MailSendResponseCode StatusCode { get; set; }
}
