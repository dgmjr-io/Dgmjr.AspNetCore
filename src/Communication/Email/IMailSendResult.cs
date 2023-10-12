namespace Dgmjr.AspNetCore.Communication.Mail;

public interface IMailSendResult : IMessageSendResult
{
    new SmsSendReponseCode StatusCode { get; set; }
}
