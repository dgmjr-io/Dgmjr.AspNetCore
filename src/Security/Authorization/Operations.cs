/*
 * Operations.cs
 *
 *   Created: 2023-01-02-11:13:55
 *   Modified: 2023-01-10-06:40:18
 *
 *   Author: David G. Moore, Jr, <david@dgmjr.io>
 *
 *   Copyright © 2022-2023 David G. Moore, Jr,, All Rights Reserved
 *      License: MIT (https://opensource.org/licenses/MIT)
 */
namespace Dgmjr.AspNetCore.Authorization;

using Abstractions;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using DgmjrSecOps = Dgmjr.Security.Operations;
using Dgmjr.Security.Enums;

public partial class Operations : OperationAuthorizationRequirement
{
    public virtual bool Equals(Operations? other) =>
        other is OperationAuthorizationRequirement oar && oar.Name == other.Name;

    // override public bool Equals(object? obj) => Equals(obj as OperationAuthorizationRequirement);

    // override public int GetHashCode() => Name.GetHashCode();

    // public static bool operator ==(Operations left, Operations right)
    // {
    //     if (ReferenceEquals(left, null))
    //     {
    //         return ReferenceEquals(right, null);
    //     }

    //     return left.Equals(right);
    // }

    // public static bool operator !=(Operations left, Operations right)
    // {
    //     return !(left == right);
    // }

    public static implicit operator DgmjrSecOps?(Operations op) =>
        (DgmjrSecOps)
            DgmjrSecOps.FromValue(
                (Dgmjr.Security.Enums.Operations)((IHaveAValue<Enums.OperationsEnum>)op).Value
            );
}
