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

namespace Dgmjr.AspNetCore.Communication.Email;

using Azure.Communication.Email;
using Azure.Identity;

using Azure.Messaging;
using Microsoft.Extensions.Options;

/* The EmailSender class is an implementation of the IEmailSender interface that uses an EmailClient to
send emails asynchronously. */
public class EmailSender : IEmailSender
{
    private readonly EmailSenderOptions _options;
    private readonly EmailClient _client;

    public EmailSender(IOptions<EmailSenderOptions> options)
    {
        _options = options?.Value;
        _client = new EmailClient(new Uri(_options.ConnectionString), new DefaultAzureCredential());
    }

    public async Task SendEmailAsync(string email, string subject, string htmlMessage)
    {
        await SendEmailAsync(
            new EmailMessage(
                _options.DefaultFrom,
                email,
                new EmailContent(subject) { Html = htmlMessage }
            )
        );
    }

    public async Task SendEmailAsync(EmailMessage message)
    {
        await _client.SendAsync(Azure.WaitUntil.Completed, message);
    }
}
