namespace Dgmjr.AspNetCore.Communication;

#if NET8_0_OR_GREATER
using SS = System.Diagnostics.CodeAnalysis.StringSyntaxAttribute;
#endif

using System;

using Dgmjr.AspNetCore.Communication.Email;
using Dgmjr.AspNetCore.Communication.Sms;

public class AzureCommunicationServicesOptions
{
    public EmailSenderOptions Email { get; set; } = new EmailSenderOptions();
    public SmsSenderOptions Sms { get; set; } = new SmsSenderOptions();
}

[RegexDto(_RegexString)]
public partial record class AzureCommunicationServicesOptionsBase
{
    public const string EmptyValue = "endpoint=https://empty.example;accessKey=NOTHING";
    public const string ConfigurationSectionName = "CommunicationServices";

#if NET8_0_OR_GREATER
    [@StringSyntax(SS.Regex)]
#endif
    public const string _RegexString =
        "^endpoint=(?<EndpointString:string>https://.*);accessKey=(?<AccessKey:string>.*)$";

    public uri Endpoint
    {
        get => EndpointString;
        init => EndpointString = value;
    }

    public AzureCommunicationServicesOptionsBase(uri endpoint, string accessKey)
    {
        Endpoint = endpoint;
        AccessKey = accessKey;
    }

    public virtual string ConnectionString
    {
        get => $"endpoint={Endpoint};accessKey={AccessKey}";
        // set
        // {
        //     var other = Parse(value);
        //     Endpoint = other.Endpoint;
        //     {
        //         OriginalString = value,
        //         Endpoint = other.Endpoint,
        //         AccessKey = other.AccessKey
        //     };
        // }
    }
}

public abstract partial record class AzureCommunicationServicesOptions<TAddressType>
    : AzureCommunicationServicesOptionsBase
{
    protected AzureCommunicationServicesOptions(string connectionString)
        : base(connectionString) { }

    protected AzureCommunicationServicesOptions(uri endpoint, string accessKey)
        : base(endpoint, accessKey) { }

    protected AzureCommunicationServicesOptions()
        : this(EmptyValue) { }

    public abstract TAddressType DefaultFrom { get; set; }

    private TAddressType? _massDistributionFrom;
    public virtual TAddressType MassDistributionFrom
    {
        get => _massDistributionFrom ?? DefaultFrom;
        set => _massDistributionFrom ??= value;
    }
    private TAddressType? _adminFrom;
    public virtual TAddressType AdminFrom
    {
        get => _adminFrom ?? DefaultFrom;
        set => _adminFrom ??= value;
    }
    private TAddressType? _securityFrom;
    public virtual TAddressType SecurityFrom
    {
        get => _securityFrom ?? DefaultFrom;
        set => _securityFrom ??= value;
    }
}
