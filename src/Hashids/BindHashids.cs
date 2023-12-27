/*
 * BindHashids.cs
 *
 *   Created: 2022-12-20-01:47:37
 *   Modified: 2022-12-20-01:47:38
 *
 *   Author: David G. Moore, Jr, <david@dgmjr.io>
 *
 *   Copyright © 2022-2023 David G. Moore, Jr,, All Rights Reserved
 *      License: MIT (https://opensource.org/licenses/MIT)
 */

using global::AspNetCore.Hashids;

public class HashidsAttribute : ModelBinderAttribute
{
    public HashidsAttribute()
        : base(typeof(global::AspNetCore.Hashids.Mvc.HashidsModelBinder)) { }
}
