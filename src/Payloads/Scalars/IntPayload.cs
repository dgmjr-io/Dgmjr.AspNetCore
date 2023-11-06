//
// IntPayload.cs
//
//   Created: 2022-10-31-08:33:05
//   Modified: 2022-10-31-08:40:31
//
//   Author: David G. Moore, Jr, <david@dgmjr.io>
//
//   Copyright © 2022-2023 David G. Moore, Jr,, All Rights Reserved
//      License: MIT (https://opensource.org/licenses/MIT)
//

using System.Globalization;

namespace Dgmjr.Payloads;

public class IntPayload(int value) : Payload<int>(value, value.ToString(CultureInfo.CurrentCulture))
{
    public IntPayload()
        : this(0) { }
}
