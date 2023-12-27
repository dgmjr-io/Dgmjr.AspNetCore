namespace Dgmjr.Web.DownstreamApis;
using System.Net.Http;

public class DownstreamApiOptionsConfigurator(IOptions<JsonOptions> jsonOptions)
    : IConfigureOptions<DownstreamApiOptions>
{
    private readonly Jso _jso = jsonOptions?.Value?.JsonSerializerOptions;

    public void Configure(DownstreamApiOptions options)
    {
        options.Serializer = requestObject =>
            new StringContent(
                Serialize(requestObject, _jso),
                UTF8,
                Application.Json.DisplayName
            );
    }
}
