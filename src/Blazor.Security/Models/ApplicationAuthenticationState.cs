using System;
using System.Collections.Generic;

namespace Dgmjr.Blazor.Security.Models;

public partial class ApplicationAuthenticationState
{
    public bool IsAuthenticated { get; set; }
    public string Name { get; set; }
    public IEnumerable<ApplicationClaim> Claims { get; set; }
}
