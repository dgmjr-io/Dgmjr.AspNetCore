namespace Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Primitives;

public class CompositeChangeToken(params IChangeToken[] changeTokens) : IChangeToken
{
    private readonly IChangeToken[] _changeTokens = changeTokens;

public bool ActiveChangeCallbacks => Exists(_changeTokens, t => t.ActiveChangeCallbacks);

public bool HasChanged => Exists(_changeTokens, t => t.HasChanged);

public IDisposable RegisterChangeCallback(Action<object?> callback, object? state) =>
    new CompositeDisposable(
        _changeTokens.Select(t => t.RegisterChangeCallback(callback, state))
    );
}
