/** <summary> The above code is defining a C# enum named "MailSendReponseCode" that represents various SMTP
response codes that can be returned by a mail server. It includes enum members with values
representing specific SMTP response codes and their corresponding descriptions. The code also
includes attributes for JSON serialization and code generation. </summary> */
using System.Text.Json.Serialization;

namespace Dgmjr.AspNetCore.Communication.Mail.Enums;

/// <summary>
/// This is a C# enum representing various SMTP response codes that can be returned by a mail server.
/// </summary>
[JConverter(typeof(JStringEnumConverter))]
[GenerateEnumerationRecordStruct("MailSendResponseCode", "Dgmjr.AspNetCore.Communication.Mail")]
public enum MailSendResponseCode
{
    /** <summary> `SmtpServiceReady = 220` is defining an enum member with a value of 220, which represents the SMTP
    response code for "Service ready". This enum is used to represent various SMTP response codes that
    can be returned by a mail server. </summmary> */
    SmtpServiceReady = 220,

    /** <summary> `SmtpServiceClosingTransmissionChannel = 221` is defining an enum member with a value of 221, which
    represents the SMTP response code for "Service closing transmission channel". This enum is used to
    represent various SMTP response codes that can be returned by a mail server. </summary> */
    SmtpServiceClosingTransmissionChannel = 221,

    /** <summary> `SmtpAuthenticationSuccessful = 235` is defining an enum member with a value of 235, which
    represents the SMTP response code for "Authentication successful". This enum member is used to
    represent the SMTP response code that is returned by a mail server when the authentication process
    is successful. </summary> */
    SmtpAuthenticationSuccessful = 235,

    /** <summary> `SmtpOk = 250` is defining an enum member with a value of 250, which represents the SMTP response
    code for "OK". This enum member is used to represent the SMTP response code that is returned by a
    mail server when a command or operation is successful. </summary> */
    SmtpOk = 250,

    /** <summary> `SmtpUserNotLocalWillForward = 251` is defining an enum member with a value of 251, which represents
    the SMTP response code for "User not local; will forward". This enum member is used to represent the
    SMTP response code that is returned by a mail server when the recipient's mailbox is not on the
    current server, but the server will forward the message to the appropriate server. </summary> */
    SmtpUserNotLocalWillForward = 251,

    /** <summary> `SmtpCannotVerifyUserButWillAcceptMessage = 252` is defining an enum member with a value of 252,
    which represents the SMTP response code for "Cannot verify user but will accept message". This enum
    member is used to represent the SMTP response code that is returned by a mail server when it cannot
    verify the recipient's mailbox existence, but will still accept the message for delivery. </summary> */
    SmtpCannotVerifyUserButWillAcceptMessage = 252,

    /** <summary> `SmtpStartMailInput = 354` is defining an enum member with a value of 354, which represents the SMTP
    response code for "Start mail input; end with <CRLF>.<CRLF>". This enum member is used to represent
    the SMTP response code that is returned by a mail server when it is ready to receive the message
    content from the client. </summary> */
    SmtpStartMailInput = 354,

    /** <summary> `SmtpServiceNotAvailable = 421` is defining an enum member with a value of 421, which represents the
    SMTP response code for "Service not available, closing transmission channel". This enum member is
    used to represent various SMTP response codes that can be returned by a mail server. </summary> */
    SmtpServiceNotAvailable = 421,

    /** <summary> `SmtpMailboxBusy = 450` is defining an enum member with a value of 450, which represents the SMTP
    response code for "Mailbox busy". This enum member is used to represent the SMTP response code that
    is returned by a mail server when the recipient's mailbox is busy and cannot accept new messages at
    the moment. </summary> */
    SmtpMailboxBusy = 450,

    /** <summary> `SmtpMailboxUnavailable = 550` is defining an enum member with a value of 550, which represents the
    SMTP response code for "Requested action not taken: mailbox unavailable". This enum member is used
    to represent the SMTP response code that is returned by a mail server when the recipient's mailbox
    is unavailable and cannot accept new messages at the moment. </summary> */
    SmtpMailboxUnavailable = 550,

    /** <summary> `SmtpActionNotTaken = 450` is defining an enum member with a value of 450, which represents the SMTP
    response code for "Action not taken". This enum member is used to represent the SMTP response code
    that is returned by a mail server when a requested action cannot be completed for some reason. </summary> */
    SmtpActionNotTaken = 450,

    /** <summary> `SmtpActionAborted = 451` is defining an enum member with a value of 451, which represents the SMTP
    response code for "Requested action aborted: local error in processing". This enum member is used to
    represent the SMTP response code that is returned by a mail server when a requested action is
    aborted due to a local error in processing. </summary> */
    SmtpActionAborted = 451,

    /** <summary> `SmtpInsufficientStorage = 452` is defining an enum member with a value of 452, which represents the
    SMTP response code for "Requested action not taken: insufficient system storage". This enum member
    is used to represent the SMTP response code that is returned by a mail server when the requested
    action cannot be completed due to insufficient system storage. </summary> */
    SmtpInsufficientStorage = 452,

    /** <summary> `SmtpSyntaxError = 500` is defining an enum member with a value of 500, which represents the SMTP
    response code for "Syntax error, command unrecognized". This enum member is used to represent the
    SMTP response code that is returned by a mail server when a command or parameter is not recognized
    or has a syntax error. </summary> */
    SmtpSyntaxError = 500,

    /** <summary> `SmtpSyntaxErrorInParameters = 501` is defining an enum member with a value of 501, which represents
    the SMTP response code for "Syntax error in parameters or arguments". This enum member is used to
    represent the SMTP response code that is returned by a mail server when a command or parameter has a
    syntax error. </summary> */
    SmtpSyntaxErrorInParameters = 501,

