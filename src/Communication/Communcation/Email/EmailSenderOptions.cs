﻿/*
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

using System.Collections;
using System.Diagnostics.CodeAnalysis;
using System.Net.Mail;
using Dgmjr.AspNetCore.Communication;

public record class EmailSenderOptions : AzureCommunicationServicesOptions<EmailAddress>
{
    public new const string ConfigurationSectionName =
        $"{AzureCommunicationServicesOptionsBase.ConfigurationSectionName}:Email";

    [Required]
    public override EmailAddress DefaultFrom { get; set; }

    public static new EmailSenderOptions Parse(string connectionString)
    {
        var options = AzureCommunicationServicesOptions<EmailAddress>.Parse(connectionString);
        return new EmailSenderOptions(options);
    }

    public EmailSenderOptions(
        AzureCommunicationServicesOptionsBase options,
        EmailAddress? defaultFrom = null
    )
    {
        DefaultFrom = defaultFrom ?? EmailAddress.Empty;
        Endpoint = options.Endpoint;
        AccessKey = options.AccessKey;
    }

    public EmailSenderOptions(AzureCommunicationServicesOptions<EmailAddress> options)
        : base(options)
    {
        DefaultFrom = options.DefaultFrom;
        AdminFrom = options.AdminFrom;
        MassDistributionFrom = options.MassDistributionFrom;
        SecurityFrom = options.SecurityFrom;
    }

    public EmailSenderOptions(string connectionString, EmailAddress? defaultFrom = null)
        : this(Parse(connectionString) with { DefaultFrom = defaultFrom ?? EmailAddress.Empty }) { }

    public EmailSenderOptions(string endpoint, string accessKey, EmailAddress? defaultFrom = null)
    {
        DefaultFrom = defaultFrom ?? EmailAddress.Empty;
        Endpoint = endpoint;
        AccessKey = accessKey;
    }

    public EmailSenderOptions()
        : this(EmptyValue) { }

    public IDictionary<string, EmailAddress> Addresses { get; set; } =
        new Dictionary<string, EmailAddress>();
}
