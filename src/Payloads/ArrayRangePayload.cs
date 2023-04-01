//
// ArrayPayload.cs
//
//   Created: 2022-10-31-08:33:05
//   Modified: 2022-10-31-08:33:26
//
//   Author: David G. Moore, Jr, <david@dgmjr.io>
//
//   Copyright © 2022-2023 David G. Moore, Jr,, All Rights Reserved
//      License: MIT (https://opensource.org/licenses/MIT)
//

namespace Dgmjr.Payloads;

// public record ArrayRangePayload<T>(IEnumerable<T>? Values = default)
//     : Payload<List<T>>(Values is null ? new List<T>() : Values.ToList());
// // {
//     // public IEnumerable<T> Values {get;} = Values is null ? Array.Empty<T>() : Values;
//     // public ArrayPayload() : this(Array.Empty<T>()) { }
//     // public ArrayPayload(IEnumerable<T> array) : base(array.ToList()) { }
// // }
