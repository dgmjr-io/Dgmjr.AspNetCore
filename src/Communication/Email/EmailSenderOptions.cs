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

using System.Diagnostics.CodeAnalysis;
using System.Net.Mail;
using Dgmjr.AspNetCore.Communication;

public record class EmailSenderOptions : AzureCommunicationServicesOptions<EmailAddress>
{
    public override required EmailAddress DefaultFrom { get; set; }

    public static new EmailSenderOptions Parse(string connectionString)
    {
        var options = AzureCommunicationServicesOptions<EmailAddress>.Parse(connectionString);
        return new EmailSenderOptions(options);
    }

    [SetsRequiredMembers]
    public EmailSenderOptions(
        AzureCommunicationServicesOptionsBase options,
        EmailAddress? defaultFrom = null
    )
    {
        DefaultFrom = defaultFrom ?? EmailAddress.Empty;
        Endpoint = options.Endpoint;
        AccessKey = options.AccessKey;
    }

    [SetsRequiredMembers]
    public EmailSenderOptions(AzureCommunicationServicesOptions<EmailAddress> options)
        : base(options)
    {
        DefaultFrom = options.DefaultFrom;
    }

    [SetsRequiredMembers]
    public EmailSenderOptions(string connectionString, EmailAddress? defaultFrom = null)
        : this(Parse(connectionString) with { DefaultFrom = defaultFrom ?? EmailAddress.Empty }) { }

    [SetsRequiredMembers]
    public EmailSenderOptions(string endpoint, string accessKey, EmailAddress? defaultFrom = null)
    {
        DefaultFrom = defaultFrom ?? EmailAddress.Empty;
        Endpoint = endpoint;
        AccessKey = accessKey;
    }

    [SetsRequiredMembers]
    public EmailSenderOptions()
        : this(string.Empty) { }
}
