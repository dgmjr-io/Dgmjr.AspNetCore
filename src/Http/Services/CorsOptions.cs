namespace Dgmjr.AspNetCore.Http.Services;

using Microsoft.AspNetCore.Cors.Infrastructure;
using System.Collections;
using ICorsPolicyDictionary = IDictionary<
    string,
    Microsoft.AspNetCore.Cors.Infrastructure.CorsPolicy
>;
using ICorsPolicyCollection = ICollection<KeyValuePair<string,  Microsoft.AspNetCore.Cors.Infrastructure.CorsPolicy>>;
using ICorsPolicyEnumerable = IEnumerable<KeyValuePair<string, Microsoft.AspNetCore.Cors.Infrastructure.CorsPolicy>>;

public class CorsOptions
    : Microsoft.AspNetCore.Cors.Infrastructure.CorsOptions,
        ICorsPolicyDictionary
{
    public CorsOptions() { }

    public CorsOptions(ICorsPolicyDictionary dictionary) => dictionary.ToList().ForEach(Add);

    public CorsOptions(IEnumerable<KeyValuePair<string, CorsPolicy>> collection) =>
        collection.ToList().ForEach(Add);

    public CorsOptions(int capacity) { }

    public bool TryGetValue(string key, [MaybeNullWhen(false)] out CorsPolicy value) =>
        (value = GetPolicy(key)) != null;

    public void Add(KeyValuePair<string, CorsPolicy> item) => AddPolicy(item.Key, item.Value);

    public void Add(string key, CorsPolicy value) => AddPolicy(key, value);

    public bool Contains(KeyValuePair<string, CorsPolicy> item) => ContainsKey(item.Key);

    public bool ContainsKey(string key) => GetPolicy(key) != null;

    void ICorsPolicyCollection.CopyTo(KeyValuePair<string, CorsPolicy>[] array, int arrayIndex) =>
        throw new NotImplementedException();

    bool ICorsPolicyCollection.Remove(KeyValuePair<string, CorsPolicy> item) =>
        throw new NotImplementedException();

    bool ICorsPolicyDictionary.Remove(string key) => throw new NotImplementedException();

    public CorsPolicy this[string key]
    {
        get => GetPolicy(key) ?? throw new KeyNotFoundException();
        set => AddPolicy(key, value);
    }

    ICollection<string> ICorsPolicyDictionary.Keys => throw new NotImplementedException();

    ICollection<CorsPolicy> ICorsPolicyDictionary.Values => throw new NotImplementedException();

    IEnumerator<KeyValuePair<string, CorsPolicy>> ICorsPolicyEnumerable.GetEnumerator() =>
        throw new NotImplementedException();

    IEnumerator IEnumerable.GetEnumerator() => throw new NotImplementedException();

    void ICorsPolicyCollection.Clear() => throw new NotImplementedException();

    int ICorsPolicyCollection.Count => throw new NotImplementedException();

    bool ICorsPolicyCollection.IsReadOnly => false;
}
