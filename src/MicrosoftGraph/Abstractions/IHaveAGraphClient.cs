namespace Dgmjr.Graph.Abstractions;
public interface IHaveAGraphClient
{
    /// <summary>Retrieves the current instance of <see cref="GraphServiceClient" /> being used to service the request</summary>
    public GraphServiceClient Graph { get; }
}
