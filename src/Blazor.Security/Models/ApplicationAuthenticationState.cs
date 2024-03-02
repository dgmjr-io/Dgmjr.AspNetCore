namespace Dgmjr.Blazor.Security.Models;
using System;
using System.Collections.Generic;

public readonly record struct ApplicationAuthenticationState
{
    public bool IsAuthenticated { get; init; }
    public string Name { get; init; }
    public IEnumerable<ApplicationClaim> Claims { get; init; }
}
