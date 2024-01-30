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
/// An sms sender.
/// </summary>
/// <remarks>
/// Initializes a new instance of the <see cref="SmsSender"/> class.
/// </remarks>
/// <param name="options">The options.</param>
public class SmsSender(SmsSenderOptions? options) : ISmsSender
{
    /// <summary>
    /// The options.
    /// </summary>
    private readonly SmsSenderOptions _options = options;

    /// <summary>
    /// Initializes a new instance of the <see cref="SmsSender"/> class.
    /// </summary>
    /// <param name="options">The options.</param>
    public SmsSender(IOptions<SmsSenderOptions> options)
        : this(options?.Value) { }

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
    public async Task<ISmsSendResult> SendSmsAsync(PhoneNumber @to, string message)
    {
        return new SmsSendResult(
            (await Client.SendAsync(from: _options.DefaultFrom, to: @to, message: message)).Value
        );
    }

    public Task<ISmsSendResult> SendSmsAsync(string to, string message) =>
        SendSmsAsync(PhoneNumber.From(to), message);
}
