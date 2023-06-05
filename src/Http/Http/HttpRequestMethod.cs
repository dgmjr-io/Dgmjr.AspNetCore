/* 
 * HttpRequestMethod.cs
 * 
 *   Created: 2023-03-18-11:54:28
 *   Modified: 2023-03-18-11:54:29
 * 
 *   Author: David G. Moore, Jr. <david@dgmjr.io>
 *   
 *   Copyright © 2022-2023 David G. Moore, Jr., All Rights Reserved
 *      License: MIT (https://opensource.org/licenses/MIT)
 */

namespace System.Net.Http;

public partial record struct HttpRequestMethod
{
    public static implicit operator HttpRequestMethod(string value) => HttpRequestMethod.Parse(value);
    public static implicit operator string(HttpRequestMethod value) => value.ToString();
    public static implicit operator Enums.HttpRequestMethod(HttpRequestMethod value) => value.Value;
    public static implicit operator HttpRequestMethod(Enums.HttpRequestMethod value) => HttpRequestMethod.TryFromValue(value, out var result) ? result : default;
    public static implicit operator HttpMethod(HttpRequestMethod value) => new HttpMethod(value.ToString());
    public static implicit operator HttpRequestMethod(HttpMethod value) => HttpRequestMethod.TryParse(value.Method, out var result) ? result : default;
}
