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

namespace Dgmjr.AspNetCore.Authentication.Enums;

[GenerateEnumerationClass(nameof(Operations), "Dgmjr.AspNetCore.Authentication")]
public enum OperationsEnum
{
    Create,
    Read,
    Update,
    Delete
}
