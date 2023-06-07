namespace Dgmjr.AspNetCore.Communication.Sms;
public interface ISmsSendResult : IMessageSendResult
{
    SmsSendResponseCode ResponseCode { get; set; }
}

public record struct SmsSendResult : IMessageSendResult
{
    int IMessageSendResult.StatusCode { get; set; }
    public bool IsSuccess { get; }
    public SmsSendResponseCode ResponseCode { get => SmsSendResponseCode.FromId(((IMessageSendResult)this).StatusCode); set => ((IMessageSendResult)this).StatusCode = (int)value; }
}