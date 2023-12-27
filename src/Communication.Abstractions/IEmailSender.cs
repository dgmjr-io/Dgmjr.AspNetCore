namespace Dgmjr.AspNetCore.Communication.Email;

using Azure.Communication.Email;

public interface IEmailSender
{
    Task SendEmailAsync(string email, string subject, string htmlMessage);
    Task SendEmailAsync(EmailMessage message);
}
