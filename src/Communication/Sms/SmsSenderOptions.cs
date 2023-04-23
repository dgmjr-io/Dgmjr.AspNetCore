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
