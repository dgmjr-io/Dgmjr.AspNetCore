/*
 * PasswordGenerator.cs
 *
 *   Created: 2022-12-31-06:39:48
 *   Modified: 2022-12-31-06:39:49
 *
 *   Author: David G. Moore, Jr. <david@dgmjr.io>
 *
 *   Copyright © 2022-2023 David G. Moore, Jr., All Rights Reserved
 *      License: MIT (https://opensource.org/licenses/MIT)
 */

namespace Dgmjr.Identity;

public interface IPassphraseGenerator
{
    string Generate();
}
