/*
 * HttpMethod.cs
 *
 *   Created: 2022-11-19-09:29:46
 *   Modified: 2022-11-19-09:29:47
 *
 *   Author: David G. Moore, Jr, <david@dgmjr.io>
 *
 *   Copyright © 2022-2023 David G. Moore, Jr,, All Rights Reserved
 *      License: MIT (https://opensource.org/licenses/MIT)
 */

namespace System.Net.Http.Enums;
using System.Runtime.Serialization;
using System.ComponentModel.DataAnnotations;

[GenerateEnumerationRecordStruct("HttpRequestMethod", "System.Net.Http")]
public enum HttpRequestMethod
{
    /// <summary>Establishes a network connection to a resource.</summary>
    /// /// <value>CONNECT</value>
    [Display(Name = "CONNECT", Description = "Establishes a network connection to a resource.")]
    [EnumMember(Value = "CONNECT")]
    [EnumValue("CONNECT")]
    Connect,

    /// <summary>Deletes a resource identified by a URI.</summary>
    /// <value>DELETE</value>
    [Display(Name = "DELETE", Description = "Deletes a resource identified by a URI.")]
    [EnumMember(Value = "DELETE")]
    [EnumValue("DELETE")]
    Delete,

    /// <summary>Retrieves a representation of a resource.</summary>
    /// <value>GET</value>
    [Display(Name = "GET", Description = "Retrieves a representation of a resource.")]
    [EnumMember(Value = "GET")]
    [EnumValue("GET")]
    Get,

    /// <summary>Retrieves the header information for a resource.</summary>
    /// <value>HEAD</value>
    [Display(Name = "HEAD", Description = "Retrieves the header information for a resource.")]
    [EnumMember(Value = "HEAD")]
    [EnumValue("HEAD")]
    Head,

    /// <summary>Describes the communication options for the target resource.</summary>
    /// <value>OPTIONS</value>
    [Display(Name = "OPTIONS", Description = "Describes the communication options for the target resource.")]
    [EnumMember(Value = "OPTIONS")]
    [EnumValue("OPTIONS")]
    Options,

    /// <summary>Applies partial modifications to a resource.</summary>
    /// <value>PATCH</value>
    [Display(Name = "PATCH", Description = "Applies partial modifications to a resource.")]
    [EnumMember(Value = "PATCH")]
    [EnumValue("PATCH")]
    Patch,

    /// <summary>Submits an entity to a resource.</summary>
    /// <value>POST</value>
    [Display(Name = "POST", Description = "Submits an entity to a resource.")]
    [EnumMember(Value = "POST")]
    [EnumValue("POST")]
    Post,

    /// <summary>Replaces a resource with a new representation.</summary>
    /// <value>PUT</value>
    [Display(Name = "PUT", Description = "Replaces a resource with a new representation.")]
    [EnumMember(Value = "PUT")]
    [EnumValue("PUT")]
    Put,

    /// <summary>Performs a message loop-back test along the path to the target resource.</summary>
    /// <value>TRACE</value>
    [Display(Name = "TRACE", Description = "Performs a message loop-back test along the path to the target resource.")]
    [EnumMember(Value = "TRACE")]
    [EnumValue("TRACE")]
    Trace,
}
