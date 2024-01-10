namespace Dgmjr.Web.DownstreamApis;

using System.Collections;

public record class DownstreamApis : DownstreamApisBase, IDownstreamApis
{
    public const string MicrosoftGraphOptions = "MicrosoftGraph";

    MicrosoftGraphOptions IDownstreamApis.MicrosoftGraph { get; set; }

    public IDictionary<string, DownstreamApiOptions> DownstreamApiOptions { get; set; } =
        new Dictionary<string, DownstreamApiOptions>();
}
