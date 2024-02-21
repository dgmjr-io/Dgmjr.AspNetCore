namespace Dgmjr.Blazor.ActiveUsers;
using System.Collections.Generic;

public interface IActiveUsersList
{
    void Add(ActiveUser user);
    ActiveUser[] ToArray();
    bool Remove(ActiveUser user);
    bool Contains(ActiveUser user);
    bool Contains(guid userId);
    int Count { get; }
}
