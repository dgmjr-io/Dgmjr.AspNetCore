namespace Dgmjr.Blazor.ActiveUsers;

using System.Collections;
using System.Collections.Concurrent;
using System.Threading.Tasks.Sources;
using System.Collections.Generic;

public class ActiveUsersList : ConcurrentDictionary<string, ActiveUser>, IActiveUsersList, IDictionary<string, ActiveUser>, ICollection<ActiveUser>
{
    public virtual bool IsReadOnly => false;

    public virtual bool Remove(ActiveUser user) => TryRemove(user.UserId, out _);
    public new virtual ActiveUser[] ToArray() => Values.ToArray();
    public virtual void CopyTo(ActiveUser[] array, int index) => Values.CopyTo(array, index);

    public virtual void Add(ActiveUser user) => TryAdd(user.UserId, user);

    public virtual bool Contains(ActiveUser user) => Contains(user.UserId);

    public virtual bool Contains(guid userId) => Contains(userId.ToString());

    public virtual bool Contains(string userId) => base.ContainsKey(userId);

    IEnumerator<ActiveUser> IEnumerable<ActiveUser>.GetEnumerator() => Values.GetEnumerator();
}
