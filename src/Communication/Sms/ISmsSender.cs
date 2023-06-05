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
using System.Threading.Tasks;

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
