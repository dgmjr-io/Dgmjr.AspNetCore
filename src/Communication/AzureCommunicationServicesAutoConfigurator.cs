/*
 * AutoConfigurator.cs
 *
 *   Created: 2024-17-19T08:17:28-05:00
 *   Modified: 2024-17-19T08:17:28-05:00
 *
 *   Author: David G. Moore, Jr. <david@dgmjr.io>
 *
 *   Copyright © 2024 David G. Moore, Jr., All Rights Reserved
 *      License: MIT (https://opensource.org/licenses/MIT)
 */

namespace Microsoft.Extensions.DependencyInjection;

using Dgmjr.AspNetCore.Communication;
using Dgmjr.AspNetCore.Communication.Email;
using Dgmjr.AspNetCore.Communication.Sms;

using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

public class AzureCommunicationServicesAutoConfigurator(
    ILogger<AzureCommunicationServicesAutoConfigurator> logger
) : IConfigureIHostApplicationBuilder, IConfigureIApplicationBuilder, ILog
{
    public ConfigurationOrder Order => ConfigurationOrder.AnyTime;

public ILogger Logger => logger;

public void Configure(IApplicationBuilder builder)
{
    var emailSenderOptions = builder.ApplicationServices.GetService<
        IOptions<EmailSenderOptions>
    >();
    if (emailSenderOptions is null)
    {
        Logger.LogWarning(
            "Azure Email Communication Services options are not configured. Please configure them in your appsettings.json file."
        );
    }
    var smsSenderOptions = builder.ApplicationServices.GetService<IOptions<SmsSenderOptions>>();
    if (smsSenderOptions is null)
    {
        Logger.LogWarning(
            "Azure SMS Communication Services options are not configured. Please configure them in your appsettings.json file."
        );
    }
}

public void Configure(IHostApplicationBuilder builder)
{
    var optionsSection = builder.Configuration.GetSection(
        AzureCommunicationServicesOptionsBase.ConfigurationSectionName
    );
    if (!optionsSection.Exists())
    {
        Logger.LogWarning(
            "Azure Communication Services options are not configured. Please configure them in your appsettings.json file."
        );
    }
    else
    {
        builder.Services.Configure<AzureCommunicationServicesOptions>(optionsSection);

        var emailCommunicationSection = builder.Configuration.GetSection(
            EmailSenderOptions.ConfigurationSectionName
        );
        if (!emailCommunicationSection.Exists())
        {
            Logger.LogWarning(
                "Azure Email Communication Services options are not configured. Please configure them in your appsettings.json file."
            );
            builder.Services.AddSingleton<IEmailSender>(
                y =>
                    throw new KeyNotFoundException(
                        $"The {nameof(EmailSenderOptions)} configuration section was not found in the appsettings.json file."
                    )
            );
        }
        else
        {
            builder.Services.Configure<EmailSenderOptions>(emailCommunicationSection);
            builder.Services.AddSingleton<IEmailSender>(
                y =>
                    new EmailSender(
                        y.GetService<IOptions<EmailSenderOptions>>()
                            ?? throw new KeyNotFoundException(
                                $"The {nameof(EmailSenderOptions)} configuration section was not found in the appsettings.json file."
                            )
                    )
            );
        }
        var smsCommunicationSection = builder.Configuration.GetSection(
            SmsSenderOptions.ConfigurationSectionName
        );
        if (!smsCommunicationSection.Exists())
        {
            Logger.LogWarning(
                "Azure SMS Communication Services options are not configured. Please configure them in your appsettings.json file."
            );
            builder.Services.AddSingleton<ISmsSender>(
                y =>
                    throw new KeyNotFoundException(
                        $"The {nameof(SmsSenderOptions)} configuration section was not found in the appsettings.json file."
                    )
            );
        }
        else
        {
            builder.Services.Configure<SmsSenderOptions>(smsCommunicationSection);
            builder.Services.AddSingleton<ISmsSender>(
                y =>
                    new SmsSender(
                        y.GetService<IOptions<SmsSenderOptions>>()
                            ?? throw new KeyNotFoundException(
                                $"The {nameof(SmsSenderOptions)} configuration section was not found in the appsettings.json file."
                            )
                    )
            );
        }
    }
}
}
