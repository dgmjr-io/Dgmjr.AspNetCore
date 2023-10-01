//
// UriPayload.cs
//
//   Created: 2022-10-31-08:33:05
//   Modified: 2022-10-31-08:42:17
//
//   Author: David G. Moore, Jr, <david@dgmjr.io>
//
//   Copyright © 2022-2023 David G. Moore, Jr,, All Rights Reserved
//      License: MIT (https://opensource.org/licenses/MIT)
//

namespace Dgmjr.Payloads;

public class UriPayload : Payload<uri>
{
    public UriPayload()
        : this(uri.From("about:blank")) { }

    public UriPayload(uri value)
        : base(value) { }
}
