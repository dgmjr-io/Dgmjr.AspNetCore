/*
 * MessageMediaTypeNames.cs
 *
 *   Created: 2023-03-18-07:11:59
 *   Modified: 2023-03-18-07:11:59
 *
 *   Author: David G. Moore, Jr. <david@dgmjr.io>
 *
 *   Copyright © 2022-2023 David G. Moore, Jr., All Rights Reserved
 *      License: MIT (https://opensource.org/licenses/MIT)
 */

namespace System.Net.Mime.MediaTypes;

public static class MessageMediaTypeNames
{
    public const string Base = "message";

    public const string Any = Base + "/*";

    /// <see href="https://www.iana.org/assignments/media-types/message/bhttp">[RFC9292]</see>
    /// <value>message/bhttp</value>
    /// <summary> The message/bhttp MIME type</summary>
    public const string bhttp = Base + "/" + "+ bhttp";

    /// <see href="https://www.iana.org/assignments/media-types/message/CPIM">[RFC3862]</see>
    /// <value>message/CPIM</value>
    /// <summary> The message/CPIM MIME type</summary>
    public const string CPIM = Base + "/" + "+ CPIM";

    /// <see href="https://www.iana.org/assignments/media-types/message/delivery-status">[RFC1894]</see>
    /// <value>message/delivery-status</value>
    /// <summary> The message/delivery-status MIME type</summary>
    public const string delivery_status = Base + "/" + "+ delivery_status";

    /// <see href="https://www.iana.org/assignments/media-types/message/disposition-notification">[RFC8098]</see>
    /// <value>message/disposition-notification</value>
    /// <summary> The message/disposition-notification MIME type</summary>
    public const string disposition_notification = Base + "/" + "+ disposition_notification";

    /// <see href="https://www.iana.org/assignments/media-types/message/example">[RFC4735]</see>
    /// <value>message/example</value>
    /// <summary> The message/example MIME type</summary>
    public const string example = Base + "/" + "+ example";

    /// <see>[RFC2045][RFC2046]</see>
    /// <value></value>
    /// <summary> The  MIME type</summary>
    public const string external_body = Base + "/" + "+ external_body";

    /// <see href="https://www.iana.org/assignments/media-types/message/feedback-report">[RFC5965]</see>
    /// <value>message/feedback-report</value>
    /// <summary> The message/feedback-report MIME type</summary>
    public const string feedback_report = Base + "/" + "+ feedback_report";

    /// <see href="https://www.iana.org/assignments/media-types/message/global">[RFC6532]</see>
    /// <value>message/global</value>
    /// <summary> The message/global MIME type</summary>
    public const string global = Base + "/" + "+ global";

    /// <see href="https://www.iana.org/assignments/media-types/message/global-delivery-status">[RFC6533]</see>
    /// <value>message/global-delivery-status</value>
    /// <summary> The message/global-delivery-status MIME type</summary>
    public const string global_delivery_status = Base + "/" + "+ global_delivery_status";

    /// <see href="https://www.iana.org/assignments/media-types/message/global-disposition-notification">[RFC6533]</see>
    /// <value>message/global-disposition-notification</value>
    /// <summary> The message/global-disposition-notification MIME type</summary>
    public const string global_disposition_notification =
        Base + "/" + "+ global_disposition_notification";

    /// <see href="https://www.iana.org/assignments/media-types/message/global-headers">[RFC6533]</see>
    /// <value>message/global-headers</value>
    /// <summary> The message/global-headers MIME type</summary>
    public const string global_headers = Base + "/" + "+ global_headers";

    /// <see href="https://www.iana.org/assignments/media-types/message/http">[RFC9112]</see>
    /// <value>message/http</value>
    /// <summary> The message/http MIME type</summary>
    public const string http = Base + "/" + "+ http";

    /// <see href="https://www.iana.org/assignments/media-types/message/imdn+xml">[RFC5438]</see>
    /// <value>message/imdn+xml</value>
    /// <summary> The message/imdn+xml MIME type</summary>
    public const string imdn_xml = Base + "/" + "+ imdn_xml";

    /// <see>[RFC2045][RFC2046]</see>
    /// <value></value>
    /// <summary> The  MIME type</summary>
    public const string partial = Base + "/" + "+ partial";

    /// <see>[RFC2045][RFC2046]</see>
    /// <value></value>
    /// <summary> The  MIME type</summary>
    public const string rfc822 = Base + "/" + "+ rfc822";

    /// <see href="https://www.iana.org/assignments/media-types/message/sip">[RFC3261]</see>
    /// <value>message/sip</value>
    /// <summary> The message/sip MIME type</summary>
    public const string sip = Base + "/" + "+ sip";

    /// <see href="https://www.iana.org/assignments/media-types/message/sipfrag">[RFC3420]</see>
    /// <value>message/sipfrag</value>
    /// <summary> The message/sipfrag MIME type</summary>
    public const string sipfrag = Base + "/" + "+ sipfrag";

    /// <see href="https://www.iana.org/assignments/media-types/message/tracking-status">[RFC3886]</see>
    /// <value>message/tracking-status</value>
    /// <summary> The message/tracking-status MIME type</summary>
    public const string tracking_status = Base + "/" + "+ tracking_status";

    /// <see href="https://www.iana.org/assignments/media-types/message/vnd.wfa.wsc">[Mick_Conley]</see>
    /// <value>message/vnd.wfa.wsc</value>
    /// <summary> The message/vnd.wfa.wsc MIME type</summary>
    public const string vnd_wfa_wsc = Base + "/" + "+ vnd_wfa_wsc";
}
