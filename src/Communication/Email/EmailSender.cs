using System.Security.AccessControl;

/*
 * EmailSender.cs
 *
 *   Created: 2022-12-24-05:29:40
 *   Modified: 2022-12-24-05:29:41
 *
 *   Author: David G. Moore, Jr, <david@dgmjr.io>
 *
 *   Copyright © 2022-2023 David G. Moore, Jr,, All Rights Reserved
 *      License: MIT (https://opensource.org/licenses/MIT)
 */

namespace Dgmjr.AspNetCore.Communication.Mail;

using Azure.Communication.Email;
// using Azure.Communication.Email.Models;
using Azure.Identity;

using Azure.Messaging;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Options;

/* The EmailSender class is an implementation of the IEmailSender interface that uses an EmailClient to
send emails asynchronously. */
public class EmailSender : IEmailSender
{
    private readonly EmailClientOptions _options;
    private readonly EmailClient _client;

    public EmailSender(IOptions<EmailClientOptions> options)
    {
        _options = options?.Value;
        _client = new EmailClient(
            new Uri(_options.ConnectionString),
            new DefaultAzureCredential()
        );
    }

    public async Task SendEmailAsync(
        string email,
        string subject,
        string htmlMessage
    )
    {
        await SendEmailAsync(
            new EmailMessage(
                _options.Value.DefaultFrom,
                subject)
            { Html = htmlMessage },
                new EmailRecipients(new[] { new EmailAddress(email) })
            );
    }

    public async Task SendEmailAsync(EmailMessage message)
    {
        await _client.SendAsync(message);
    }
}
