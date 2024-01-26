using Microsoft.Extensions.DependencyInjection;

namespace Dgmjr.Configuration.Extensions;

public class MultiServiceCollection(params IServiceCollection[] collections)
    : MultiCollection<ServiceDescriptor>(collections),
        IServiceCollection
{
    private readonly IServiceCollection[] _collections;

public ServiceDescriptor this[int index]
{
    get => _collections[0][index];
    set => throw new NotImplementedException();
}

public int IndexOf(ServiceDescriptor item) => _collections[0].IndexOf(item);

public void Insert(int index, ServiceDescriptor item)
{
    foreach (var collection in _collections)
    {
        collection.Insert(index, item);
    }
}

public void RemoveAt(int index)
{
    foreach (var collection in _collections)
    {
        collection.RemoveAt(index);
    }
}
}
