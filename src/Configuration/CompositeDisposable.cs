namespace Microsoft.Extensions.DependencyInjection;

internal class CompositeDisposable : IDisposable
{
    private readonly List<IDisposable> _disposables = new List<IDisposable>();
    private bool disposed = false;

    public CompositeDisposable(IEnumerable<IDisposable> disposables)
    {
        _disposables.AddRange(disposables);
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (!disposed)
        {
            if (disposing)
            {
                foreach (var disposable in _disposables)
                {
                    disposable.Dispose();
                }
            }

            disposed = true;
        }
    }
}
