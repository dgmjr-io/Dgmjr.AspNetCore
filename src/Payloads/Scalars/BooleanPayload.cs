//
// BooleanPayload.cs
//
//   Created: 2022-10-31-08:33:05
//   Modified: 2022-10-31-08:33:46
//
//   Author: David G. Moore, Jr, <david@dgmjr.io>
//
//   Copyright © 2022-2023 David G. Moore, Jr,, All Rights Reserved
//      License: MIT (https://opensource.org/licenses/MIT)
//

namespace Dgmjr.Payloads;

public class BooleanPayload(bool value) : Payload<bool>(value, value.ToString())
{
    public BooleanPayload()
        : this(true) { }

    public override string ToString() => Value.ToString();
}
