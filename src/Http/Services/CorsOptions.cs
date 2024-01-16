namespace Dgmjr.AspNetCore.Http.Services;

using Microsoft.AspNetCore.Cors.Infrastructure;
using System.Collections;
using ICorsPolicyDictionary = IDictionary<
    string,
    Microsoft.AspNetCore.Cors.Infrastructure.CorsPolicy
>;
using CorsPolicyDictionary = Dictionary<
    string,
    Microsoft.AspNetCore.Cors.Infrastructure.CorsPolicy
>;
using ICorsPolicyCollection = ICollection<KeyValuePair<string, Microsoft.AspNetCore.Cors.Infrastructure.CorsPolicy>>;
using ICorsPolicyEnumerable = IEnumerable<KeyValuePair<string, Microsoft.AspNetCore.Cors.Infrastructure.CorsPolicy>>;
using System.Diagnostics.CodeAnalysis;

public class CorsOptions : Microsoft.AspNetCore.Cors.Infrastructure.CorsOptions
{
    public CorsOptions() { }

    public CorsOptions(ICorsPolicyDictionary dictionary) => dictionary.ToList().ForEach(Add);

    public CorsOptions(IConfigurationSection section) => section.Bind(this);

    public CorsOptions(ICorsPolicyEnumerable collection) =>
        collection.ToList().ForEach(Add);

    public CorsOptions(int capacity) { }

    public CorsPolicy this[string key] { get => Policies[key]; set => Policies[key] = value; }

    public ICorsPolicyDictionary Policies { get; } = new CorsPolicyDictionary();

    public ICollection<string> Keys => Policies.Keys;

    public ICollection<CorsPolicy> Values => Policies.Values;

    public int Count => Policies.Count;

    public bool IsReadOnly => Policies.IsReadOnly;

    public void Add(string key, CorsPolicy value)
    {
        Policies.Add(key, value);
    }

    public void Add(KeyValuePair<string, CorsPolicy> item)
    {
        Policies.Add(item);
    }

    public void Clear()
    {
        Policies.Clear();
    }

    public bool Contains(KeyValuePair<string, CorsPolicy> item)
    {
        return Policies.Contains(item);
    }

    public bool ContainsKey(string key)
    {
        return Policies.ContainsKey(key);
    }

    public void CopyTo(KeyValuePair<string, CorsPolicy>[] array, int arrayIndex)
    {
        Policies.CopyTo(array, arrayIndex);
    }

    public IEnumerator<KeyValuePair<string, CorsPolicy>> GetEnumerator()
    {
        return Policies.GetEnumerator();
    }

    public bool Remove(string key)
    {
        return Policies.Remove(key);
    }

    public bool Remove(KeyValuePair<string, CorsPolicy> item)
    {
        return Policies.Remove(item);
    }

    public bool TryGetValue(string key, [MaybeNullWhen(false)] out CorsPolicy value)
    {
        return Policies.TryGetValue(key, out value);
    }
}