    /** <summary> `SmtpCommandNotImplemented = 502` is defining an enum member with a value of 502, which represents
    the SMTP response code for "Command not implemented". This enum member is used to represent the SMTP
    response code that is returned by a mail server when a command is not implemented or recognized by
    the server. </summary> */
    SmtpCommandNotImplemented = 502,

    /** <summary> `SmtpBadCommandSequence = 503` is defining an enum member with a value of 503, which represents the
    SMTP response code for "Bad sequence of commands". This enum member is used to represent the SMTP
    response code that is returned by a mail server when a command is issued in the wrong order or
    sequence. </summary> */
    SmtpBadCommandSequence = 503,

    /** <summary> The above code is a C# comment and does not do anything. It is just a text description of a possible
    error code in the SMTP protocol, where "SmtpCommandParameterNotImplemented" is a code for an error
    that occurs when a parameter in an SMTP command is not implemented. The code "504" is the numerical
    representation of this error. </summary> */
    SmtpCommandParameterNotImplemented = 504,

    /** <summary> `SmtpAuthenticationRequired = 530` is defining an enum member with a value of 530, which represents
    the SMTP response code for "Authentication required". This enum member is used to represent the SMTP
    response code that is returned by a mail server when authentication is required before the requested
    action can be completed. </summary> */
    SmtpAuthenticationRequired = 530,

    /** <summary> `SmtpAuthenticationMechanismTooWeak = 534` is defining an enum member with a value of 534, which
    represents the SMTP response code for "Authentication mechanism is too weak". This enum member is
    used to represent the SMTP response code that is returned by a mail server when the requested
    authentication mechanism is considered too weak or insecure to be used. </summary> */
    SmtpAuthenticationMechanismTooWeak = 534,

    /** <summary> `SmtpAuthenticationInvalidCredentials = 535` is defining an enum member with a value of 535, which
    represents the SMTP response code for "Authentication credentials invalid". This enum member is used
    to represent the SMTP response code that is returned by a mail server when the authentication
    process fails due to invalid credentials being provided by the client. </summary> */
    SmtpAuthenticationInvalidCredentials = 535,

    /** <summary> `SmtpEncryptionRequired = 538` is defining an enum member with a value of 538, which represents the
    SMTP response code for "Encryption required for requested authentication mechanism". This enum
    member is used to represent the SMTP response code that is returned by a mail server when encryption
    is required for the requested authentication mechanism to be used. </summary> */
    SmtpEncryptionRequired = 538,

    /** <summary> `SmtpMailboxUnavailableOrBusy = 550` is defining an enum member with a value of 550, which
    represents the SMTP response code for "Requested action not taken: mailbox unavailable or busy".
    This enum member is used to represent the SMTP response code that is returned by a mail server when
    the recipient's mailbox is either unavailable or busy and cannot accept new messages at the moment. </summary> */
    SmtpMailboxUnavailableOrBusy = 550,

    /** <summary> `SmtpUserNotLocalTryOther = 551` is defining an enum member with a value of 551, which represents
    the SMTP response code for "User not local; try other path". This enum member is used to represent
    the SMTP response code that is returned by a mail server when the recipient's mailbox is not on the
    current server, but the server will try to deliver the message to another server. </summary> */
    SmtpUserNotLocalTryOther = 551,

    /** <summary> `SmtpExceededStorageAllocation = 552` is defining an enum member with a value of 552, which
    represents the SMTP response code for "Requested mail action aborted: exceeded storage allocation".
    This enum member is used to represent the SMTP response code that is returned by a mail server when
    the requested action cannot be completed because the recipient's mailbox has exceeded its storage
    allocation limit. </summary> */
    SmtpExceededStorageAllocation = 552,

    /** <summary> `SmtpMailboxNameNotAllowed = 553` is defining an enum member with a value of 553, which represents
    the SMTP response code for "Requested action not taken: mailbox name not allowed". This enum member
    is used to represent the SMTP response code that is returned by a mail server when the recipient's
    mailbox name is not allowed or recognized by the server. </summary> */
    SmtpMailboxNameNotAllowed = 553,

    /** <summary> `SmtpTransactionFailed = 554` is defining an enum member with a value of 554, which represents the
    SMTP response code for "Transaction failed". This enum member is used to represent the SMTP response
    code that is returned by a mail server when a transaction fails for some reason. </summary> */
    SmtpTransactionFailed = 554,

    /** <summary> `SmtpMessageTooBig = 554` is defining an enum member with a value of 554, which represents the SMTP
    response code for "Transaction failed: message too big". This enum member is used to represent the
    SMTP response code that is returned by a mail server when the message being sent is too large to be
    accepted by the recipient's mailbox or the mail server. </summary> */
    SmtpMessageTooBig = 554,

    /** <summary> `SmtpTimeout = 554` is defining an enum member with a value of 554, which represents the SMTP
    response code for "Transaction failed: timeout exceeded". This enum member is used to represent the
    SMTP response code that is returned by a mail server when a transaction fails due to a timeout being
    exceeded. </summary> */
    SmtpTimeout = 554,

    /** <summary> `SmtpGenericFailure = 999` is defining an enum member with a value of 999, which represents a
    generic SMTP response code for a failure that cannot be classified under any other specific response
    code. This enum member is used to represent the SMTP response code that is returned by a mail server
    when a command or operation fails for some reason that cannot be classified under any other specific
    response code. </summary> */
    SmtpGenericFailure = 999
}
