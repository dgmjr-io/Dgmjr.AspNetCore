using System.Security.AccessControl;

/*
 * SmsSender.cs
 *
 *   Created: 2023-01-05-07:30:05
 *   Modified: 2023-01-05-07:30:05
 *
 *   Author: David G. Moore, Jr, <david@dgmjr.io>
 *
 *   Copyright © 2022-2023 David G. Moore, Jr,, All Rights Reserved
 *      License: MIT (https://opensource.org/licenses/MIT)
 */

namespace Dgmjr.AspNetCore.Communication.Sms;

using System;
using System.Domain;
using System.Threading.Tasks;
using Azure.Communication.Sms;
using Azure.Identity;
using Microsoft.Extensions.Options;

/// <summary>
/// The sms sender interface.
/// </summary>
public interface ISmsSender
{
    /// <summary>
    /// Sends the sms asynchronously.
    /// </summary>
    /// <param name="@to">The number to send the message to.</param>
    /// <param name="message">The message.</param>
    /// <returns><![CDATA[Task<SmsSendResult>]]></returns>
    Task<SmsSendResult> SendSmsAsync(PhoneNumber @to, string message);
    /// <summary>
    /// Sends the sms asynchronously.
    /// </summary>
    /// <param name="@to">The number to send the message to.</param>
    /// <param name="message">The message.</param>
    /// <returns><![CDATA[Task<SmsSendResult>]]></returns>
    Task<SmsSendResult> SendSmsAsync(string @to, string message)
#if NET7_0_OR_GREATER
        => SendSmsAsync(PhoneNumber.Parse(@to), message)
#endif
        ;
}

/// <summary>
/// An sms sender.
/// </summary>
public class SmsSender
{
    /// <summary>
    /// The options.
    /// </summary>
    private readonly SmsSenderOptions _options;

    /// <summary>
    /// Initializes a new instance of the <see cref="SmsSender"/> class.
    /// </summary>
    /// <param name="options">The options.</param>
    public SmsSender(IOptions<SmsSenderOptions> options) : this(options?.Value) { }

    /// <summary>
    /// Initializes a new instance of the <see cref="SmsSender"/> class.
    /// </summary>
    /// <param name="options">The options.</param>
    public SmsSender(SmsSenderOptions? options) => _options = options;

    /// <summary>
    /// Creates the client.
    /// </summary>
    /// <returns>An <see cref="SmsClient" />.</returns>
    protected SmsClient CreateClient() => new(_options.ConnectionString);

    private SmsClient _client;
    /// <summary>
    /// Gets the client.
    /// </summary>
    protected SmsClient Client => _client ??= CreateClient();

    /// <summary>
    /// Sends the sms asynchronously.
    /// </summary>
    /// <param name="to">The number of the recipient.</param>
    /// <param name="message">The message.</param>
    /// <returns>A <![CDATA[Task<SmsSendResult>]]></returns>
    public async Task<SmsSendResult> SendSmsAsync(PhoneNumber @to, string message)
    {
        return (await Client.SendAsync(from: _options.DefaultFrom, to: @to, message: message)).Value;
    }
}

public record class SmsSenderOptions : AzureCommunicationServicesOptions<PhoneNumber>
{
    /// <summary>
    /// The default phone number string.
    /// </summary>
    public const string DefaultFromPhoneNumberString = "+12025550108";
    /// <summary>
    /// The default from phone number.
    /// </summary>
    public static readonly PhoneNumber DefaultFromPhoneNumber = PhoneNumber.From(
        DefaultFromPhoneNumberString
    );

    private PhoneNumber? _defaultFrom;
    public override PhoneNumber DefaultFrom { get => _defaultFrom ??= DefaultFromPhoneNumber; set => _defaultFrom ??= value; }

    /// <summary>
    /// Initializes a new instance of the <see cref="SmsSenderOptions"/> class.
    /// </summary>
    /// <param name="connectionString">The connection string.</param>
    public SmsSenderOptions(string connectionString) : base(connectionString) { }

    /// <summary>
    /// Initializes a new instance of the <see cref="SmsSenderOptions"/> class.
    /// </summary>
    /// <param name="connectionString">The connection string.</param>
    /// <param name="fromPhoneNumber">The from phone number.</param>
    public SmsSenderOptions(string connectionString, PhoneNumber? fromPhoneNumber = null)
        : base(connectionString) { }

    /// <summary>
    /// Initializes a new instance of the <see cref="SmsSenderOptions"/> class.
    /// </summary>
    public SmsSenderOptions() : this(string.Empty) { }
}
