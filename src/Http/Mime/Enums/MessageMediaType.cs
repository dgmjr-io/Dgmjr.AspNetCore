/*
 * MessageMediaType.cs
 *
 *   Created: 2023-10-10-01:45:14
 *   Modified: 2023-10-10-01:45:14
 *
 *   Author: David G. Moore, Jr. <david@dgmjr.io>
 *
 *   Copyright © 2022 - 2023 David G. Moore, Jr., All Rights Reserved
 *      License: MIT (https://opensource.org/licenses/MIT)
 */

namespace Dgmjr.Mime.Enums;

[GenerateEnumerationRecordStruct("MessageMediaType", "Dgmjr.Mime")]
public enum MessageMediaType
{
    [Uri(IanaMediaTypeUrlBase + MediaTypes_xhtml + "#message")]
    Base,

    [Uri(IanaMediaTypeUrlBase + MediaTypes_xhtml + "#message-*")]
    Any,

    [Uri(IanaMediaTypeUrlBase + "message/bhttp")]
    [Display(
        Name = "message/bhttp",
        ShortName = "bhttp",
        Description = " The message/bhttp MIME type"
    )]
    Bhttp,

    [Uri(IanaMediaTypeUrlBase + "message/CPIM")]
    [Display(
        Name = "message/CPIM",
        ShortName = "CPIM",
        Description = " The message/CPIM MIME type"
    )]
    CPIM,

    [Uri(IanaMediaTypeUrlBase + "message/delivery-status")]
    [Display(
        Name = "message/delivery-status",
        ShortName = "delivery_status",
        Description = " The message/delivery-status MIME type"
    )]
    DeliveryStatus,

    [Uri(IanaMediaTypeUrlBase + "message/disposition-notification")]
    [Display(
        Name = "message/disposition-notification",
        ShortName = "disposition_notification",
        Description = " The message/disposition-notification MIME type"
    )]
    DispositionNotification,

    [Uri(IanaMediaTypeUrlBase + "message/example")]
    [Display(
        Name = "message/example",
        ShortName = "example",
        Description = " The message/example MIME type"
    )]
    Example,

    [Uri("urn:ietf:rfc:2046:5.2.3")]
    [Display(Name = "", ShortName = "external_body", Description = " The  MIME type")]
    ExternalBody,

    [Uri(IanaMediaTypeUrlBase + "message/feedback-report")]
    [Display(
        Name = "message/feedback-report",
        ShortName = "feedback_report",
        Description = " The message/feedback-report MIME type"
    )]
    FeedbackReport,

    [Uri(IanaMediaTypeUrlBase + "message/global")]
    [Display(
        Name = "message/global",
        ShortName = "global",
        Description = " The message/global MIME type"
    )]
    Global,

    [Uri(IanaMediaTypeUrlBase + "message/global-delivery-status")]
    [Display(
        Name = "message/global-delivery-status",
        ShortName = "global_delivery_status",
        Description = " The message/global-delivery-status MIME type"
    )]
    GlobalDeliveryStatus,

    [Uri(IanaMediaTypeUrlBase + "message/global-disposition-notification")]
    [Display(
        Name = "message/global-disposition-notification",
        ShortName = "global_disposition_notification",
        Description = "The message/global-disposition-notification MIME type"
    )]
    GlobalDispositionNotification,

    [Uri(IanaMediaTypeUrlBase + "message/global-headers")]
    [Display(
        Name = "message/global-headers",
        ShortName = "global_headers",
        Description = " The message/global-headers MIME type"
    )]
    GlobalHeaders,

    [Uri(IanaMediaTypeUrlBase + "message/http")]
    [Display(
        Name = "message/http",
        ShortName = "http",
        Description = " The message/http MIME type"
    )]
    Http,

    [Uri(IanaMediaTypeUrlBase + "message/imdn+xml")]
    [Display(
        Name = "message/imdn+xml",
        ShortName = "imdn_xml",
        Description = " The message/imdn+xml MIME type"
    )]
    ImdnXml,

    [Uri("urn:ietf:rfc:2046:5.2.2")]
    [Display(Name = "", ShortName = "partial", Description = " The  MIME type")]
    Partial,

    [Uri("urn:ietf:rfc:822")]
    [Display(Name = "", ShortName = "rfc822", Description = " The  MIME type")]
    Rfc822,

    [Uri(IanaMediaTypeUrlBase + "message/sip")]
    [Display(Name = "message/sip", ShortName = "sip", Description = " The message/sip MIME type")]
    Sip,

    [Uri(IanaMediaTypeUrlBase + "message/sipfrag")]
    [Display(
        Name = "message/sipfrag",
        ShortName = "sipfrag",
        Description = " The message/sipfrag MIME type"
    )]
    Sipfrag,

    [Uri(IanaMediaTypeUrlBase + "message/tracking-status")]
    [Display(
        Name = "message/tracking-status",
        ShortName = "tracking_status",
        Description = " The message/tracking-status MIME type"
    )]
    TrackingStatus,

    [Uri(IanaMediaTypeUrlBase + "message/vnd.wfa.wsc")]
    [Display(
        Name = "message/vnd.wfa.wsc",
        ShortName = "vnd_wfa_wsc",
        Description = " The message/vnd.wfa.wsc MIME type"
    )]
    vnd_wfa_wsc,
}
