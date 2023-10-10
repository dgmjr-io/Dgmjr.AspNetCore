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
namespace Dgmjr.AspNetCore.Authentication;

using Enums;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using DgmjrSecOps = Dgmjr.Security.Operations;

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

    public static implicit operator DgmjrSecOps(Operations op) =>
        op.Value switch
        {
            OperationsEnum.Create => DgmjrSecOps.Create.Instance,
            OperationsEnum.Read => DgmjrSecOps.Read.Instance,
            OperationsEnum.Update => DgmjrSecOps.Update.Instance,
            OperationsEnum.Delete => DgmjrSecOps.Delete.Instance,
            _
                => throw new InvalidCastException(
                    $"Could not cast the value {op} into an object of type {typeof(JwcSecOps)}"
                )
        };
}
