/*
 * Operations copy.cs
 *
 *   Created: 2023-01-03-03:13:58
 *   Modified: 2023-01-03-03:13:59
 *
 *   Author: David G. Moore, Jr, <david@dgmjr.io>
 *
 *   Copyright © 2022-2023 David G. Moore, Jr,, All Rights Reserved
 *      License: MIT (https://opensource.org/licenses/MIT)
 */

namespace Dgmjr.AspNetCore.Authorization.Enums;

[GenerateEnumerationClass(
    nameof(Dgmjr.AspNetCore.Authorization.Operations),
    "Dgmjr.AspNetCore.Authorization"
)]
public enum OperationsEnum
{
    [Uri(Dgmjr.Security.Operations.Create.UriString)]
    Create = Dgmjr.Security.Operations.Create.Value,

    [Uri(Dgmjr.Security.Operations.Create.UriString)]
    Read = Dgmjr.Security.Operations.Read.Value,

    [Uri(Dgmjr.Security.Operations.Create.UriString)]
    Update = Dgmjr.Security.Operations.Update.Value,

    [Uri(Dgmjr.Security.Operations.Create.UriString)]
    Delete = Dgmjr.Security.Operations.Delete.Value,

    [Uri(Dgmjr.Security.Operations.Create.UriString)]
    All = Dgmjr.Security.Operations.All.Value
}
